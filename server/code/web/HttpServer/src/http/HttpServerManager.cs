﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;

namespace dc
{
    public class HttpServerManager : Singleton<HttpServerManager>
    {
        public void Setup()
        {

        }
        public void Destroy()
        {

        }
        public void Start()
        {
            HttpListener httpListener = new HttpListener();

            httpListener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
            httpListener.Prefixes.Add("http://localhost:8080/");
            httpListener.Start();
            new Thread(new ThreadStart(delegate
            {
                while (true)
                {
                    HttpListenerContext httpListenerContext = httpListener.GetContext();

                    if (httpListenerContext.Request.HttpMethod == "GET")
                    {
                        Console.WriteLine(httpListenerContext.Request.QueryString["name"]);
                    }
                    else if (httpListenerContext.Request.HttpMethod == "POST")
                    {
                        using (var reader = new StreamReader(httpListenerContext.Request.InputStream,System.Text.Encoding.UTF8))
                        {
                            var text = reader.ReadToEnd();
                            Console.WriteLine(text);
                        }
                    }

                    httpListenerContext.Response.StatusCode = 200;
                    using (StreamWriter writer = new StreamWriter(httpListenerContext.Response.OutputStream))
                    {
                        writer.WriteLine("<html><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"/><title>测试服务器</title></head><body>");
                        writer.WriteLine("<div style=\"height:20px;color:blue;text-align:center;\"><p> hello</p></div>");
                        writer.WriteLine("<ul>");
                        writer.WriteLine("</ul>");
                        writer.WriteLine("</body></html>");
                    }
                }
            })).Start();
        }
    }
}
