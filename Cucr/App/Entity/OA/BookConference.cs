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
    /// 订阅会议
    /// </summary>
    public class BookConference {
        /// <summary>
        /// ID
        /// </summary>
        /// <value></value>
        [Key]
        public string id { get; set; }
        /// <summary>
        /// 公司ID
        /// </summary>
        /// <value></value>
        public string companyId { get; set; }
        /// <summary>
        /// 订阅房间Id
        /// </summary>
        /// <value></value>
        public string conferenceRoomId { get; set; }
        /// <summary>
        /// 订阅会议名称
        /// </summary>
        /// <value></value>
        public string conferenceRoomName { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        /// <value></value>
        public DateTime date { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        /// <value></value>
        public DateTime beginTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        /// <value></value>
        public DateTime endTime { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        /// <value></value>
        public string title { get; set; }
        /// <summary>
        /// 所属项目
        /// </summary>
        /// <value></value>
        public string project { get; set; }
        /// <summary>
        /// 会议内容
        /// </summary>
        /// <value></value>
        public string content { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        /// <value></value>
        public string department { get; set; }
        /// <summary>
        /// 发起人Id
        /// </summary>
        /// <value></value>
        public string fqrId { get; set; }
        /// <summary>
        /// 参与人
        /// </summary>
        /// <value></value>
        public string userIds { get; set; }
        /// <summary>
        /// 参与人姓名
        /// </summary>
        /// <value></value>
        public string userNames { get; set; }
        /// <summary>
        /// 参与人头像集合
        /// </summary>
        /// <value></value>
        public string headPortrait { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        /// <value></value>
        public string enclosure { get; set; }
        /// <summary>
        /// 通知对象（用户id集合）
        /// </summary>
        /// <value></value>
        public string noticePerson { get; set; }
        /// <summary>
        /// 提交人
        /// </summary>
        /// <value></value>
        public string subPerson { get; set; }
        /// <summary>
        /// 是否推送(0：不推送；1：推送；)
        /// </summary>
        /// <value></value>
        public bool push { get; set; }
        /// <summary>
        /// 录入人
        /// </summary>
        /// <value></value>
        public string inputPerson { get; set; }
        /// <summary>
        /// 录入时间
        /// </summary>
        /// <value></value>
        public DateTime inputTime { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        /// <value></value>
        public int orderBy { get; set; }
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