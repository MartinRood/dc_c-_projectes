﻿using System;
using System.Collections.Generic;

namespace dc
{
    /// <summary>
    /// 管理器
    /// @author hannibal
    /// @time 2017-7-28
    /// </summary>
    public class Master : Singleton<Master>
    {
        public void Setup()
        {
            //初始化日志，放最前面
            Log4Helper.Init(log4net.LogManager.GetLogger("loginfo"), log4net.LogManager.GetLogger("loginfo"), log4net.LogManager.GetLogger("logerror"), log4net.LogManager.GetLogger("logerror"));

            Log.Info("开启时间(" + DateTime.Now.ToString() + ")");
            ServerConfig.Load();
            Console.Title = "DB:" + ServerConfig.net_info.server_uid;

            Framework.Instance.Setup(Tick);
            DataManager.Instance.Setup();
            DBManager.Instance.Setup();
            ServerNetManager.Instance.Setup();
            ForServerNetManager.Instance.Setup();
            PlayerCacheManager.Instance.Setup();
            MailCacheManager.Instance.Setup();
            ServerCmdManager.Instance.Setup();
        }
        public void Destroy()
        {
            Framework.Instance.Destroy();
            DataManager.Instance.Destroy();
            DBManager.Instance.Destroy();
            ServerNetManager.Instance.Destroy();
            ForServerNetManager.Instance.Destroy();
            PlayerCacheManager.Instance.Destroy();
            MailCacheManager.Instance.Destroy();
            ServerCmdManager.Instance.Destroy();

            Log.Info("服务器关闭");
        }
        public void Tick()
        {
            ServerNetManager.Instance.Tick();
            ForServerNetManager.Instance.Tick();
            DBManager.Instance.Tick();
            PlayerCacheManager.Instance.Tick();
            MailCacheManager.Instance.Tick();
        }

        public void Start()
        {
            //启动DB
            DBManager.Instance.Start(ServerConfig.net_info.db_list);
            DataManager.Instance.LoadAll();
            ServerNetManager.Instance.Connect2WorldServer(ServerConfig.net_info.ws_ip, ServerConfig.net_info.ws_port);
            
            Framework.Instance.MainLoop();
        }
        /// <summary>
        /// 主动关服
        /// </summary>
        public void Stop()
        {
            this.Destroy();

            while (true)
            {
                System.Threading.Thread.Sleep(1);
            }
        }
    }
}