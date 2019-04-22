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
    /// 角色分配表
    /// </summary>
    [Table ("sys_roledistribution")]
    public class RoleDistribution {
        /// <summary>
        /// ID
        /// </summary>
        /// <value></value>
        public string id { get; set; } = Guid.NewGuid ().ToString ();
        /// <summary>
        /// 角色
        /// </summary>
        /// <value></value>
        public string roleId { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        /// <value></value>
        public string userId { get; set; }

    }
}