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
    /// 公司功能权限表
    /// </summary>
    [Table ("sys_companyfcunctionaddress")]
    public class CompanyFcunctionAddress : BaseEntity {
        /// <summary>
        /// 公司ID(所属公司ID)
        /// </summary>
        /// <value></value>
        public string companyId { get; set; }
        /// <summary>
        /// 功能定义表ID
        /// </summary>
        /// <value></value>
        public string fcunctionAddressId { get; set; }
        /// <summary>
        /// 功能地址(程序相对路径)
        /// </summary>
        /// <value></value>
        public string address { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        /// <value></value>
        public bool enable { get; set; }

    }

}