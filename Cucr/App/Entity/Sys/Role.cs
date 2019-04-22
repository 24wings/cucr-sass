using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Cucr.CucrSaas.App.Entity.OA;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Cucr.CucrSaas.App.Entity.Sys {

    /// <summary>
    /// 项目表
    /// </summary>
    [Table ("sys_role")]
    public class Role : BaseEntity {
        /// <summary>
        /// 公司ID
        /// </summary>
        /// <value></value>
        public string companyId { get; set; }
        /// <summary>
        /// 角色名
        /// </summary>
        /// <value></value>
        public string roleName { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        /// <value></value>
        public string explain { get; set; }
        /// <summary>
        /// 是否超级管理员
        /// </summary>
        /// <value></value>
        public bool superAdministrator { get; set; }
    }
}