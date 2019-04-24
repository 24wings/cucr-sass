using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Cucr.CucrSaas.App.Entity.Sys;
using Cucr.CucrSaas.Common.Util;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Cucr.CucrSaas.App.Entity.OA
{
    /// <summary>
    /// 消息
    /// </summary>
    [Table("oa_notice")]
    public class Notice
    {
        /// <summary>
        /// 主键
        /// </summary>
        /// <returns></returns>
        [Key]
        public string id { get; set; } = Guid.NewGuid().ToString();
        /// <summary>
        /// 公司ID
        /// </summary>
        /// <value></value>
        public string companyId { get; set; }
        /// <summary>
        /// 发布人Id
        /// </summary>
        /// <value></value>
        public string PersonId { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        /// <value></value>
        public string title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        /// <value></value>
        public string content { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        /// <value></value>
        public int? type { get; set; }
        /// <summary>
        /// 通知人(用户GUID集合)
        /// </summary>
        /// <value></value>
        public string noticePerson { get; set; }
        /// <summary>
        /// 推送人姓名
        /// </summary>
        /// <value></value>
        public string noticePersonName { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        /// <value></value>
        public int? datetime { get; set; } = DateUtil.getNowSeconds();
        /// <summary>
        /// 是否推送(0:不推送；1：推送)
        /// </summary>
        /// <value></value>
        public bool? push { get; set; }
        /// <summary>
        /// 录入时间
        /// </summary>
        /// <value></value>
        public int? inputTime { get; set; } = DateUtil.getNowSeconds();
        /// <summary>
        /// 排序
        /// </summary>
        /// <value></value>
        public int? orderBy { get; set; }
        /// <summary>
        /// 组织架构Id集合
        /// </summary>
        /// <value></value>
        public string noticeCompanyFrameworkIds { get; set; }

        /// <summary>
        /// 附件列表
        /// </summary>
        /// <value></value>
        [NotMapped]
        public List<Enclosure> enclusures { get; set; } = new List<Enclosure>();
        /// <summary>
        /// 图片列表
        /// </summary>
        /// <value></value>
        [NotMapped]
        public List<Enclosure> images { get; set; } = new List<Enclosure>();
        /// <summary>
        /// 用户
        /// </summary>
        /// <value></value>
        [NotMapped]
        public User user { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        /// <value></value>
        public DateTime? inputDateTime { get; set; }
        /// <summary>
        /// 重设时间
        /// </summary>
        /// <returns></returns>
        public DateTime resetTime()
        {
            var zeroTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);

            var dateTime = zeroTime.AddSeconds((double)this.inputTime);
            this.inputDateTime = dateTime;
            return dateTime;
        }

    }
}