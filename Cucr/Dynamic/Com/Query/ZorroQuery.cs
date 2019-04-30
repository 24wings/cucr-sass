using System;
using System.Collections;
using System.Collections.Generic;

namespace Cucr.CucrSaas.Dynamic.Com {

    /// <summary>
    /// 动态组件
    /// </summary>
    public class DynamiAttribute : Attribute {
        /// <summary>
        /// 加载组件
        /// </summary>
        /// <value></value>
        public string alias { get; set; }

    }

    /// <summary>
    /// 查询动态组件
    /// </summary>
    public class QueryDynamicAttribute : DynamiAttribute {
        /// <summary>
        /// 标签
        /// </summary>
        /// <value></value>
        public string label { get; set; }
        /// <summary>
        /// 生成查询条件
        /// </summary>
        /// <value></value>
        public List<Filter> filter { get; set; } = new List<Filter> ();
        /// <summary>
        /// 查询条件
        /// </summary>
        /// <value></value>
        public int conditions { get; set; }
    }
    /// <summary>
    /// 查询条件
    /// </summary>
    public enum Condtion {
        Eq = 0b1,
        Grate = 0b11,
        Contains = 0b111
    }

    /// <summary>
    /// zorro query
    /// </summary>
    public class ZorroQueryInputAttribute : Attribute {

    }

    /// <summary>
    /// 查询视图
    /// </summary>
    public class QueryViewAttribute : DynamiAttribute {
        /// <summary>
        /// 别名
        /// </summary>
        /// <value></value>
        public string alias { get; set; } = "zorro-view-query";
        /// <summary>
        /// 查询
        /// </summary>
        /// <value></value>
        public List<QueryDynamicAttribute> queryDynamics { get; set; } = new List<QueryDynamicAttribute> ();
    }

    /// <summary>
    /// 子查询
    /// </summary>
    public class SubQueryPageAttribute : DynamiAttribute {
        /// <summary>
        /// 组件
        /// </summary>
        /// <value></value>
        public string alias { get; set; } = "sub-query-page";
        /// <summary>
        /// 主要查询Type
        /// </summary>
        /// <value></value>
        public Type mainQueryDynamicType { get; set; }
        /// <summary>
        /// type
        /// </summary>
        /// <value></value>
        public QueryViewAttribute mainQueryDynamic { get; set; }
        /// <summary>
        ///  Dynamic | TreeViewDynamic | TableViewDynamic;
        /// </summary>
        /// <value></value>
        public DynamiAttribute mainDynamic { get; set; }
        /// <summary>
        /// 子视图
        /// </summary>
        /// <value></value>
        public DynamiAttribute subDynamic { get; set; }
        // public Dictionary<string, object> param { get; set; }
        // public Array param2 { get; set; }

    }

}