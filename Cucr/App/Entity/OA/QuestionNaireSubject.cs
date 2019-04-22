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
    /// 问卷调查题目表
    /// </summary>
    public class QuestionSubject : BaseEntity {
        /// <summary>
        /// 问卷调查ID
        /// </summary>
        /// <value></value>
        public string oa_QuestionnaireId { get; set; }
        /// <summary>
        /// 问卷调查类型
        /// </summary>
        /// <value></value>
        public QuestionSubjectType type { get; set; }
        /// <summary>
        /// 问题
        /// </summary>
        /// <value></value>
        public string question { get; set; }
    }
    /// <summary>
    /// 题目类型（0：选择题；1：填空题）
    /// </summary>
    public enum QuestionSubjectType {
        /// <summary>
        /// 选择题
        /// </summary>
        Choose,
        /// <summary>
        /// 填空题
        /// </summary>
        Fill
    }
}