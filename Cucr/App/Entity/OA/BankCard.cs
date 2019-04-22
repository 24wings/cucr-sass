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
    /// 银行卡
    /// </summary>
    [Table ("oa_bankcard")]
    public class BankCard {
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        [Key]
        public string id { get; set; } = Guid.NewGuid ().ToString ();
        /// <summary>
        /// 用户id
        /// </summary>
        /// <value></value>
        public string userId { get; set; }
        /// <summary>
        /// 银行名称
        /// </summary>
        /// <value></value>
        public string bankName { get; set; }
        /// <summary>
        /// 开户行
        /// </summary>
        /// <value></value>
        public string openBankName { get; set; }
        /// <summary>
        /// 卡号
        /// </summary>
        /// <value></value>
        public string no { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        /// <value></value>
        public string name { get; set; }
        /// <summary>
        /// 录入人
        /// </summary>
        /// <value></value>
        public string inputPerson { get; set; }
        /// <summary>
        /// 录入时间
        /// </summary>
        /// <value></value>
        public DateTime inputTime { get; set; }
        /// <summary>
        /// 录入时间
        /// </summary>
        /// <value></value>
        public int orderBy { get; set; }
        /// <summary>
        /// 保留字段1
        /// </summary>
        /// <value></value>
        public string reservedSpace1 { get; set; }
        /// <summary>
        /// 保留字段2
        /// </summary>
        /// <value></value>
        public string reservedSpace2 { get; set; }
        /// <summary>
        /// 保留字段3
        /// </summary>
        /// <value></value>
        public string reservedSpace3 { get; set; }
    }

}