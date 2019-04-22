namespace Cucr.CucrSaas.App.DTO
{
    /// <summary>
    /// 列出系统公告
    /// </summary>
    public class ListNoticesInput
    {
        /// <summary>
        /// 页数
        /// </summary>
        /// <value></value>
        public int page { get; set; } = 0;
        /// <summary>
        /// 页面数量
        /// </summary>
        /// <value></value>
        public int pageSize { get; set; } = 10;
    }
    /// <summary>
    /// 关键字搜索公告
    /// </summary>
    public class SearchNoticesInput
    {
        /// <summary>
        /// 关键字
        /// </summary>
        /// <value></value>
        public string keyword { get; set; }
    }
}