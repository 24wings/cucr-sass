using System;
using System.ComponentModel.DataAnnotations;
using Cucr.CucrSaas.App.Entity.Sys;

namespace Cucr.CucrSaas.App.DTO
{

    /// <summary>
    /// App注册发送验证码
    /// </summary>
    public class AppSingupInput
    {

        /// <summary>
        /// 手机号
        /// </summary>
        /// <value></value>
        [Required(ErrorMessage = "手机号必填")]
        public string phone { get; set; }

    }
}