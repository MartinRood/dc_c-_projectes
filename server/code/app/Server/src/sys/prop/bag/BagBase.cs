using System;
using System.Collections.Generic;

namespace dc
{
    /// <summary>
    /// 包裹
    /// @author hannibal
    /// @time 2018-1-11
    /// </summary>
    public class BagBase
    {
        private List<long> m_all_props = new List<long>();

        #region 管理器
        public virtual void AddItem(long item_idx)
        {
            if (!m_all_props.Contains(item_idx))
                m_all_props.Add(item_idx);
        }
        public virtual void RemoveItem(long item_idx)
        {
            m_all_props.Remove(item_idx);
        }
        public List<long> all_props
        {
            get { return m_all_props; }
        }
        #endregion
    }
}
