using System;
using System.Collections.Generic;

namespace dc
{
    public class HttpID
    {
    }
    /// <summary>
    /// 返回码
    /// </summary>
    public enum eResponseCode
    {
        Unknow = -1,//服务器内部错误
        Succeed,    //成功
        Failed,     //失败
    }
}
