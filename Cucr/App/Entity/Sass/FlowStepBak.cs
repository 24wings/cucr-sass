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
    /// 流程步骤备份
    /// </summary>
    [Table ("oa_saas_flow_stepbak")]
    public class FlowStepBak : BaseEntity {
        /// <summary>
        /// 步骤Id
        /// </summary>
        /// <value></value>
        public string stepId { get; set; }

        /// <summary>
        /// 备份流程Id
        /// </summary>
        /// <value></value>
        public string flowBakId { get; set; }
        /// <summary>
        /// 流程id
        /// </summary>
        /// <value></value>
        public string flowId { get; set; }
        /// <summary>
        /// 步骤名称
        /// </summary>
        /// <value></value>
        public string stepName { get; set; }
        /// <summary>
        /// 执行类型
        /// </summary>
        /// <value></value>
        public ExecuteType executeType { get; set; }
        /// <summary>
        /// 执行角色Id
        /// </summary>
        /// <value></value>
        public string executeRoleId { get; set; }
        /// <summary>
        /// 执行人
        /// </summary>
        /// <value></value>
        public string executeUserId { get; set; }
        /// <summary>
        /// 执行部门
        /// </summary>
        /// <value></value>
        public string executeDeptId { get; set; }
        /// <summary>
        /// 抄送角色
        /// </summary>
        /// <value></value>
        public string sendRoleId { get; set; }
        /// <summary>
        /// 抄送人
        /// </summary>
        /// <value></value>
        public string sendUserId { get; set; }
        /// <summary>
        /// 抄送部门
        /// </summary>
        /// <value></value>
        public string sendDeptId { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        /// <value></value>
        public int sort { get; set; }
    }
}