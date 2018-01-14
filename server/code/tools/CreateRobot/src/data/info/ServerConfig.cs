using System;
using System.Collections.Generic;

namespace dc
{
    public class ServerConfig
    {
        public static ServerDBInfo db_info;
        public static bool Read()
        {
            if (JsonFile.Read<ServerDBInfo>("./create_robot.json", ref db_info))
                return true;
            else 
                return false;
        }
    }

    public class ServerDBInfo
    {
        public string name;     //dc_game数据库名
        public string address;  //dc_game数据库地址
        public ushort port;
        public string username;
        public string password;
    }
}
