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
    /// 公司组织架构
    /// </summary>

    [Table ("sys_companyframework")]
    public class CompanyFramework : BaseEntity {
        /// <summary>
        /// 公司ID(所属公司ID)
        /// </summary>
        /// <value></value>
        public string companyId { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        /// <value></value>
        public string department { get; set; }
        /// <summary>
        /// 功能地址(程序相对路径)
        /// </summary>
        /// <value></value>
        public string parentId { get; set; }
        /// <summary>
        /// 组织级别(例：一级部门 001，二级部门001.1，001.2，001.3，三级部门001.1.1，001.1.2)
        /// </summary>
        /// <value></value>
        public string level { get; set; }
        /// <summary>
        /// 部门人数
        /// </summary>
        /// <value></value>
        public int? userNum { get; set; } = 0;
        /// <summary>
        /// 子部门数量
        /// </summary>
        /// <value></value>
        [NotMapped]
        public int? subCompanyFrameworkNum { get; set; } = 0;

    }

}