using System;
using Microsoft.AspNetCore.Http;

namespace Cucr.CucrSaas.Common.DTO
{
    /// <summary>
    /// 文件上传
    /// </summary>
    public class UploadFileInput
    {
        /// <summary>
        ///  文件流
        /// </summary>
        /// <value></value>
        public IFormFile file { get; set; }

        /// <summary>
        /// 文件名字,默认为上传文件
        /// 如上传文件为png,则为 上传文件.png
        /// </summary>
        /// <value></value>
        public string filename { get; set; } = "上传文件";
    }
}