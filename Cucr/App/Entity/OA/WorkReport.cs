using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Cucr.CucrSaas.App.Entity.OA
{

    /// <summary>
    /// 工作报告
    /// </summary>
    [Table("oa_workreport")]
    public class WorkReport
    {
        /// <summary>
        /// 主键
        /// </summary>
        /// <returns></returns>
        [Key]
        public string id { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// 公司id
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
        /// </summary>
        /// <value></value>
        public WorkReportType type { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        /// <value></value>
        public string title { get; set; }
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
        /// 完成时间
        /// </summary>
        /// <value></value>
        public string completedHouse { get; set; }

        /// <summary>
        /// 录入人
        /// </summary>
        public string inputPerson { get; set; }
        /// <summary>
        /// 录入时间
        /// </summary>
        /// <value></value>
        public int? inputTime { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        /// <value></value>
        public string orderBy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string reservedSpace1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string reservedSpace2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string reservedSpace3 { get; set; }
        /// <summary>
        /// 数据创建时间
        /// </summary>
        /// <value></value>
        public DateTime? createTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 附件列表
        /// </summary>
        /// <value></value>
        [NotMapped]
        public List<Enclosure> enclosures { get; set; }

    }

    /// <summary>
    /// 汇报类型（0：日报；1：周报；2：月报；3：年中总结；4：年终总结；5：项目汇报）
    /// </summary>
    public enum WorkReportType
    {
        /// <summary>
        ///日报
        /// </summary>
        Day,
        /// <summary>
        ///周报
        /// </summary>
        Week,
        /// <summary>
        ///月报
        /// </summary>
        Month,
        /// <summary>
        ///年中
        /// </summary>
        SixMonth,
        /// <summary>
        ///年终
        /// </summary>
        Year,
        /// <summary>
        ///项目
        /// </summary>
        Project

    }
}