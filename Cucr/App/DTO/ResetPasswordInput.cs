using System.ComponentModel.DataAnnotations;

namespace Cucr.CucrSaas.App.DTO {

    /// <summary>
    /// 重置密码
    /// </summary>
    public class ResetPasswordInput {
        /// <summary>
        /// 手机号
        /// </summary>
        /// <value></value>
        [Required]
        public string oldPassword { get; set; }
        /// <summary>
        /// 新密码
        /// </summary>
        /// <value></value>
        [Required]
        public string newPassword { get; set; }

    }

}