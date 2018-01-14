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
        /// 创号
        /// </summary>
        /// <param name="info"></param>
        /// <param name="callback"></param>
        public static void CreateCharacter(long account_idx, CreateCharacterInfo info, Action<long> callback)
        {
            string sql = "call SP_CHARACTER_CREATE("
                + 1 + ","
                + info.char_idx + ","
                + account_idx + ","
                + info.spid + ",'"
                + info.char_name + "',"
                + info.char_type + ","
                + info.ws_id + ","
                + info.ss_id + ","
                + info.fs_id
                + ")";
            try
            {
                DatabaseManager.Instance.GetDB().Query(sql, (reader) =>
                {
                    long result = 0;
                    if (reader.HasRows && reader.Read())
                    {
                        result = reader.GetInt64(0);
                    }
                    callback(result);
                });
            }
            catch(Exception e)
            {
                Log.Exception(e);
            }
        }
    }
}
