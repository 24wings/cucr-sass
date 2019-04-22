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
    /// 教育经历表
    /// </summary>
    public class Education : BaseEntity {

        /// <summary>
        /// 用户ID
        /// </summary>
        /// <value></value>
        public string userId { get; set; }
        /// <summary>
        /// 院系
        /// </summary>
        /// <value></value>
        public string courtyard { get; set; }
        /// <summary>
        /// 专业
        /// </summary>
        public string major { get; set; }
        /// <summary>
        /// 学校名称
        /// </summary>
        /// <value></value>
        public string schoolName { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? beginDate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        /// <value></value>
        public DateTime endDate { get; set; }
        /// <summary>
        /// 最高教育
        /// </summary>
        /// <value></value>
        public HeightEducationType heihgtEducation { get; set; }
    }
    /// <summary>
    /// 最高学历(0：小学；1：初中；2：高中；3：大专；4：本科；5：硕士；6：博士；)
    /// </summary>
    public enum HeightEducationType {
        /// <summary>
        /// 小学；
        /// </summary>
        ///
        Primary,
        /// <summary>
        /// 小学；
        /// </summary>
        Junior,

        /// <summary>
        /// 高中
        /// </summary>
        High,
        /// <summary>
        /// 本科
        /// </summary>
        College,
        /// <summary>
        /// 高中
        /// </summary>
        Bachelor,

        /// <summary>
        /// 硕士
        /// </summary>
        Master,
        /// <summary>
        /// 硕士
        /// </summary>
        Doctor
    }

}