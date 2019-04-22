using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace Cucr.CucrSaas.App.Entity.OA {

    /// <summary>
    /// 项目汇报
    /// </summary>
    public class ProjectReport : BaseEntity {
        /// <summary>
        /// 公司Id
        /// </summary>
        /// <value></value>
        public string companyId { get; set; }
        /// <summary>
        /// 项目Id
        /// </summary>
        /// <value></value>
        public string projectId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string subPersonId { get; set; }
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
        /// <summary>
        /// 附件地址
        /// </summary>
        /// <value></value>
        public string enclosure { get; set; }
        /// <summary>
        /// 消息推送人集合
        /// </summary>
        public string noticePersonIds { get; set; }
        /// <summary>
        /// 提交时间
        /// </summary>
        /// <value></value>
        public DateTime? subTime { get; set; }
        /// <summary>
        /// 工单明细Id
        /// </summary>
        /// <value></value>
        public string WorkorderDetailedId { get; set; }
        /// <summary>
        /// 已完成工时
        /// </summary>
        /// <value></value>
        public decimal completedHouse { get; set; }
    }
}