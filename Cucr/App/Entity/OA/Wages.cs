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
    /// 工资条
    /// </summary>
    [Table ("oa_wages")]
    public class Wages {
        /// <summary>
        /// 主键
        /// </summary>
        /// <returns></returns>
        public string id { get; set; } = Guid.NewGuid ().ToString ();
        /// <summary>
        /// 公司id
        /// </summary>
        /// <value></value>
        public string companyId { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        /// <value></value>
        public string userId { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        /// <value></value>
        public string name { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        /// <value></value>
        public string department { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        /// <value></value>
        public string position { get; set; }
        /// <summary>
        /// 工作天数
        /// </summary>
        /// <value></value>
        public Decimal workDay { get; set; }
        /// <summary>
        /// 基本薪资
        /// </summary>
        /// <value></value>
        public Decimal basicWage { get; set; }
        /// <summary>
        /// 职位薪资
        /// </summary>
        /// <value></value>
        public Decimal positionMoney { get; set; }

        /// <summary>
        /// 加班薪资
        /// </summary>
        /// <value></value>
        public Decimal overtimeMoney { get; set; }
        /// <summary>
        /// 绩效工资标准
        /// </summary>
        /// <value></value>
        public Decimal meritpaystandard { get; set; }
        /// <summary>
        /// 绩效评分
        /// </summary>
        /// <value></value>
        public Decimal meritpayscore { get; set; }
        /// <summary>
        /// 实发绩效工资
        /// </summary>
        /// <value></value>
        public Decimal paymentMeritpay { get; set; }
        /// <summary>
        /// 电脑补贴
        /// </summary>
        /// <value></value>
        public Decimal computersubsidy { get; set; }
        /// <summary>
        /// 其他补发
        /// </summary>
        /// <value></value>
        public string reissueOther { get; set; }
        /// <summary>
        /// 提成
        /// </summary>
        /// <value></value>
        public decimal royalty { get; set; }
        /// <summary>
        /// 应付工资合计
        /// </summary>
        /// <value></value>
        public decimal totalpayablewages { get; set; }
        /// <summary>
        /// 迟到
        /// </summary>
        /// <value></value>
        public decimal late { get; set; }
        /// <summary>
        /// 旷工
        /// </summary>
        /// <value></value>
        public decimal absenteeism { get; set; }
        /// <summary>
        /// 未打卡
        /// </summary>
        /// <value></value>
        public decimal nopunchcard { get; set; }
        /// <summary>
        ///  罚单
        /// </summary>
        /// <value></value>
        public decimal infringementnotice { get; set; }
        /// <summary>
        /// 工会费
        /// </summary>
        /// <value></value>

        public decimal unionfee { get; set; }
        /// <summary>
        /// 社保代缴（个人）
        /// </summary>
        /// <value></value>
        public decimal socialSecurityPayment { get; set; }
        /// <summary>
        /// 公积金代缴（个人）
        /// </summary>
        /// <value></value>
        public decimal providentFundPayment { get; set; }
        /// <summary>
        /// 全勤奖
        /// </summary>
        /// <value></value>
        public decimal fullAttendanceMoney { get; set; }
        /// <summary>
        /// 合计
        /// </summary>
        /// <value></value>
        public decimal total { get; set; }
        /// <summary>
        /// 发放时间
        /// </summary>
        /// <value></value>
        public DateTime grantTime { get; set; }

        /// <summary>
        /// 发放月份
        /// </summary>
        /// <value></value>
        public DateTime grantMonth { get; set; }
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