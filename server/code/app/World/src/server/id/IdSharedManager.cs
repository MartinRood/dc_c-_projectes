using System;
using System.Collections.Generic;

namespace dc
{
    /// <summary>
    /// 全局id分配
    /// @author hannibal
    /// @time 2018-1-12
    /// </summary>
    public class IdSharedManager : Singleton<IdSharedManager>
    {
        /// <summary>
        /// 服务器启动次数
        /// </summary>
        private int m_server_start_count = 0;

        public IdSharedManager()
        {
        }

        public void Setup()
        {
        }
        public void Destroy()
        {
        }
        /// <summary>
        /// 初始化每个gamedb对应的启动次数
        /// </summary>
        public void Init()
        {
            foreach (var obj in ServerConfig.db_info.db_list)
            {
                if (obj.type == (ushort)eDBType.Game)
                {
                    QueryMaxCount(obj.id);
                }
            }
            if (m_server_start_count < 0 || m_server_start_count > 1048576)// 2 ^ 20 == 1048576
            {
                Log.Error("启动次数错误:" + m_server_start_count);
            }
            else
            {
                Log.Info("服务器启动最大次数:" + m_server_start_count);
            }
        }
        private void QueryMaxCount(ushort game_db_id)
        {
            DBID db_id = new DBID();
            db_id.game_id = game_db_id;
            SQLCommonHandle.GetServerStartCount(db_id, max_id =>
            {
                if (max_id > m_server_start_count)
                    m_server_start_count = max_id;
            });
        }
        /// <summary>
        /// 发送次数给连接服务器
        /// </summary>
        /// <param name="conn_idx"></param>
        public void SendStartCount(long conn_idx)
        {
            inner.ServerStartCount msg = PacketPools.Get(inner.msg.SERVER_START_COUNT) as inner.ServerStartCount;
            msg.count = m_server_start_count;
            ServerNetManager.Instance.Send(conn_idx, msg);
        }
    }
}
