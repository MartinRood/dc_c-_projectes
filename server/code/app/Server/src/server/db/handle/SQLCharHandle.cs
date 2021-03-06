﻿using System;
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
        public static void CreateCharacter(long account_idx, DBID db_id, CreateCharacterInfo info, Action<long> callback)
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
            DBManager.Instance.GetDB(eDBType.Game, db_id.game_id).Query(sql, (reader) =>
            {
                long result = 0;
                if (reader.HasRows && reader.Read())
                {
                    result = reader.GetInt64(0);
                }
                callback(result);
            });
        }
        /// <summary>
        /// 查询需要预加载的角色列表
        /// </summary>
        /// <param name="callback"></param>
        public static void QueryCharForPreload(uint load_max, DBID db_id, Action<List<long>> callback)
        {
            List<long> list = new List<long>();
            string sql = "call SP_CHARACTER_FOR_PRELOAD";
            DBManager.Instance.GetDB(eDBType.Game, db_id.game_id).Query(sql, (reader) =>
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        long char_idx = reader.GetInt64(0);
                        list.Add(char_idx);
                    }
                }
                callback(list);
            });
        }
        /// <summary>
        /// 角色列表
        /// </summary>
        /// <param name="username">登录用户名</param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static void QueryCharacterList(long account_idx, DBID db_id, Action<List<CharacterLogin>> callback)
        {
            string sql = "call SP_CHARACTER_ENUM(" + account_idx + ")";
            DBManager.Instance.GetDB(eDBType.Game, db_id.game_id).Query(sql, (reader) =>
            {
                List<CharacterLogin> list = new List<CharacterLogin>();
                if (reader.HasRows && reader.Read())
                {
                    int idx = 0;
                    CharacterLogin data = new CharacterLogin();
                    data.char_idx = reader.GetInt64(idx++);
                    data.char_name = reader.GetString(idx++);
                    data.char_type = reader.GetByte(idx++);
                    data.level = reader.GetUInt16(idx++);
                    data.wid = reader.GetUInt16(idx++);
                    data.sid = reader.GetUInt16(idx++);
                    data.dbid = reader.GetUInt16(idx++);
                    list.Add(data);
                }
                callback(list);
            });
        }
        /// <summary>
        /// 查询角色信息
        /// </summary>
        /// <param name="info"></param>
        /// <param name="callback"></param>
        public static void QueryCharacterInfo(long char_idx, DBID db_id, PlayerInfoForSS data, Action<bool> callback)
        {
            bool ret = false;
            string sql = "call SP_CHARACTER_BASE(" + char_idx + ")";
            DBManager.Instance.GetDB(eDBType.Game, db_id.game_id).Query(sql, (reader) =>
            {
                if (reader.HasRows && reader.Read())
                {
                    int idx = 0;
                    data.char_idx = reader.GetInt64(idx++);
                    data.account_index = reader.GetInt64(idx++);
                    data.spid = reader.GetUInt16(idx++);
                    data.char_name = reader.GetString(idx++);
                    data.char_type = reader.GetByte(idx++);
                    data.ws_id = reader.GetUInt16(idx++);
                    data.ss_id = reader.GetUInt16(idx++);
                    data.fs_id = reader.GetUInt16(idx++);
                    data.pos_x = reader.GetInt32(idx++);
                    data.pos_y = reader.GetInt32(idx++);
                    data.scene_type_idx = reader.GetUInt32(idx++);
                    data.scene_obj_idx = reader.GetInt64(idx++);
                    data.flags = reader.GetUInt32(idx++);
                    data.model_idx = reader.GetUInt32(idx++);
                    data.job = reader.GetByte(idx++);
                    data.level = reader.GetUInt16(idx++);
                    data.exp = reader.GetUInt32(idx++);
                    data.energy = reader.GetUInt32(idx++);
                    data.gold = reader.GetUInt32(idx++);
                    data.coin = reader.GetUInt32(idx++);
                    data.hp = reader.GetUInt32(idx++);
                    data.hp_max = reader.GetUInt32(idx++);
                    data.hurt = reader.GetUInt32(idx++);
                    data.range = reader.GetUInt32(idx++);
                    data.run_speed = reader.GetUInt32(idx++);
                    data.vip_grade = reader.GetUInt32(idx++);
                    data.vip_flags = reader.GetUInt32(idx++);
                    data.time_last_login = reader.GetInt64(idx++);
                    data.time_last_logout = reader.GetInt64(idx++);
                    ret = true;
                }
                else
                {
                    Log.Warning("查询角色失败:" + char_idx);
                }
                callback(ret);
            });
        }
        /// <summary>
        /// 查询角色信息
        /// </summary>
        public static void QueryCharacterInfoByName(string char_name, DBID db_id, Action<bool, PlayerInfoByName> callback)
        {
            bool ret = false;
            PlayerInfoByName data = new PlayerInfoByName();
            string sql = "call SP_CHARACTER_ENUM_BY_NAME('" + char_name + "')";
            DBManager.Instance.GetDB(eDBType.Game, db_id.game_id).Query(sql, (reader) =>
            {
                if (reader.HasRows && reader.Read())
                {
                    int idx = 0;
                    data.char_idx = reader.GetInt64(idx++);
                    data.char_name = reader.GetString(idx++);
                    data.char_type = reader.GetByte(idx++);
                    data.level = reader.GetUInt16(idx++);
                    ret = true;
                }
                else
                {
                    Log.Debug("根据名称查询角色失败:" + char_name);
                }
                callback(ret, data);
            });
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="info"></param>
        public static void SaveCharacterInfo(DBID db_id, PlayerInfoForSS info)
        {
            string sql = ("update `character` set " +
                "`char_name` = '" + info.char_name + "'," +       // 名字
                "`char_type` = '" + info.char_type + "'," +       // 角色类型(男 or 女 )
                "`ws_id` = '" + info.ws_id + "'," +                 // 
                "`ss_id` = '" + info.ss_id + "'," +                 // 
                "`fs_id` = '" + info.fs_id + "'," +               // 
                "`pos_x` = '" + info.pos_x + "'," +               // 
                "`pos_y` = '" + info.pos_y + "'," +               // 
                "`scene_type_idx` = '" + info.scene_type_idx + "'," +
                "`scene_obj_idx` = '" + info.scene_obj_idx + "'," +
                "`flags` = '" + info.flags + "'," +               // 特殊标记
                "`model_idx` = '" + info.model_idx + "'," +       // 模型ID
                "`job` = '" + info.job + "'," +                   // 职业
                "`level` = '" + info.level + "'," +               // 角色等级
                "`exp` = '" + info.exp + "'," +                   // 当前经验
                "`energy` = '" + info.energy + "'," +             // 能量
                "`gold` = '" + info.gold + "'," +                 // 金币（点卷）
                "`coin` = '" + info.coin + "'," +                 // 游戏币(铜币)
                "`hp` = '" + info.hp + "'," +                     // 生命
                "`hp_max` = '" + info.hp_max + "'," +             // 生命上限
                "`hurt` = '" + info.hurt + "'," +                 // 伤害
                "`range` = '" + info.range + "'," +               // 攻击范围
                "`run_speed` = '" + info.run_speed + "'," +       // vip等级
                "`vip_grade` = '" + info.vip_grade + "'," +
                "`vip_flags` = '" + info.vip_flags + "'," +       // vip flags
                "`time_last_login` = '" + info.time_last_login + "'," +
                "`time_last_logout` = '" + info.time_last_logout + "'," +
                "`last_update_time` = now() where `character`.char_index=" + info.char_idx
                );
            DBManager.Instance.GetDB(eDBType.Game, db_id.game_id).Execute(sql);
        }
    }
}
