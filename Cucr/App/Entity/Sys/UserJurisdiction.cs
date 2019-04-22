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
    /// 用户功能权限表
    /// </summary>
    [Table ("sys_userjurisdiction")]
    public class UserJurisdiction : BaseEntity {
        /// <summary>
        /// 用户Id
        /// </summary>
        /// <value></value>
        public string userId { get; set; }
        /// <summary>
        /// 公司功能权限表GUID
        /// </summary>
        /// <value></value>
        public string functionAddressId { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        /// <value></value>
        public bool enable { get; set; }
    }
}