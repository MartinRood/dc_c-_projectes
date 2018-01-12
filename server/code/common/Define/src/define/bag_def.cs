using System;
using System.Collections.Generic;

namespace dc
{
    /// <summary>
    /// 背包
    /// @author hannibal
    /// @time 2018-1-12
    /// </summary>
    public class bag
    {
            public const int MAX_BAG_NUM				    = 4;	    // 背包可拓展最大数量

            public const int MAIN_BAG_CAPACITY_DEFAULT	    = 36;	    // 主背包单页格子数量 6*6
            public const int MAIN_BAG_CAPACITY_MAX	        = 144;	    // 主背包最大格子数量 36*4

            public const int STORAGE_BAG_CAPACITY_DEFAULT	= 9;		// 仓库默认容量
            public const int STORAGE_BAG_CAPACITY_MAX		= 54;		// 仓库最大容量
        
            public const int EQUIP_BAG_CAPACITY_DEFAULT     = 4;		// 装备背包默认容量
            public const int EQUIP_BAG_CAPACITY_MAX         = 10;		// 装备背包最大容量

            public const int WEAPON_BAG_CAPACITY_DEFAULT    = 4;		// 武器背包默认容量
            public const int WEAPON_BAG_CAPACITY_MAX	    = 10;		// 武器背包最大容量

    }
    /// <summary>
    /// 背包类型
    /// </summary>
    public enum eBagType
    {
        Invalid = 0,	    //无效背包索引

        Default,		    // 默认背包(主背包)		
        Store,		        // 仓库					
        Equip,			    // 装备
        Weapon,			    // 武器(枪械)			

        Max
    }
    /// <summary>
    /// 是否可堆叠
    /// </summary>
    public enum eBagPropStackType
	{
		No	= 1, // 不可堆叠
		Yes	= 2, // 可堆叠
	}
    /// <summary>
    /// 背包操作
    /// </summary>
    public enum eBagPropOperation
    {
        Invalid = 0,	// 无效值

        Remove = 1,	    // 丢弃
        Destroy = 2,	// 摧毁
        Use = 3,	    // 使用
        Move = 4,	    // 移动(报告：交互，合并)
        Split = 5,	    // 拆分
        Open = 6,	    // 购买开放格子
        Sell = 7,	    // 出售
        Purchase = 8,   // 回购
        Sort = 9,       // 整理

        Get = 10,	    // 获取

        Max,
    }
    /// <summary>
    /// 操作结果
    /// </summary>
    public enum eBagPropOptResult
    {
        SUCCEED = 0,				    // 操作成功
        NOT_EXIST = 1,				    // 物件不存在
        NO_FREE_POSITION = 2,		    // 背包无位置
        SELL_ERROR = 3,				    // 出售错误
        BUY_BACK_ERROR = 4,			    // 回购错误
        UNKNOWN,					    // 未知错误
        LACK_GOLD_ERROR,			    // 点卷不足
        MATERAIL_LACK_ERROR,		    // 材料缺乏
        BAG_TYPE_ERROR,				    // 背包类型错误
        BAG_HAS_NO_PROP_ERROR,			// 背包没有道具
        BAG_PROP_CAN_NOT_EQUIPED_ERROR,	// 该道具不能装备(不是武器，不能更换)
        LACK_COIN_ERROR,			    // 钱币不足

        HAS_MAX_NUMBER,				    // 已经最大持有数
        BUY_BACK_ELAPSED,			    // 回购列表该物品过期
    }

    /// <summary>
    /// 装备的位置索引
    /// </summary>
    public enum eEquipBagIndex
    {
        Invalid = 0,		// 无效的
        Glove,			    // 手套
        Pants,			    // 裤子
        Clothes,			// 衣服
        Helmet,			    // 头盔
        Belt,			    // 腰带
        Shoe,			    // 鞋子
        Fashion,			// 时装
        Bulletproof_Vest,   // 防弹背心
        Wing,			    // 翅膀

        Max,
    }
    /// <summary>
    /// 武器的位置索引
    /// </summary>
    public enum eWeaponIndex
    {
        Invalid = 0,	    // 无效的
        Trigger,		    // 扳机
        Barrel,			    // 枪管
        Telescope,		    // 瞄准镜
        Charger,		    // 弹夹
        Gunstock,		    // 枪托
        Spring,			    // 弹簧

        Max,
    }
}
