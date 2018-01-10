using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;

namespace dc
{
    /// <summary>
    /// 处理http
    /// @author hannibal
    /// @time 2018-1-10
    /// </summary>
    public class HttpServerManager : Singleton<HttpServerManager>
    {
        private HttpListener m_http_listerner;
        /// <summary>
        /// 监听线程是否关闭
        /// </summary>
        private bool m_disposed = false;
        /// <summary>
        /// request参数
        /// </summary>
        private HttpRequestArgs m_request_args = new HttpRequestArgs();

        public void Setup()
        {
            m_request_args.Setup();

            //打开端口
            this.AddFireWallPort(ServerConfig.info.port_for_server);

            m_http_listerner = new HttpListener();
            m_http_listerner.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
            m_http_listerner.Prefixes.Add("http://localhost:" + ServerConfig.info.port_for_server + "/");
        }
        public void Destroy()
        {
            m_request_args.Destroy();

            m_disposed = true;
            m_http_listerner.Close();
        }
        public void Tick()
        {
            m_request_args.Update();
        }
        /// <summary>
        /// 开启服务
        /// </summary>
        public void Start()
        {
            m_http_listerner.Start();

            //启动新线程处理逻辑
            new Thread(new ThreadStart(OnRequestThread)).Start();
        }
        /// <summary>
        /// 防火墙打开端口
        /// </summary>
        /// <param name="port"></param>
        private void AddFireWallPort(int port)
        {
            string argsDll = String.Format(@"firewall set portopening TCP {0} ENABLE", port);
            ProcessStartInfo psi = new ProcessStartInfo("netsh", argsDll);
            psi.Verb = "runas";
            psi.CreateNoWindow = true;
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.UseShellExecute = false;
            Process.Start(psi).WaitForExit();
        }
        /// <summary>
        /// 处理请求
        /// </summary>
        private void OnRequestThread()
        {
            while (!m_disposed)
            {
                try
                {
                    HttpListenerContext httpListenerContext = m_http_listerner.GetContext();

                    if (httpListenerContext.Request.HttpMethod == "GET")
                    {
                        m_request_args.ParseGetRequest(httpListenerContext.Request.QueryString);
                    }
                    else if (httpListenerContext.Request.HttpMethod == "POST")
                    {
                        using (var reader = new StreamReader(httpListenerContext.Request.InputStream, System.Text.Encoding.UTF8))
                        {
                            var content = reader.ReadToEnd();
                            Console.WriteLine(content);
                            m_request_args.ParsePostRequest(content);
                        }
                    }

                    httpListenerContext.Response.StatusCode = 200;
                    using (StreamWriter writer = new StreamWriter(httpListenerContext.Response.OutputStream))
                    {
                        writer.Write(((int)eResponseCode.Succeed).ToString());
                    }
                }
                catch(Exception e)
                {
                    Log.Exception(e);

                    try
                    {
                        //发送失败消息
                        HttpListenerContext requestContext = m_http_listerner.GetContext();
                        requestContext.Response.StatusCode = 500;
                        using (StreamWriter writer = new StreamWriter(requestContext.Response.OutputStream))
                        {
                            writer.Write(((int)eResponseCode.Unknow).ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Exception(ex);
                        m_disposed = true;
                    }
                }
            }
        }
    }
}
