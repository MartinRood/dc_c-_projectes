using System;
using System.Collections.Generic;

namespace dc
{
    /// <summary>
    /// 全局id分配
    /// 1.id由(大区id + 服务器内部id + 服务器启动次数 + 自增长id)组成
    /// 2.内存分布(15 + 10 + 18 + 20 = 63)
    /// 3.单次服务器启动分配id上限:2^20(1048576)
    /// 4.不同模块，自增长id不要共用
    /// @author hannibal
    /// @time 2018-1-12
    /// </summary>
    public class IdSharedManager : Singleton<IdSharedManager>
    {
        private int m_server_start_count = 0;
        /// <summary>
        /// 服务器启动次数
        /// </summary>
        private long m_base_id = 0;

        /// <summary>
        /// 角色id
        /// </summary>
        private int m_cur_char_idx = 0;
        /// <summary>
        /// db事件
        /// </summary>
        private int m_cur_db_event_idx = 0;
        /// <summary>
        /// 邮件
        /// </summary>
        private int m_cur_mail_idx = 0;
        /// <summary>
        /// 物品
        /// </summary>
        private int m_cur_item_idx = 0;

        public void InitServerStartCount(int start_count)
        {
            Log.Info("收到ws下发的启动次数:" + start_count);

            m_server_start_count = start_count;
            long realm_idx = ServerNetManager.Instance.srv_realm_idx;
            long sid = ServerNetManager.Instance.srv_uid;
            m_base_id = (realm_idx << 48) | (sid << 38) | ((long)start_count << 20);
        }
        /// <summary>
        /// 角色id
        /// </summary>
        public long GetNextCharIdx()
        {
            return (m_base_id + ++m_cur_char_idx);
        }
        /// <summary>
        /// db事件
        /// </summary>
        public long GetNextDbEventIdx()
        {
            return (m_base_id + ++m_cur_db_event_idx);
        }
        /// <summary>
        /// 邮件
        /// </summary>
        public long GetNextMailIdx()
        {
            return (m_base_id + ++m_cur_mail_idx);
        }
        /// <summary>
        /// 物品
        /// </summary>
        public long GetNextItemIdx()
        {
            return (m_base_id + ++m_cur_item_idx);
        }
    }
}
