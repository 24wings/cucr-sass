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

    [Table ("sys_functionaddress")]
    public class FunctionAddress : BaseEntity {
        /// <summary>
        /// 功能名称
        /// </summary>
        /// <value></value>
        public string functionName { get; set; }
        /// <summary>
        /// 所属模块
        /// </summary>
        /// <value></value>
        public string module { get; set; }
        /// <summary>
        /// 功能地址(程序相对路径)
        /// </summary>
        /// <value></value>
        public string address { get; set; }
    }

}