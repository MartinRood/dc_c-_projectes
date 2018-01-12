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
        private long m_base_id = 0;

        public void InitServerStartCount(int start_count)
        {
            Log.Info("收到ws下发的启动次数:" + start_count);

            ushort realm_idx = ServerNetManager.Instance.srv_realm_idx;
            ushort sid = ServerNetManager.Instance.srv_uid;

            m_base_id = (sid << 52) | (start_count << 32);
        }
    }
}
