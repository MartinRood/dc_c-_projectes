using System;
using System.Collections.Generic;

namespace dc
{
    /// <summary>
    /// 物品基类
    /// @author hannibal
    /// @time 2018-1-11
    /// </summary>
    public class BaseItem
    {
        protected long m_item_idx;              //唯一id
        protected long m_char_idx;              //携带者
        protected eItemMainType m_main_type;    //类型
        protected eItemSubType m_sub_type;      //类型
        protected eBagType m_bag_type;          //背包类型
        protected uint m_ui_pos;                //在ui面板位置
        protected uint m_number;                //叠加数量
        protected long m_create_time;           //获得时间

        public virtual void Init(ItemInfo item_info)
        {
            this.Serialize(item_info);
        }
        public virtual void Init(long _item_idx, ItemTemplateInfo template_info)
        {
            m_item_idx = _item_idx;
        }

        #region 序列化
        public virtual void Serialize(ItemInfo item_info)
        {
            m_item_idx = item_info.item_idx;
            m_char_idx = item_info.char_idx;
            //m_main_type = item_info.type;
            m_sub_type = item_info.type;
            m_bag_type = item_info.bag_type;
            m_ui_pos = item_info.ui_pos;
            m_number = item_info.number;
            m_create_time = item_info.create_time;
        }
        public virtual void Derialize(ItemInfo item_info)
        {
        }
        #endregion

        #region get/set
        public void SetCharIdx(long char_idx)
        {
            m_char_idx = char_idx;
        }
        public virtual void SetUIPos(uint ui_pos)
        {
            m_ui_pos = ui_pos;
        }
        /// <summary>
        /// 设置数量
        /// </summary>
        public virtual uint SetNumber(uint number)
        {
            m_number = number;
            return m_number;
        }
        /// <summary>
        /// 增加数量
        /// </summary>
        public virtual uint AddNumber(uint number)
        {
            m_number += number;
            return m_number;
        }
        /// <summary>
        /// 消耗
        /// </summary>
        public virtual uint SubNumber(uint number)
        {
            if (number > m_number)
                m_number = 0;
            else
                m_number -= number;
            return m_number;
        }

        public long item_idx            { get { return m_item_idx; } }
        public long char_idx            { get { return m_char_idx; } }
        public eItemMainType main_type  { get { return m_main_type; } }
        public eItemSubType sub_type    { get { return m_sub_type; } }
        public eBagType bag_type        { get { return m_bag_type; } }
        public uint ui_pos              { get { return m_ui_pos; } }
        public uint number              { get { return m_number; } }
        public long create_time         { get { return m_create_time; } }
        #endregion
    }
}
