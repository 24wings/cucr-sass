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
    /// 组织机构数据权限表
    /// </summary>

    [Table ("sys_companyframeworkdata")]
    public class CompanyFrameworkData : BaseEntity {
        /// <summary>
        /// 组织机构GUID
        /// </summary>
        /// <value></value>
        public string companyFrameworkId { get; set; }
        /// <summary>
        /// 项目表GUID
        /// </summary>
        /// <value></value>
        public string projectId { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        /// <value></value>
        public bool enable { get; set; }

    }

}