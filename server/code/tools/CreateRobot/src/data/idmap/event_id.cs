using System;
using System.Collections.Generic;

namespace dc
{
    /// <summary>
    /// 客户端事件定义
    /// @author hannibal
    /// @time 2016-8-18
    /// </summary>
    public class ClientEventID
    {
        /// <summary>
        /// 切换
        /// </summary>
        public const string SWITCH_PRESSURE = "SWITCH_PRESSURE";
        /// <summary>
        /// 创建完成
        /// </summary>
        public const string CREATE_COMPLETE = "CREATE_COMPLETE";
        /// <summary>
        /// 创建进度
        /// </summary>
        public const string CREATE_PROGRESS = "CREATE_PROGRESS";
    }
}
