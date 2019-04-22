using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Cucr.CucrSaas.App.Entity.OA;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Cucr.CucrSaas.App.Entity.OA {
    /// <summary>
    /// 流程表备份表
    /// </summary>
    [Table ("oa_saas_flowbak")]
    public class FlowBak : BaseEntity {
        /// <summary>
        /// id
        /// </summary>
        /// <value></value>
        public string flowBakId = Guid.NewGuid ().ToString ();
        /// <summary>
        /// 流程id
        /// </summary>
        /// <value></value>

        public string flowId { get; set; }
        /// <summary>
        /// 流程名称
        /// </summary>
        /// <value></value>
        public string flowName { get; set; }
        /// <summary>
        /// 流程类型
        /// </summary>
        /// <value></value>
        public int flowType { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        /// <value></value>
        public DateTime createTime { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        /// <value></value>
        public string createUserId { get; set; }

    }
}