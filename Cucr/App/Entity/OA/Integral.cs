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
    /// 积分表
    /// </summary>
    [Table ("oa_integral")]
    public class Integral : BaseEntity {

        /// <summary>
        /// 考勤项
        /// </summary>
        /// <value></value>
        public string userId { get; set; }
        /// <summary>
        /// 考勤项
        /// </summary>
        /// <value></value>
        public string attendanceItems { get; set; }

        /// <summary>
        /// 得分
        /// </summary>
        /// <value></value>
        public int? score { get; set; }

    }
}