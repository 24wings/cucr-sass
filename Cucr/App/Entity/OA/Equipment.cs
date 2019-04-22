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
    /// 附件
    /// </summary>
    [Table ("oa_equipment")]
    public class Equipment {
        /// <summary>
        /// 主键
        /// </summary>
        /// <returns></returns>
        public string id = Guid.NewGuid ().ToString ();
        /// <summary>
        /// 附件ID
        /// </summary>
        /// <value></value>
        public string fjId { get; set; }
        /// <summary>
        /// 附件名字
        /// </summary>
        /// <value></value>
        public string fjName { get; set; }
        /// <summary>
        /// 附件地址
        /// </summary>
        /// <value></value>
        public string fjAddress { get; set; }

        /// <summary>
        /// 附件类型
        /// </summary>
        /// <value></value>
        public string fjType { get; set; }

        /// <summary>
        /// 附件对应业务类型
        /// </summary>
        /// <value></value>
        public string businessname { get; set; }
    }
}