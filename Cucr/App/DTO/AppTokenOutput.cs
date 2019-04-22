using System;
using Cucr.CucrSaas.App.Entity.Sys;

namespace Cucr.CucrSaas.App.DTO {

    /// <summary>
    /// token信息
    /// </summary>
    public class TokenInstance {
        /// <summary>
        /// 设备id
        /// </summary>
        /// <value></value>
        public string mechineId { get; set; }
        /// <summary>
        /// 登陆密码
        /// </summary>
        /// <value></value>
        public string LoginPassword { get; set; }

        /// <summary>
        /// 登录的手机号
        /// </summary>
        /// <value></value>
        public string phone { get; set; }

    }
    /// <summary>
    /// token实体
    /// 前端使用token可以获得token实体信息
    /// </summary>
    public class AppTokenOutput {

        // public TokenInstance tokenInstance { get; set; }

        /// <summary>
        /// 用户信息
        /// </summary>
        /// <value></value>
        public User user { get; set; }

    }
}