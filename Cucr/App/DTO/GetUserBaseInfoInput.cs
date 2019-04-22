using System.ComponentModel.DataAnnotations;

namespace Cucr.CucrSaas.App.DTO {
    /// <summary>
    /// 获取用户基本信息
    /// </summary>
    public class GetUserBaseInfoInput {
        /// <summary>
        /// 用户Id
        /// </summary>
        /// <value></value>
        [Required ()]
        public string userId { get; set; }
    }
}