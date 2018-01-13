using System;
using System.Collections.Generic;

namespace dc
{
    /// <summary>
    /// 物品管理器
    /// @author hannibal
    /// @time 2018-1-11
    /// </summary>
    class ItemManager : Singleton<ItemManager>
    {
        private Dictionary<long, BaseItem> m_all_props = null;

        public ItemManager()
        {
            m_all_props = new Dictionary<long, BaseItem>();
        }

        public void Setup()
        {
        }
        public void Destroy()
        {
        }

        #region 管理器
        /// <summary>
        /// 创建-玩家重新登录
        /// </summary>
        public BaseItem CreateItem(ItemInfo item_info)
        {
            BaseItem prop = CommonObjectPools.Spawn<BaseItem>();
            prop.Init(item_info);
            this.AddItem(prop);
            return prop;
        }
        /// <summary>
        /// 创建-新道具
        /// </summary>
        public BaseItem CreateItem(uint template_idx, uint num)
        {
            long item_idx = IdSharedManager.Instance.GetNextItemIdx();
            BaseItem prop = CommonObjectPools.Spawn<BaseItem>();
            prop.Init(item_idx, new ItemTemplateInfo());
            this.AddItem(prop);
            return prop;
        }
        /// <summary>
        /// 销毁
        /// </summary>
        /// <param name="item_idx"></param>
        public void DestroyItem(long item_idx)
        {
            BaseItem prop;
            if(m_all_props.TryGetValue(item_idx, out prop))
            {
                this.RemoveItem(prop);
            }
        }

        private void AddItem(BaseItem prop)
        {
            if (prop == null) return;
            m_all_props.Add(prop.item_idx, prop);
        }
        private void RemoveItem(BaseItem prop)
        {
            if (prop == null) return;
            CommonObjectPools.Despawn(prop);
            m_all_props.Remove(prop.item_idx);
        }

        public BaseItem GetItem(long item_idx)
        {
            BaseItem prop;
            if (m_all_props.TryGetValue(item_idx, out prop))
            {
                return prop;
            }
            return null;
        }
        public bool HasItem(long item_idx)
        {
            return m_all_props.ContainsKey(item_idx);
        }
        #endregion
    }
}
