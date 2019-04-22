using System.ComponentModel.DataAnnotations;

namespace Cucr.CucrSaas.App.DTO {
    /// <summary>
    /// app用户登录实体
    /// </summary>
    public class AppUserLoginInput {
        /// <summary>
        /// 用户手机号
        /// </summary>
        /// <value></value>
        [Required]
        public string phone { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        /// <value></value>
        public string loginPassword { get; set; }
        /// <summary>
        /// 登录的设备Id
        /// </summary>
        /// <value></value>
        public string mechineId { get; set; }

    }
}