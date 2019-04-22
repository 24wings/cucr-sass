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
    /// 设备领取表
    /// </summary>
    [Table ("oa_usercontract")]
    public class UserContract : BaseEntity {
        /// <summary>
        /// 员工ID
        /// </summary>
        /// <value></value>
        public string userId { get; set; }
        /// <summary>
        /// 合同编号
        /// </summary>
        /// <value></value>

        public string no { get; set; }
        /// <summary>
        /// 合同开始时间
        /// </summary>
        /// <value></value>

        public DateTime beginTime { get; set; }
        /// <summary>
        /// 合同结束时间
        /// </summary>
        /// <value></value>
        public DateTime endTime { get; set; }
        /// <summary>
        /// 合同附件
        /// </summary>
        /// <value></value>
        public string enclosure { get; set; }
    }
}