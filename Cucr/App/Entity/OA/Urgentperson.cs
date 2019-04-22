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
    /// 紧急联系人表
    /// </summary>
    [Table ("oa_urgentperson")]
    public class Urgentperson : BaseEntity {

        /// <summary>
        /// 用户ID
        /// </summary>
        /// <value></value>
        public string userId { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        /// <value></value>

        public string name { get; set; }
        /// <summary>
        /// 与本人关系
        /// </summary>
        /// <value></value>
        public string relationship { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        /// <value></value>
        public string phone { get; set; }
    }
}