namespace Cucr.CucrSaas.App.DTO {
    /// <summary>
    /// 创建外勤输入
    /// </summary>
    public class CreateOutcardInput {
        /// <summary>
        /// 标题
        /// </summary>
        /// <value></value>
        public string title { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        /// <value></value>
        public string address { get; set; }
        /// <summary>
        /// 通知对象Id集合
        /// </summary>
        /// <value></value>
        public string noticePersonIds { get; set; }
        /// <summary>
        /// 外勤内容
        /// </summary>
        /// <value></value>
        public string content { get; set; }
        /// <summary>
        /// 附件Id集合
        /// </summary>
        /// <value></value>
        public string encluserIds { get; set; } = "";
    }
}