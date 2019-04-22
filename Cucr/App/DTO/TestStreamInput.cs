using Microsoft.AspNetCore.Http;

namespace Cucr.CucrSaas.App.DTO
{
    /// <summary>
    /// 测试文件上传
    /// </summary>
    public class TestFileUpload
    {
        /// <summary>
        /// 文件上传体
        /// </summary>
        /// <value></value>
        public IFormFile file { get; set; }

    }
}