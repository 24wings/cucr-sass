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
    /// 角色
    /// </summary>
    [Table ("sys_rolejurisdiction")]
    public class RoleJurisdiction {
        /// <summary>
        /// 角色ID
        /// </summary>
        /// <value></value>
        public string roleId { get; set; }
        /// <summary>
        /// 功能ID或者数据ID
        /// </summary>
        /// <value></value>
        public string fcunctionAddressId { get; set; }
        /// <summary>
        /// 数据类型(1:功能权限，2：数据权限)
        /// </summary>
        /// <value></value>
        public int type { get; set; }
        /// <summary>
        /// 是否启用(0：不启用；1：启用)
        /// </summary>
        /// <value></value>
        public bool enable { get; set; }
        //    inputPerson, inputTime
    }
}