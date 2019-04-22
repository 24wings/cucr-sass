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
    ///流程步骤执行表
    /// </summary>
    [Table ("oa_saas_flow_exe_step")]
    public class FlowExeStep : BaseEntity {
        /// <summary>
        /// ID
        /// </summary>
        /// <value></value>
        public string exeStepId { get; set; }
        /// <summary>
        /// 备份流程id
        /// </summary>
        public string flowBakId { get; set; }
        /// <summary>
        /// 步骤名称
        /// </summary>
        /// <value></value>
        public string stepName { get; set; }
        /// <summary>
        /// 执行状态
        /// </summary>
        /// <value></value>
        public ExecuteState executeState { get; set; }

        /// <summary>
        /// 执行类型
        /// </summary>
        /// <value></value>
        public ExecuteType executeType { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        /// <value></value>
        public int sort { get; set; }

    }
    /// <summary>
    /// 执行状态1通过,2驳回,3待审核
    /// </summary>
    public enum ExecuteState {
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

    /// <summary>
    /// 执行类型1并签 2会签
    /// </summary>
    public enum ExecuteType {
        /// <summary>
        /// 并签
        /// </summary>
        AndSign = 1,
        /// <summary>
        /// 会签
        /// </summary>
        Sign
    }
}