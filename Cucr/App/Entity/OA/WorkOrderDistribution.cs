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
    /// 工单流水表
    /// </summary>
    [Table ("oa_workorderdistribution")]
    public class WorkOrderDistribution : BaseEntity {
        /// <summary>
        /// 任务工单ID
        /// </summary>
        /// <value></value>
        public string workorderId { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        /// <value></value>
        public string userId { get; set; }
        /// <summary>
        /// 完成工时
        /// </summary>
        /// <value></value>
        public string completedHouse { get; set; }
    }

}