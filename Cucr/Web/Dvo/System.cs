using System;
using System.Collections;
using Cucr.CucrSaas.Dynamic.Com;

namespace Cucr.CucrSaas.Web.Dvo {

    /// <summary>
    /// 系统选择参数查询
    /// </summary>
    [QueryView]
    public class SystemSelectQueryView {
        /// <summary>
        /// 下拉选择
        /// </summary>
        /// <value></value>
        [QueryDynamic (label = "选择参数类型", alias = "zorro-query-select", conditions = (int) Condtion.Eq)]
        public string selectParamType { get; set; }
        /// <summary>
        /// 查询参数
        /// </summary>
        /// <value></value>
        [QueryDynamic (label = "关键字搜索", alias = "zorro-query-input", conditions = (int) Condtion.Contains)]
        public string name { get; set; }
    }
    /// <summary>
    /// 系统选择项
    /// </summary>
    [SubQueryPage (mainQueryDynamicType = typeof (SystemSelectQueryView))]

    public class SystemSelectPage {

    }

}