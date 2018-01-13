using System;
using System.Collections.Generic;

namespace dc
{
    /// <summary>
    /// 单个玩家包裹
    /// @author hannibal
    /// @time 2018-1-11
    /// </summary>
    class PlayerBag
    {
        /// <summary>
        /// 包裹携带者
        /// </summary>
        private long m_char_idx;
        private Dictionary<eBagType, BagBase> m_all_bags = null;

        public PlayerBag()
        {
            m_all_bags = new Dictionary<eBagType, BagBase>();
        }

        public void Setup()
        {
            m_all_bags.Add(eBagType.Main, new Bag_Main());
            m_all_bags.Add(eBagType.Equip, new Bag_Equip());
            m_all_bags.Add(eBagType.Store, new Bag_Store());
            m_all_bags.Add(eBagType.Weapon, new Bag_Weapon());
        }
        public void Destroy()
        {
            this.Save();
        }

        #region 数据加载，保存
        /// <summary>
        /// 加载玩家所有物品
        /// </summary>
        /// <param name="_char_idx"></param>
        public void Load(long _char_idx)
        {
            m_char_idx = _char_idx;

            Player player = UnitManager.Instance.GetPlayerByIdx(m_char_idx);
            if(player == null)
            {
                Log.Error("未找到玩家信息:" + m_char_idx);
                return;
            }
            SQLItemHandle.LoadItem(m_char_idx, player.db_id, list => 
            {
                foreach(ItemInfo info in list)
                {
                    this.CreateItem(info);
                }
            });
        }
        /// <summary>
        /// 保存更改
        /// </summary>
        public void Save()
        {
        }

        #endregion

        #region 管理器
        /// <summary>
        /// 创建
        /// </summary>
        public void CreateItem(ItemInfo item_info)
        {
            BaseItem prop = ItemManager.Instance.CreateItem(item_info);
            if(prop == null)
            {
                Log.Error("创建物品失败:" + item_info.item_idx);
                return;
            }
            this.AddItem(prop.item_idx);
        }
        /// <summary>
        /// 添加道具到背包
        /// </summary>
        public void AddItem(long item_idx)
        {
            BaseItem prop = ItemManager.Instance.GetItem(item_idx);
            if(prop == null)
            {
                Log.Warning("未发现物品:" + item_idx);
                return;
            }
            BagBase bag = this.GetBag(prop.bag_type);
            bag.AddItem(item_idx);
        }
        /// <summary>
        /// 从背包移除
        /// </summary>
        public void RemoveItem(long item_idx)
        {
            BaseItem prop = ItemManager.Instance.GetItem(item_idx);
            if (prop == null)
            {
                Log.Warning("未发现物品:" + item_idx);
                return;
            }
            BagBase bag = this.GetBag(prop.bag_type);
            bag.RemoveItem(item_idx);
        }
        /// <summary>
        /// 获取背包
        /// </summary>
        public BagBase GetBag(eBagType type)
        {
            switch(type)
            {
                case eBagType.Equip: return this.GetEquipBag();
                case eBagType.Store: return this.GetStoreBag();
                case eBagType.Weapon: return this.GetWeaponBag();
                case eBagType.Main: 
                default:
                    return this.GetDefaultBag();
            }
        }
        public Bag_Main GetDefaultBag()
        {
            return m_all_bags[eBagType.Main] as Bag_Main;
        }
        public Bag_Equip GetEquipBag()
        {
            return m_all_bags[eBagType.Equip] as Bag_Equip;
        }
        public Bag_Store GetStoreBag()
        {
            return m_all_bags[eBagType.Store] as Bag_Store;
        }
        public Bag_Weapon GetWeaponBag()
        {
            return m_all_bags[eBagType.Weapon] as Bag_Weapon;
        }
        #endregion
    }
}
