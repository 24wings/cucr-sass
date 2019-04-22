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
    /// 公司表
    /// </summary>
    [Table("sys_company")]
    public class Company : BaseEntity
    {

        // [Key]
        // public string id { get; set; } = Guid.NewGuid ().ToString ();
        /// <summary>
        /// 公司名称
        /// </summary>
        /// <value></value>
        public string companyName { get; set; }
        /// <summary>
        /// 公司座机
        /// </summary>
        /// <value></value>
        public string companyTelephone { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        /// <value></value>
        public string mail { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        /// <value></value>

        public string address { get; set; }
        /// <summary>
        /// 间接
        /// </summary>
        /// <value></value>
        public string introduce { get; set; }

        /// <summary>
        /// 企业类型
        /// </summary>
        /// <value></value>
        public string type { get; set; }
        /// <summary>
        /// 网址
        /// </summary>
        /// <value></value>
        public string website { get; set; }
        /// <summary>
        /// 行业
        /// </summary>
        /// <value></value>
        public string industry { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        /// <value></value>
        public string headPerson { get; set; }
        /// <summary>
        /// 负责人电话
        /// </summary>
        /// <value></value>
        public string headPhone { get; set; }
        /// <summary>
        /// 公司精度
        /// </summary>
        /// <value></value>
        public decimal? lat { get; set; }
        /// <summary>
        /// 公司维度
        /// </summary>
        /// <value></value>
        public decimal? lng { get; set; }
        /// <summary>
        /// 距离
        /// </summary>
        /// <value></value>
        public int? distance { get; set; }
    }
}