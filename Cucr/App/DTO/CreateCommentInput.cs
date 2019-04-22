using Microsoft.AspNetCore.Http;

namespace Cucr.CucrSaas.App.Entity.OA
{
    /// <summary>
    /// 创建评论
    /// </summary>
    public class CreateWorkReportCommentInput
    {
        /// <summary>
        /// 对应Id
        /// 当工作Id
        /// </summary>
        /// <value></value>
        public string workReportId { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        /// <value></value>
        public string content { get; set; }
        /// <summary>
        /// 如果不是回复则为空,或者不传
        /// 如果是回复传上级评论id
        /// </summary>
        /// <value></value>
        public string parentId { get; set; }
        /// <summary>
        /// 附件Id集合
        /// </summary>
        /// <value></value>
        public string enclusureIds { get; set; } = "";



    }
    /// <summary>
    /// 创建工单评论
    /// </summary>
    public class CreateWorkOrderCommentInput
    {
        /// <summary>
        /// 当工单Id
        /// </summary>
        /// <value></value>
        public string workOrderId { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        /// <value></value>
        public string content { get; set; }
        /// <summary>
        /// 如果不是回复则为空,或者不传
        /// 如果是回复传上级评论id
        /// </summary>
        /// <value></value>
        public string parentId { get; set; }
        /// <summary>
        /// 附件Id集合
        /// </summary>
        /// <value></value>
        public string enclusureIds { get; set; } = "";

    }
    /// <summary>
    /// 创建推送评论输入
    /// </summary>
    /// <value></value>
    public class CreateNoticeCommentInput
    {
        /// <summary>
        /// 公告Id
        /// </summary>
        /// <value></value>
        public string noticeId { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        /// <value></value>
        public string content { get; set; }
        /// <summary>
        /// 如果不是回复则为空,或者不传
        /// 如果是回复传上级评论id
        /// </summary>
        /// <value></value>
        public string parentId { get; set; }
        /// <summary>
        /// 附件Id集合
        /// </summary>
        /// <value></value>
        public string enclusureIds { get; set; } = "";
    }
}