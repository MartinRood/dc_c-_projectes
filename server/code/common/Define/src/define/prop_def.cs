using System;
using System.Collections.Generic;

namespace dc
{
    /// <summary>
    /// 物品
    /// @author hannibal
    /// @time 2018-1-11
    /// </summary>
    public class item
    {
        /// <summary>
        /// 物品是否合法
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool IsValidProp(PropID item_id)
        {
            switch (item_id.type)
            {
                case ePropType.CURRENCY:
                    eCurrencyType sub_type = (eCurrencyType)item_id.obj_type;
                    if (sub_type != eCurrencyType.Diamond && sub_type != eCurrencyType.Gold && sub_type != eCurrencyType.Silver)
                        return false;

                    break;

                case ePropType.ITEM:

                    break;

                default:
                    break;
            }
            return true;
        }

        public static eItemMainType GetMainType(eItemSubType type)
        {
            return eItemMainType.EXPENDABLE;
        }
    }

    /// <summary>
    /// 道具id
    /// </summary>
    public struct PropID : ISerializeObject
    {
        public ePropType type;      //主类型
        public uint obj_type;       //副类型(货币：货币类型，物品：物品id)
        public long obj_value;      //数量

        public void Set(ePropType _type, uint _obj_type, long _obj_value)
        {
            this.type = _type;
            this.obj_type = _obj_type;
            this.obj_value = _obj_value;
        }
        public void Read(ByteArray by)
        {
            type = (ePropType)by.ReadByte();
            obj_type = by.ReadUInt();
            obj_value = by.ReadLong();
        }
        public void Write(ByteArray by)
        {
            by.WriteByte((byte)type);
            by.WriteUInt(obj_type);
            by.WriteLong(obj_value);
        }
    }

    /// <summary>
    /// 物品信息
    /// </summary>
    public class ItemInfo : ISerializeObject, IPoolsObject
    {
        public long item_idx;
        public long char_idx;
        private eItemSubType _type; //类型
        public eBagType bag_type;   //背包类型
        public uint ui_pos;         //在ui面板位置
        public uint number;         //叠加数量
        public long create_time;    //获得时间

        // 内容
        public ItemContent bin_content = new ItemContent();

        public void Init()
        {

        }

        public void Copy(ItemInfo item_info)
        {
            item_idx = item_info.item_idx;
            char_idx = item_info.char_idx;
            type = item_info.type;
            bag_type = item_info.bag_type;
            ui_pos = item_info.ui_pos;
            number = item_info.number;
            create_time = item_info.create_time;
            bin_content = item_info.bin_content;
        }
        public void Read(ByteArray by)
        {
            item_idx = by.ReadLong();
            char_idx = by.ReadLong();
            type = (eItemSubType)by.ReadUInt();
            bag_type = (eBagType)by.ReadUShort();
            ui_pos = by.ReadUInt();
            number = by.ReadUInt();
            create_time = by.ReadLong();
            bin_content.Read(by);
        }
        public void Write(ByteArray by)
        {
            by.WriteLong(item_idx);
            by.WriteLong(char_idx);
            by.WriteUInt((uint)type);
            by.WriteUShort((ushort)type);
            by.WriteUInt(ui_pos);
            by.WriteUInt(number);
            by.WriteLong(create_time);
            bin_content.Write(by);
        }
        public eItemSubType type
        {
            get { return _type; }
            set 
            {
                _type = value;
                bin_content.content_type = item.GetMainType(_type);
            }
        }
    }

    /// <summary>
    /// 物品内容
    /// </summary>
    public struct ItemContent : ISerializeObject
    {
        public eItemMainType content_type;
        public ItemNormalContent bin_normal_content;
        public void Read(ByteArray by)
        {
            switch (content_type)
            {
                case eItemMainType.EXPENDABLE: bin_normal_content.Read(by); break;
            }
        }
        public void Write(ByteArray by)
        {
            switch (content_type)
            {
                case eItemMainType.EXPENDABLE: bin_normal_content.Write(by); break;
            }
        }
    }
    /// <summary>
    /// 普通物品内容
    /// </summary>
    public struct ItemNormalContent : ISerializeObject
    {
        public string content;
        public void Read(ByteArray by)
        {
            content = by.ReadString();
        }
        public void Write(ByteArray by)
        {
            content = "";
            by.WriteString(content);
        }
    }

    /// <summary>
    /// 模板数据
    /// </summary>
    public class ItemTemplateInfo : ISerializeObject, IPoolsObject
    {
        public void Init()
        {

        }
        public void Read(ByteArray by)
        {
        }
        public void Write(ByteArray by)
        {
        }
    }

    /// <summary>
    /// 道具类型
    /// </summary>
    public enum ePropType
    {
        CURRENCY,           // 货币
        ITEM,               //物品
    }

    /// <summary>
    /// 物品主类型
    /// </summary>
    public enum eItemMainType
    {
        INVALID = 0,
        EXPENDABLE,         // 消耗品
        WAR_EXPENDABLE,     // 战场上的消耗品
        EQUIPMENT,          // 普通装备
        EQUIP,              // 武器
        CAR,                // 坐骑
        GEM,                // 宝石
        GIFT,               // 礼包

        MAX,
    }

    /// <summary>
    /// 物品子类型
    /// </summary>
    public enum eItemSubType
    {
        INVALID = 0,

        //-------------------------------------------begin 消耗品-------------------------------------------
        HEAT,                   //热量
        DOUBLEEXP,              //双倍经验卡
        BUGLE,                  //喇叭
        FRIENDEXTEND,           //好友扩充卡
        //end 消耗品

        //-------------------------------------------begin 战场上的消耗品(战场中使用并且在战场中获得，商城中购买不了)
        BATTLE_MEDICINEBOX = 13,//医药箱
        BATTLE_CLIP,            // 弹夹
        //-------------------------------------------end 战场上的消耗品-------------------------------------------

        //-------------------------------------------begin 装备-------------------------------------------
        GLOVE,                  //手套 9
        BOOTHOSE,               //护腿 10
        ARMOR,                  //护甲 11 
        ARMGUARD,               //护手 12
        RING,                   //戒指 13
        NECKLACE,               //项链 14 
        GLASSES,                //眼镜 15
        SHOES,                  //鞋子 16
        FASHION,                //时装 17
        //-------------------------------------------end 装备-------------------------------------------

        //-------------------------------------------begin 武器-------------------------------------------
        RIFLE = 1,              //小米步枪 1
        AK47,                   //AK-47 2
        SNIPE,                  //重型狙击 3 
        ROCKET,                 //火箭筒 4
        SHRAPNEL,               //榴弹枪 5
        KNIFE,                  //菜刀 6
        FIREGUN,                //火焰枪 7
        HEAVYGUN,               //重机枪 8
        //-------------------------------------------end 武器-------------------------------------------

        //-------------------------------------------begin 坐骑-------------------------------------------
        SCHOOL_CAR = 1,         //校车1
        FASHION_CONCEPTION_CAR, //时尚概念 2
        CRAZY_CAR,              //狂野战车3
        //-------------------------------------------end 武器-------------------------------------------

        //-------------------------------------------begin 宝石-------------------------------------------
        GEM_ATTACK,             //攻击宝石 1
        GEM_HP,                 //生命宝石 2
        GEM_DEFENSE,            //防御宝石 3
        GEM_RANGE,              //远视宝石 4
        GEM_CRIT_RATE,          //暴击率宝石 5
        GEM_CRIT_DOUBLE,        //暴击倍数宝石 6
        GEM_ACCURACY,           //精确宝石 7
        GEM_DUCK_RATE,          //闪避宝石 8
        //-------------------------------------------end 宝石-------------------------------------------

        //-------------------------------------------begin 图纸-------------------------------------------
        MATERIAL_METAL,         //钛合金 44
        MATERIAL_NEON_SIGN,     //霓虹革 45
        MATERIAL_SILK,          //冰蚕丝 46
        MATERIAL_STEEL,         //金钢锭 47
        MATERIAL_PEACOCK,       //孔雀翎 48
        MATERIAL_OBSIDIAN,      //黑曜石 49
        MATERIAL_NOCTILUCA,     //夜光石 50
        MATERIAL_WIRE_WOVE,     //金丝线 51
        MATERIAL_VELOURS,       //天鹅绒 52
        //-------------------------------------------end 宝石-------------------------------------------

        MAX,
    }

    /// <summary>
    /// 货币类型
    /// </summary>
    public enum eCurrencyType
    {
        Diamond,    //钻石，点券等需要充值获取
        Gold,       //金币
        Silver,     //银币
    }

    /// <summary>
    /// 物品标记
    /// </summary>
    public enum eItemFlags
    {
        // 无
        NONE = 0x00000000,
        // 此物品已经开始计时
        TIMESTARTED = 0x00000001,
        // 装备时开始计时
        EQUIP_TIMESTART = 0x00000002,
        // 物品已经灵魂绑定
        SOULBOUND = 0x00000004,
        // 装备上就不能被卸载
        CANTALLOWUNEQUIP = 0x00000008,
        // 不能被摧毁(不能被丢弃等)
        CANTDESTROY = 0x00000010,
        // 不能出售
        CANTSELL = 0x00000020,
        // 唯一性物品
        ONLYONE = 0x00000040,
        // 已处理过期的物品
        EXPIRE_DEAL = 0x00000080,
        // 不允许自动使用的物品
        DONT_USE = 0x00000100,
        // 锁定物品
        LOCK = 0x00000200,
    }

    /// <summary>
    /// 物品操作行为定义
    /// </summary>
    public enum eItemAction
	{
		// 未定义
		UNINITED = 0,
		// 载入物品中
		LOADING,
		// 已经载入
		LOADED,
		// 创建	
		CREATE,
		// 销毁
		DESTROY,
		// 使用
		USE,
		// 装备
		EQUIP,
		// 卸下装备
		UNEQUIP,
		// 内部移动
		INNERMOVE,
		// 拆分创建
		SPLIT_CREATE,
		// 合并销毁
		MERGE_DESTROY,
		// 拆分
		SPLIT,
		// debug
		DEBUG,
		// 收取邮件
		TAKE_MAIL,
		// 合成
		COMPOSE,
		// 商店购买
		SHOP_BUY_ITEM,
		// 商店售出
		SHOP_SELL_ITEM,
        // 个人商店刷新
		REFRESH_PERSONAL_SHOP,
		// 替换（如升阶）
		INSTEAD,
		// 商城物品赠送成功
		SHOP_PRESENT,
		// 商城物品索取成功
		SHOP_DEMAND,
		// 更新物品
		UPDATE,
		// 更新物品有效期
		UPDATE_EXPIRETIME,
		// 强化装备
		UPDATE_STRENGTHEN,
		// 镶嵌宝石
		EQUIP_GEM,
		// 卸载宝石
		UNEQUIP_GEM,
		// 更新物件标识
		UPDATE_FLAG,
		// 礼包打开
		OPEN_GIFT,
		//自定义激活码兑换
		CUSTOM_CODE,
		//领取VIP礼包
		GET_VIP_GIFT,
		//战场上捡起
		WAR_PICK_UP,
	}
    /// <summary>
    /// 装备目标类型
    /// </summary>
    public enum eEquipTarget
    {
        INVALID = 0,
        // 玩家
        PLAYER,
        // 宠物
        PET,
    }
}
