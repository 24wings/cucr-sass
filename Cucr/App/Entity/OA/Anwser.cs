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
    /// 问传调查
    /// </summary>
    [Table ("oa_answer")]
    public class Anwser {

        /// <summary>
        /// id
        /// </summary>
        /// <value></value>
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        ///    问传调查关联id
        /// </summary>
        /// <value></value>
        public string OA_QuestionnaireSubjectId { get; set; }
    }

}