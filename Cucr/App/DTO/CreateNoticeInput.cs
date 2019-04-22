namespace Cucr.CucrSaas.App.DTO
{
    /// <summary>
    /// 创建公告输入
    /// </summary>
    public class CreateNoticeInput
    {
        /// <summary>
        /// 标题
        /// </summary>
        /// <value></value>
        public string title { get; set; }
        /// <summary>
        /// 推送人
        /// </summary>
        /// <value></value>
        public string noticePerson { get; set; }
        /// <summary>
        /// 推送组织Id集合
        /// </summary>
        /// <value></value>
        public string noticeCompanyFrameworkIds { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        /// <value></value>
        public string content { get; set; }
        /// <summary>
        /// 附件ID集合
        /// </summary>
        /// <value></value>
        public string encluserIds { get; set; } = "";
    }
}