namespace Cucr.CucrSaas.App.DTO {
    /// <summary>
    /// 通过关键字 搜索工作报告 
    /// </summary>
    public class SearchWorkReportByKeyword {
        /// <summary>
        /// 工作报告类型
        /// </summary>
        /// <value></value>
        public string keyword { get; set; } = "";
        /// <summary>
        /// 页面
        /// </summary>
        /// <value></value>
        public int page { get; set; } = 0;
        /// <summary>
        /// 每页数量
        /// </summary>
        /// <value></value>
        public int pageSize { get; set; } = 10;

    }

}