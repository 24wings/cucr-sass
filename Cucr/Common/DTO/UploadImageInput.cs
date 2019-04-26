using System;
using System.Collections.Generic;

namespace Cucr.CucrSaas.Common.DTO
{
    /// <summary>
    /// 图片上传
    /// </summary>
    public class UploadImageInput
    {
        /// <summary>
        /// base64格式
        /// </summary>
        /// <value></value>
        public string base64 { get; set; }

        /// <summary>
        /// 文件名
        /// </summary>
        /// <value></value>
        public string filename { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class UploadImageList
    {
        /// <summary>
        /// 图片列表
        /// </summary>
        /// <value></value>
        public List<UploadImageInput> imageList { get; set; }
    }
}