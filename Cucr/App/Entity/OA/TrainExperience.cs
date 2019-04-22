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
    /// 培训经历表
    /// </summary>
    [Table ("oa_trainexperience")]
    public class TrainExperience : BaseEntity {

        /// <summary>
        /// 用户Id
        /// </summary>
        /// <value></value>
        public string userId { get; set; }
        /// <summary>
        /// 学校名称
        /// </summary>
        /// <value></value>
        public string schoolName { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        /// <value></value>
        public DateTime beginDate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        /// <value></value>
        public DateTime endDate { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        /// <value></value>
        public string content { get; set; }
        /// <summary>
        /// 专业
        /// </summary>
        /// <value></value>
        public string major { get; set; }
    }
}