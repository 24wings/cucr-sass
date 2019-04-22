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
    /// 流程步骤执行人表
    /// </summary>
    [Table ("oa_saas_flow_step_exeuser")]
    public class FlowStepExeuser : BaseEntity {
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        public string exeUserId = Guid.NewGuid ().ToString ();
        /// <summary>
        /// 流程执行步骤id
        /// </summary>
        /// <value></value>
        public string exeStepId { get; set; }
        /// <summary>
        /// 执行人
        /// </summary>
        /// <value></value>
        public string userId { get; set; }
        /// <summary>
        /// 执行人名称
        /// </summary>
        /// <value></value>
        public string userName { get; set; }
        /// <summary>
        /// 执行人部门
        /// </summary>
        /// <value></value>
        public string deptId { get; set; }
        /// <summary>
        /// 执行人部门名称
        /// </summary>
        /// <value></value>
        public string deptName { get; set; }
        /// <summary>
        /// 执行人角色
        /// </summary>
        /// <value></value>
        public string roleId { get; set; }
        /// <summary>
        /// 执行人角色名称
        /// </summary>
        /// <value></value>
        public string roleName { get; set; }
        /// <summary>
        /// 执行状态
        /// </summary>
        /// <value></value>
        public ExeState? exeState { get; set; }
        /// <summary>
        /// 执行角色
        /// 1执行者，2抄送接收者
        /// </summary>
        /// <value></value>
        public string flowRole { get; set; }
        /// <summary>
        /// 意见
        /// </summary>
        /// <value></value>
        public string opinion { get; set; }
        /// <summary>
        /// 是否易读
        /// </summary>
        /// <value></value>
        public bool isRead { get; set; }
        /// <summary>
        /// 执行时间
        /// </summary>
        /// <value></value>
        public DateTime exeTime { get; set; }
    }

    /// <summary>
    /// 执行状态 1通过 2驳回 3待审核
    /// </summary>
    public enum ExeState {
        /// <summary>
        /// 通过 
        /// </summary>
        Pass = 1,
        /// <summary>
        /// 拒绝 
        /// </summary>
        Reject,
        /// <summary>
        /// 待审核
        /// </summary>
        WaitApprove
    }
}