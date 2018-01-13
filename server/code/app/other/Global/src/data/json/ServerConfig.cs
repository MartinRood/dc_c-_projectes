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
        public static ServerNetInfo net_info;
        public static ServerDBInfo db_info;
        public static bool Load()
        {
            bool ret_net = JsonFile.Read<ServerNetInfo>("./global.json", ref net_info);
            bool ret_db = JsonFile.Read<ServerDBInfo>("./db.json", ref db_info);
            if (!server.CheckSidValid(net_info.server_uid))
            {
                Log.Error("错误的服务器id:" + net_info.server_uid);
                return false;
            }
            return ret_net && ret_db;
        }
    }

    public class ServerNetInfo
    {
        public int log_level;
        public ushort server_uid;//本区服务器唯一id
        public string ip_for_server;
        public ushort port_for_server;
    }
    public class ServerDBInfo
    {
        public List<DBItems> db_list = new List<DBItems>();//数据库列表
    }
}
