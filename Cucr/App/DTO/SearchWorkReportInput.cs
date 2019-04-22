namespace Cucr.CucrSaas.App.DTO
{
    /// <summary>
    /// 搜索工作报告 
    /// </summary>
    public class SearchWorkReportInput
    {
        /// <summary>
        /// 工作报告类型
        /// </summary>
        /// <value></value>
        public WorkReportObjectType workReportType { get; set; }
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

    /// <summary>
    /// 查询的工作报告类型
    /// /// </summary>
    public enum WorkReportObjectType
    {
        ///<summary>
        ///我提交的
        ///</summary>

        MySubmitted,
        ///<summary>
        ///我接收的
        ///</summary>

        MyRecive,
        ///<summary>
        ///通知我的
        ///</summary>

        MyNotify
    }

}