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
    /// 技能信息表
    /// </summary>
    [Table ("oa_skillinformation")]
    public class SkillInfomation : BaseEntity {
        /// <summary>
        /// 用户Id
        /// </summary>
        /// <value></value>
        public string userId { get; set; }
        /// <summary>
        /// 技能名称
        /// </summary>
        /// <value></value>
        public string skillName { get; set; }
        /// <summary>
        /// 技能说明
        /// </summary>
        /// <value></value>
        public string explain { get; set; }
        /// <summary>
        /// 熟练程度
        /// </summary>
        /// <value></value>
        public string proficiency { get; set; }

        /// <summary>
        /// 使用年限
        /// </summary>
        /// <value></value>
        public string serviceLlife { get; set; }
    }
}