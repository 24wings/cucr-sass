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
    /// 出勤表,出差表
    /// </summary>
    public class Outcard {
        /// <summary>
        /// id
        /// </summary>
        /// <value></value>
        /// [Key]
        public string id { get; set; } = Guid.NewGuid ().ToString ();
        /// <summary>
        /// 公司Id
        /// </summary>
        /// <value></value>
        public string companyId { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        /// <value></value>
        public string userId { get; set; }
        /// <summary>
        /// 出勤类型
        /// </summary>
        /// <value></value>
        public KqType kqType { get; set; }
        /// <summary>
        /// 打卡类型
        /// </summary>
        /// <value></value>
        public CardType cardType { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        /// <value></value>
        public string title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string content { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        /// <value></value>
        public string enclosure { get; set; }
        /// <summary>
        /// 客户
        /// </summary>
        /// <value></value>
        public string customer { get; set; }
        /// <summary>
        /// 区域
        /// </summary>
        /// <value></value>
        public string region { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        /// <value></value>
        public string address { get; set; }
        /// <summary>
        /// 打卡时间
        /// </summary>
        /// <value></value>
        public int? time { get; set; }
        /// <summary>
        ///  图片
        /// </summary>
        /// <value></value>
        public string imgUrl { get; set; }
        /// <summary>
        /// 通知对象ID集合
        /// </summary>
        /// <value></value>
        public string noticePerson { get; set; }
        /// <summary>
        /// 抄送人ID集合
        /// </summary>
        /// <value></value>
        public string ccPerson { get; set; }
        /// <summary>
        /// 流水号
        /// </summary>
        /// <value></value>
        public string serialNumber { get; set; }
        /// <summary>
        /// 录入人
        /// </summary>
        /// <value></value>
        public int inputPerson { get; set; }
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
    }

    /// <summary>
    /// 考勤类型(0：外勤打卡；1：出差打卡)
    /// </summary>

    public enum KqType {
        /// <summary>
        /// 外勤打卡
        /// </summary>
        Field,
        /// <summary>
        /// 出差打卡
        /// </summary>
        Trip
    }

    /// <summary>
    /// 打卡类型(0：签入；1：签出)
    /// </summary>
    public enum CardType {
        /// <summary>
        /// 签入
        /// </summary>
        CheckIn,
        /// <summary>
        /// 签出
        /// </summary>
        Checkout
    }

}