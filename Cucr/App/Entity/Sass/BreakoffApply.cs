using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Cucr.CucrSaas.App.Entity.OA;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace Cucr.CucrSaas.App.Entity.Sass {

    /// <summary>
    /// 调休申请
    /// </summary>
    [Table ("oa_saas_breakoff_apply")]
    public class BreakoffApply : BaseEntity {

        /// <summary>
        /// 流程id
        /// </summary>
        /// <value></value>
        public string flowBakId { get; set; }
        /// <summary>
        /// 流水号
        /// </summary>
        /// <value></value>
        public string code { get; set; }
        /// <summary>
        /// 申请人Id
        /// </summary>
        /// <value></value>
        public string applyUserId { get; set; }
        /// <summary>
        /// 申请人名称
        /// </summary>
        /// <value></value>
        public string applyUserName { get; set; }
        /// <summary>
        /// 申请人部门
        /// </summary>
        /// <value></value>
        public string applyDeptId { get; set; }
        /// <summary>
        /// 申请人部门名称
        /// </summary>
        /// <value></value>
        public string applyDeptName { get; set; }
        /// <summary>
        /// 申请时间
        /// </summary>
        /// <value></value>
        public DateTime applyTime { get; set; }
        /// <summary>
        /// 调休开始时间
        /// </summary>
        /// <value></value>
        public DateTime startTime { get; set; }
        /// <summary>
        /// 调休结束时间
        /// </summary>
        /// <value></value>
        public DateTime endTime { get; set; }
        /// <summary>
        /// 调休天数
        /// </summary>
        /// <value></value>
        public int durationDay { get; set; }
        /// <summary>
        /// 调休小时数
        /// </summary>
        /// <value></value>
        public int durationHour { get; set; }
        /// <summary>
        /// 通知对象
        /// </summary>
        /// <value></value>
        public string noticeUserId { get; set; }
        /// <summary>
        /// 调休说明
        /// </summary>
        /// <value></value>
        public string explain { get; set; }

    }

}