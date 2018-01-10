using System;
using System.Collections.Generic;

namespace dc
{
    /// <summary>
    /// 服务器配置
    /// @author hannibal
    /// @time 2016-8-1
    /// </summary>
    public class ServerConfig
    {
        public static ServerConfigInfo info;
        public static bool Load()
        {
            bool ret_net = JsonFile.Read<ServerConfigInfo>("./http_server.json", ref info);
            return ret_net;
        }
    }

    public class ServerConfigInfo
    {
        public class DBItems
        {
            public ushort id;
            public string name;     //dc_game数据库名
            public string address;  //dc_game数据库地址
            public ushort port;
            public string username;
            public string password;
        }
        public int log_level;
        public ushort port_for_server;//监听端口
        public List<DBItems> db_list = new List<DBItems>();//数据库列表
    }
}
