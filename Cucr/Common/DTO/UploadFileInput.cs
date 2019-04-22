using System;
namespace Cucr.CucrSaas.Common.DTO
{
    /// <summary>
    /// 文件上传
    /// </summary>
    public class UploadFileInput
    {
        /// <summary>
        /// base64格式
        /// </summary>
        /// <value></value>
        public string base64 { get; set; }
        /// <summary>
        /// 文件扩展名
        /// 默认 png
        /// </summary>
        /// <value></value>
        public string ext { get; set; } = "png";
        /// <summary>
        /// 文件名字,默认为上传文件
        /// 如上传文件为png,则为 上传文件.png
        /// </summary>
        /// <value></value>
        public string fileName { get; set; } = "上传文件";
    }
}