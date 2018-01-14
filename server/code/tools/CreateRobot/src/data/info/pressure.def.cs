using System;
using System.Collections.Generic;

namespace dc
{
    /// <summary>
    /// 创建用户数据
    /// </summary>
    public class sCreateUserInfo
    {
        public string ip;
        public ushort port;
        public string db_name;
        public long start_id;       //起始id
        public long start_account;  //起始账号
        public long end_account;
    }
}
