using System;
using System.Collections.Generic;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace dc
{
    /// <summary>
    /// 物品
    /// @author hannibal
    /// @time 2016-11-1
    /// </summary>
    public class SQLItemHandle
    {
        /// <summary>
        /// 玩家所有物品
        /// </summary>
        public static void LoadItem(long char_idx, DBID db_id, Action<List<ItemInfo>> callback)
        {
            string sql = "call SP_ITEM_LIST(" + char_idx + ")";
            DBManager.Instance.GetDB(eDBType.Game, db_id.game_id).Query(sql, (reader) =>
            {
                List<ItemInfo> list = new List<ItemInfo>();
                while (reader.HasRows && reader.Read())
                {
                    int idx = 0;
                    ItemInfo data = CommonObjectPools.Spawn<ItemInfo>();
                    data.item_idx = reader.GetInt64(idx++);
                    data.char_idx = reader.GetInt64(idx++);
                    data.type = (eItemSubType)reader.GetUInt32(idx++);
                    data.bag_type = (eBagType)reader.GetUInt16(idx++);
                    data.ui_pos = reader.GetUInt32(idx++);
                    data.number = reader.GetUInt32(idx++);
                    data.create_time = reader.GetInt64(idx++);
                    //内容
                    long len = reader.GetBytes(idx, 0, null, 0, int.MaxValue);
                    ByteArray by = DBUtils.AllocDBArray();
                    reader.GetBytes(idx, 0, by.Buffer, 0, (int)len);
                    by.WriteEmpty((int)len);
                    data.bin_content.Read(by);
                    list.Add(data);
                }
                callback(list);
            });
        }
        /// <summary>
        /// 创建物品
        /// </summary>
        public static void CreateItem(ItemInfo info, DBID db_id)
        {
            string sql = "insert into `character_all_item` " +
            "(item_idx, char_idx,type,bag_type,ui_pos,number,create_time,bin_content) " +
            "values (" +
            info.item_idx + "," +
            info.char_idx + "," +
            (uint)info.type + "," +
            (ushort)info.bag_type + "," +
            info.ui_pos + "," +
            info.number + "," +
            info.create_time + "," +
            "@bin_content)";

            ByteArray by = DBUtils.AllocDBArray();
            info.bin_content.Write(by);
            List<MySqlParameter> param = new List<MySqlParameter>();
            MySqlParameter p = Database.MakeMysqlParam("@bin_content", MySqlDbType.Blob, by.GetBuffer(), by.Available);
            param.Add(p);
            DBManager.Instance.GetDB(eDBType.Game, db_id.game_id).Execute(sql, param);
        }
    }
}
