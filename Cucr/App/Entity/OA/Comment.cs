using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace Cucr.CucrSaas.App.Entity.OA
{
    /// <summary>
    /// 评论表
    /// </summary>
    [Table("oa_comment")]
    public class Comment
    {
        /// <summary>
        /// id
        /// </summary>
        /// <returns></returns>
        public string id { get; set; } = Guid.NewGuid().ToString();
        /// <summary>
        /// 对应主键
        /// </summary>
        /// <value></value>
        public string dyId { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        /// <value></value>
        public string personid { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        /// <value></value>
        public string content { get; set; }
        /// <summary>
        /// 评论时间
        /// </summary>
        /// <value></value>

        public int? commentTime { get; set; }
        /// <summary>
        /// 回复评论Id
        /// </summary>
        /// <value></value>
        public string parentId { get; set; }
        /// <summary>
        /// 附件列表
        /// </summary>
        /// <value></value>
        [NotMapped]
        public List<Enclosure> enclusures { get; set; }
        /// <summary>
        /// 图片列表
        /// </summary>
        /// <value></value>
        [NotMapped]
        public List<Enclosure> images { get; set; }
    }
}