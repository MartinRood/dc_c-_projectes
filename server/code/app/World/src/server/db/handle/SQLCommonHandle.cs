using System;
using System.Collections.Generic;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace dc
{
    /// <summary>
    /// 角色操作
    /// @author hannibal
    /// @time 2016-9-1
    /// </summary>
    public class SQLCommonHandle
    {
        /// <summary>
        /// 服务器启动次数
        /// </summary>
        public static void GetServerStartCount(DBID db_id, Action<int> callback)
        {
            string sql = "call SP_SERVER_START_COUNT";
            DBManager.Instance.GetDB(eDBType.Game, db_id.game_id).QuerySync(sql, (reader) =>
            {
                int count = 0;
                if (reader.HasRows && reader.Read())
                {
                    count = reader.GetInt32(0);
                }
                callback(count);
            });
        }
    }
}
