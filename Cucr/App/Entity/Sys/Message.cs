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
    /// 发送短信记录表
    /// </summary>
    [Table ("sys_message")]
    public class Message {

        /// <summary>
        /// 主键
        /// </summary>
        /// <value></value>
        [Key]
        public string id { get; set; } = Guid.NewGuid ().ToString ();
        /// <summary>
        /// 发送时间
        /// </summary>
        /// <returns></returns>
        public DateTime createTime = new DateTime ();
        /// <summary>
        /// 验证码
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 是否验证码
        /// </summary>
        /// <value></value>
        public bool isAuthcode { get; set; }
        /// <summary>
        /// 短信内容
        /// </summary>
        /// <value></value>
        public string content { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        /// <value></value>
        public string phone { get; set; }
        /// <summary>
        /// 阿里大鱼流水号,
        /// 可用于获取短信发送的详细信息
        /// </summary>
        /// <value></value>
        public string bizId { get; set; }

    }
}