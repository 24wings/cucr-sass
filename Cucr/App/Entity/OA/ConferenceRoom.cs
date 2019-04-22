using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace Cucr.CucrSaas.App.Entity.OA {
    /// <summary>
    /// 会议室维护
    /// </summary>
    public class ConferenceRoom {
        /// <summary>
        /// ID
        /// </summary>
        /// <value></value>
        [Key]
        public string id { get; set; } = Guid.NewGuid ().ToString ();
        /// <summary>
        /// 公司ID
        /// </summary>
        /// <value></value>
        public string companyId { get; set; }
        /// <summary>
        /// 会议室名字
        /// </summary>
        /// <value></value>
        public string conferenceName { get; set; }
        /// <summary>
        /// 会议室地址
        /// </summary>
        /// <value></value>

        public string conferenceAddress { get; set; }
        /// <summary>
        /// 会议室设施
        /// </summary>
        /// <value></value>

        public string facilities { get; set; }
        /// <summary>
        /// 最大参与人数
        /// </summary>
        /// <value></value>
        public int maxNumber { get; set; }
        /// <summary>
        /// 是否开放
        /// </summary>
        /// <value></value>
        public bool open { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string inputPerson { get; set; }
        /// <summary>
        /// 录入时间
        /// </summary>
        /// <value></value>
        public DateTime? inputTime { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        /// <value></value>
        public int? orderBy { get; set; }
        /// <summary>
        /// 保留字段1
        /// </summary>
        /// <value></value>
        public string reservedSpace1 { get; set; }
        /// <summary>
        /// 保留字段2
        /// </summary>
        /// <value></value>
        public string reservedSpace2 { get; set; }
        /// <summary>
        /// 保留字段3
        /// </summary>
        /// <value></value>
        public string reservedSpace3 { get; set; }
    }
}