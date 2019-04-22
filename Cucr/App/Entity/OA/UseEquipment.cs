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
    [Table ("oa_useequipment")]
    public class UseEquipment : BaseEntity {
        /// <summary>
        /// 用户id
        /// </summary>
        /// <returns></returns>
        public string userId { get; set; }
        /// <summary>
        /// 设备管理表Id
        /// </summary>
        /// <value></value>
        public string deviceManagementID { get; set; }
        /// <summary>
        /// 领取时间
        /// </summary>
        /// <value></value>
        public DateTime leadTime { get; set; }

    }
}