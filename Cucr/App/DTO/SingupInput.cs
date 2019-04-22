namespace Cucr.CucrSaas.App.DTO {

    /// <summary>
    /// 注册输入
    /// </summary>
    public class SignupInput {
        /// <summary>
        /// 手机号
        /// </summary>
        /// <value></value>
        public string phone { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        /// <value></value>
        public string loginPassword { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        /// <value></value>
        public string authcode { get; set; }
    }

}