using System;
using System.ComponentModel.DataAnnotations;
using Cucr.CucrSaas.App.Entity.Sys;

namespace Cucr.CucrSaas.App.DTO {

    /// <summary>
    /// 忘记密码
    /// </summary>
    public class AppForgotPasswordInput {

        /// <summary>
        /// 手机号
        /// </summary>
        /// <value></value>
        [Required (ErrorMessage = "手机号必填")]
        public string phone { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        /// <value></value>
        [Required (ErrorMessage = "验证码必填")]
        public string authcode { get; set; }
        /// <summary>
        /// 新密码
        /// </summary>
        /// <value></value>
        [MinLength (6, ErrorMessage = "密码最少6位")]
        [Required (ErrorMessage = "新密码必填")]
        public string newPassword { get; set; }

    }
}