using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Cucr.CucrSaas.App.Entity.OA {

    /// <summary>
    /// 工资条
    /// </summary>
    [Table ("oa_work")]
    public class Work : BaseEntity {
        /// <summary>
        /// 用户Id
        /// </summary>
        /// <value></value>
        public string userId { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        /// <value></value>
        public string companyName { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        /// <value></value>
        public DateTime beginDate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        /// <value></value>
        public DateTime? endDate { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        /// <value></value>
        public string department { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        /// <value></value>
        public string position { get; set; }

    }
}