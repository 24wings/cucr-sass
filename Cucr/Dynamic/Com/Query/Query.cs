using System;

namespace Cucr.CucrSaas.Dynamic.Com {
    /// <summary>
    /// 过滤条件
    /// </summary>
    public class Filter {
        /// <summary>
        /// 键
        /// </summary>
        /// <value></value>
        public string key { get; set; }
        /// <summary>
        /// 条件
        /// </summary>
        /// <value></value>
        public string condition { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        /// <value></value>
        public object value { get; set; }
    }
}