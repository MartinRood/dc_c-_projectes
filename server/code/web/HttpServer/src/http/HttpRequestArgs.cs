using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace dc
{
    /// <summary>
    /// http参数处理
    /// @author hannibal
    /// @time 2018-1-10
    /// </summary>
    public class HttpRequestArgs
    {
        /// <summary>
        /// 需要处理的命令集合
        /// </summary>
        private Queue<sRequestInfo> m_request_args = new Queue<sRequestInfo>();
        /// <summary>
        /// 同步逻辑线程和httpserver线程
        /// </summary>
        private object m_lock_obj = new object();

        public void Setup()
        {

        }
        public void Destroy()
        {
            m_request_args.Clear();
        }
        public void Update()
        {
            int count = 0;
            while (this.HasArgs() && count++ < 100)
            {
                sRequestInfo info = this.PopArgs();
                if (string.IsNullOrEmpty(info.key) || string.IsNullOrEmpty(info.value)) continue;
                //switch(info.key)
                //{
                //    //TODO
                //}
            }
        }

        public bool HasArgs()
        {
            return m_request_args.Count > 0;
        }
        /// <summary>
        /// 取参数
        /// </summary>
        public sRequestInfo PopArgs()
        {
            if (m_request_args.Count == 0)
            {
                Log.Warning("参数队列为空");
                return new sRequestInfo();
            }
            sRequestInfo info;
            lock(m_lock_obj)
            {
                info = m_request_args.Dequeue();
            }
            return info;
        }

        #region 解析
        /// <summary>
        /// 解析get请求
        /// </summary>
        /// <param name="QueryString"></param>
        public void ParseGetRequest(NameValueCollection QueryString)
        {
            for(int i = 0; i < QueryString.Count; ++i)
            {
                sRequestInfo info = new sRequestInfo();
                info.key = QueryString.GetKey(i);
                info.value = QueryString.Get(i);
                lock (m_lock_obj)
                {
                    m_request_args.Enqueue(info);
                }
            }
        }
        /// <summary>
        /// 解析post请求
        /// </summary>
        public void ParsePostRequest(string content)
        {
            if (string.IsNullOrEmpty(content)) return;

            string[] arrs = content.Split('&');
            if (arrs == null || arrs.Length == 0) return;

            for (int i = 0; i < arrs.Length; ++i)
            {
                string[] arr = arrs[i].Split('=');
                if (arr == null || arr.Length != 2) continue;
                sRequestInfo info = new sRequestInfo();
                info.key = arr[0];
                info.value = arr[1];
                lock(m_lock_obj)
                {
                    m_request_args.Enqueue(info);
                }
            }
        }
        #endregion
    }
}
