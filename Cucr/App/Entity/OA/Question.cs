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
    /// 选择题答案表
    /// </summary>
    public class Question : BaseEntity {
        /// <summary>
        /// 题目表ID
        /// </summary>
        /// <value></value>
        public string qa_QuestionnaireSubjectId { get; set; }

        /// <summary>
        /// 答案内容（例：A：1212；B:1212;）
        /// </summary>
        /// <value></value>
        public string context { get; set; }
    }
}