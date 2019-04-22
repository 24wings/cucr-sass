using System;

namespace Cucr.CucrSaas.Common.Util
{
    /// <summary>
    /// 日期工具类
    /// </summary>
    public static class DateUtil
    {
        /// <summary>
        /// 获取当前时间秒数
        /// </summary>
        /// <returns></returns>
        public static int getNowSeconds()
        {
            return (int)DateTime.Now.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds;
        }
    }
}