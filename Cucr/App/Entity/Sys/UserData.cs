using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Cucr.CucrSaas.App.Entity.Sys {

    /// <summary>
    /// 用户数据权限表
    /// </summary>
    [Table ("sys_userdata")]
    public class UserData {
        /// <summary>
        /// 用户Id
        /// </summary>
        /// <value></value>
        public string userId { get; set; }
        /// <summary>
        /// 项目表GUID
        /// </summary>
        /// <value></value>
        public string projectId { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        /// <value></value>
        public bool enable { get; set; }

    }
}