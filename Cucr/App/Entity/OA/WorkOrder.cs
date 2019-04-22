using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Cucr.CucrSaas.App.Entity.Sys;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace Cucr.CucrSaas.App.Entity.OA {

    /// <summary>
    /// 工单
    /// </summary>
    [Table ("oa_workorder")]
    public class WorkOrder : BaseEntity {

        /// <summary>
        /// 公司Id
        /// </summary>
        /// <value></value>
        public string companyId { get; set; }
        /// <summary>
        /// 项目id
        /// </summary>
        /// <value></value>
        public string projectId { get; set; }
        /// <summary>
        /// 发布人id
        /// </summary>
        /// <value></value>
        public string userId { get; set; }
        /// <summary>
        /// 发布人姓名
        /// </summary>
        /// <value></value>
        public string name { get; set; }
        /// <summary>
        /// 发布标题
        /// </summary>
        /// <value></value>
        public string title { get; set; }
        /// <summary>
        /// 周期(天)
        /// </summary>
        /// <value></value>
        public decimal? cycle { get; set; }
        /// <summary>
        /// 已经使用工时
        /// </summary>
        /// <value></value>
        public decimal? useworkingHours { get; set; }
        /// <summary>
        /// 总工时
        /// </summary>
        /// <value></value>
        public decimal? workingHours { get; set; }
        /// <summary>
        /// 级别
        /// </summary>
        /// <value></value>
        public string level { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        /// <value></value>
        public string projectName { get; set; }
        /// <summary>
        /// 指派人Id
        /// </summary>
        /// <value></value>
        public string assignId { get; set; }
        /// <summary>
        /// 指派人姓名
        /// </summary>
        /// <value></value>
        public string assignName { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        /// <value></value>
        public string enclosure { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        /// <value></value>
        public int? beginTime { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        /// <value></value>
        public int? beoverdueTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        /// <value></value>
        public int? endTime { get; set; }
        /// <summary>
        /// 是否超时
        /// </summary>
        /// <value></value>
        public bool timeout { get; set; }
        /// <summary>
        /// 超时原因
        /// </summary>
        /// <value></value>
        public string timeoutReason { get; set; }
        /// <summary>
        /// 通知对象(用户ID集合)
        /// </summary>
        /// <value></value>
        public string noticePerson { get; set; }
        /// <summary>
        /// 通知对象
        /// </summary>
        /// <value></value>
        public string noticePersonName { get; set; }
        /// <summary>
        /// 工单描述
        /// </summary>
        /// <value></value>
        public string explain { get; set; }
        /// <summary>
        /// 工单状态
        /// 0待分配，1.待执行，2.执行中，3.待确认，4.已完成（完成），5.已取消，6.已超期
        /// </summary>
        /// <value></value>
        public WorkOrderStatus? wctype { get; set; }

        /// <summary>
        /// 取消原因
        /// </summary>
        /// <value></value>
        public string cancelReason { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        /// <value></value>
        [NotMapped]
        public List<Enclosure> images { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        /// <value></value>
        [NotMapped]
        public List<Enclosure> enclosures { get; set; }
        /// <summary>
        ///  user
        /// </summary>
        /// <value></value>
        [NotMapped]
        public User user { get; set; }
        /// <summary>
        /// 消息通知人
        /// </summary>
        /// <value></value>
        [NotMapped]
        public List<User> noticePersons { get; set; }

        /// <summary>
        /// 交付人
        /// </summary>
        /// <value></value>
        [NotMapped]
        public User assign { get; set; }

    }

    /// <summary>
    /// 0待分配，1.待执行，2.执行中，3.待确认，4.已完成（完成），5.已取消，6.已超期
    /// </summary>
    public enum WorkOrderStatus {
        /// <summary>
        ///  待分配
        /// </summary>
        UnSubmiited,
        /// <summary>
        ///  待执行
        /// </summary>
        Wait,
        /// <summary>
        ///  执行中
        /// </summary>

        Process,
        /// <summary>
        ///  待确认
        /// </summary>
        UnComfirm,

        /// <summary>
        /// 已完成
        /// </summary>

        Finish,
        /// <summary>
        ///  已取消
        /// </summary>
        Cancel,
        /// <summary>
        ///  已超期
        /// </summary>
        Fail

    }
}