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
    public class SQLCharHandle
    {
        /*～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～game～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～*/
        /// <summary>
        /// 最大角色id
        /// </summary>
        /// <param name="callback"></param>
        public static void QueryMaxCharIdx(ushort ws_id, DBID db_id, Action<long> callback)
        {
            string sql = "select count(*), max(char_index) from `character` where ws_id = " + ws_id;
            long max_id = 0;//从这个开始
            DBManager.Instance.GetDB(eDBType.Game, db_id.game_id).QuerySync(sql, (reader) =>
            {
                if (reader.HasRows && reader.Read())
                {
                    int count = reader.GetInt32(0);
                    if (count > 0) max_id = reader.GetInt64(1);
                }
                callback(max_id);
            });
        }
    }
}
