using System.ComponentModel.DataAnnotations;

namespace Cucr.CucrSaas.App.DTO {
    /// <summary>
    /// app用户登录实体
    /// </summary>
    public class AppUserOutput {
        /// <summary>
        /// 姓名
        /// </summary>
        /// <value></value>
        public string name { get; set; }
        /// <summary>
        /// 主键
        /// </summary>
        /// <value></value>
        public string id { get; set; }

    }
}