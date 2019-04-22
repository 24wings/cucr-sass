using Cucr.CucrSaas.App.Entity.OA;
using Cucr.CucrSaas.Common.Util;

namespace Cucr.CucrSaas.App.DTO
{
    /// <summary>
    /// 创建工作报告输入
    /// </summary>
    public class CreateWorkReportInput
    {
        /// <summary>
        /// 汇报类型（0：日报；1：周报；2：月报；3：年中总结；4：年终总结；5：项目汇报）
        /// </summary>
        /// <value></value>
        public WorkReportType wcType { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        /// <value></value>
        public string title { get; set; }
        /// <summary>
        /// 公司Id
        /// </summary>
        /// <value></value>
        public string companyId { get; set; }
        /// <summary>
        /// 项目id
        /// </summary>
        /// <value></value>
        public string projectId { get; set; }
        /// <summary>
        /// 提交人ID
        /// </summary>
        /// <value></value>
        public string subPersonId { get; set; }
        /// <summary>
        /// 工作报告
        /// 汇报类型（0：日报；1：周报；2：月报；3：年中总结；4：年终总结；5：项目汇报）
        /// </summary>
        /// <value></value>
        public WorkReportType type { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        /// <value></value>
        public string content { get; set; }

        // public string enclosure { get; set; }

        /// <summary>
        /// 通知对象ID(用户ID集合)
        /// </summary>
        /// <value></value>

        public string noticePersonIds { get; set; }
        /// <summary>
        /// 抄送人ID(用户Id集合)
        /// </summary>
        /// <value></value>
        public string ccPersonIds { get; set; }
        /// <summary>
        /// 发送时间
        /// </summary>
        /// <value></value>
        public int? subTime { get; set; }
        /// <summary>
        /// 工单明细Id（工单明细ID集合）
        /// </summary>
        /// <value></value>
        public string workorderDetailedId { get; set; }
        /// <summary>
        /// 附件Id列表
        /// </summary>
        /// <value></value>
        public string enclosure { get; set; }





    }
}