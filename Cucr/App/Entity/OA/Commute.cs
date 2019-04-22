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
    /// 打表规则卡
    /// </summary>
    [Table ("oa_commute")]
    public class Commute {
        /// <summary>
        /// Id
        /// </summary>
        /// <value></value>
        public string id { get; set; } = Guid.NewGuid ().ToString ();
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string companyId { get; set; }
        /// <summary>
        /// 上午上班时间
        /// </summary>
        /// <value></value>
        public TimeSpan morningWorkTime { get; set; }
        /// <summary>
        /// 上午下班时间
        /// </summary>
        /// <value></value>
        public TimeSpan? morningGoOffWork { get; set; }
        /// <summary>
        /// 下午上班时间
        /// </summary>
        /// <value></value>
        public TimeSpan? afternoonWorkTime { get; set; }
        /// <summary>
        /// 下午下班时间
        /// </summary>
        /// <value></value>
        public TimeSpan? afternoonGoOffWork { get; set; }
        /// <summary>
        /// 第一次打卡时间
        /// </summary>
        /// <value></value>
        public TimeSpan? beginPunchInterval1 { get; set; }
        /// <summary>
        /// 第一次打卡结束时间
        /// </summary>
        public TimeSpan? endPunchInterval1 { get; set; }
        /// <summary>
        /// 第二次打卡开始时间
        /// </summary>
        public TimeSpan? beginPunchInterval2 { get; set; }
        /// <summary>
        /// 第二次打卡结束时间
        /// </summary>
        /// <value></value>
        public TimeSpan? endPunchInterval2 { set; get; }
        /// <summary>
        /// 第三次打卡时间
        /// </summary>
        /// <value></value>
        public TimeSpan? beginPunchInterval3 { get; set; }
        /// <summary>
        /// 第三次打卡开始结束时间
        /// </summary>
        /// <value></value>
        public TimeSpan? endPunchInterval3 { get; set; }
        /// <summary>
        /// 第四次打卡结束时间
        /// </summary>
        public TimeSpan? beginPunchInterval4 { get; set; }
        /// <summary>
        /// 第四次打卡开始结束时间
        /// </summary>
        /// <value></value>
        public TimeSpan? endPunchInterval4 { get; set; }
        /// <summary>
        /// 今日应打卡次数(2次或者4次)
        /// </summary>
        public int putCardNumber { get; set; } = 2;
        /// <summary>
        /// 制定人
        /// </summary>
        public string enactingPerson { get; set; }
        /// <summary>
        /// 开始执行日期
        /// </summary>
        public string beginImplementTime { get; set; }
        /// <summary>
        /// 结束执行日期
        /// </summary>
        /// <value></value>
        public string endImplementTime { get; set; }
        /// <summary>
        /// 录入人
        /// </summary>
        public String inputPerson { get; set; }
        /// <summary>
        /// 录入时间
        /// </summary>
        /// <value></value>
        public TimeSpan? inputTime { get; set; }
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