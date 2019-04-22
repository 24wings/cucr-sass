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
    /// 问卷调查表
    /// </summary>
    public class QuestionNaire : BaseEntity {
        /// <summary>
        /// 所属公司id
        /// </summary>
        public string companyId { get; set; }
        /// <summary>
        /// 发布人id
        /// </summary>
        /// <value></value>

        public string userId { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        /// <value></value>
        public string title { get; set; }
        /// <summary>
        /// 流水号
        /// </summary>
        /// <value></value>
        public string serialNumber { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        /// <value></value>
        public string department { get; set; }
        /// <summary>
        /// 问卷开始时间
        /// </summary>
        /// <value></value>
        public DateTime beginTime { get; set; }
        /// <summary>
        /// 问卷结束时间
        /// </summary>
        /// <value></value>
        public DateTime endTime { get; set; }
    }
}