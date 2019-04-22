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
    /// 设备管理表
    /// </summary>

    [Table ("sys_devicemanagement")]
    public class DeviceManagement : BaseEntity {
        /// <summary>
        /// 设备名称
        /// </summary>
        /// <value></value>
        public string deviceName { get; set; }
        /// <summary>
        /// 设备说明
        /// </summary>
        /// <value></value>
        public string explain { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        /// <value></value>
        public string fzr { get; set; }
    }

}