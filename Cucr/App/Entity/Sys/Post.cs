using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Cucr.CucrSaas.App.Entity.OA;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace Cucr.CucrSaas.App.Entity.Sys
{

    /// <summary>
    /// 岗位表
    /// </summary>
    [Table("sys_post")]
    public class Post : BaseEntity
    {
        /// <summary>
        /// 公司ID 
        /// </summary>
        /// <value></value>
        public string companyId { get; set; }
        /// <summary>
        /// 组织架构Id
        /// </summary>
        /// <value></value>
        public string jobPostId { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        /// <value></value>
        public string position { get; set; }
    }
}