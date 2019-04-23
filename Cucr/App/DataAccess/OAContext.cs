using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Cucr.CucrSaas.App.Entity;
using Cucr.CucrSaas.App.Entity.OA;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Cucr.CucrSaas.App.DataAccess {

    /// <summary>
    /// OA数据访问
    /// </summary>
    public class OAContext : DbContext {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public OAContext (DbContextOptions<OAContext> options) : base (options) { }
        /// <summary>
        /// 问卷调查
        /// </summary>
        public DbSet<Anwser> anwsers { get; set; }
        /// <summary>
        /// 评论表
        /// </summary>
        /// <value></value>
        public DbSet<Comment> comments { get; set; }
        /// <summary>
        /// 工作报告
        /// </summary>
        /// <value></value>
        public DbSet<WorkReport> workreports { get; set; }
        /// <summary>
        /// 出勤记录
        /// </summary>
        /// <value></value>
        public DbSet<Incard> incards { get; set; }

        /// <summary>
        /// 工资条
        /// </summary>
        /// <value></value>
        public DbSet<Wages> wageses { get; set; }

        /// <summary>
        /// 工单
        /// </summary>
        /// <value></value>
        public DbSet<WorkOrder> workOrders { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        /// <value></value>
        public DbSet<Enclosure> enclosures { get; set; }
        /// <summary>
        /// 打卡表
        /// </summary>
        /// <value></value>
        public DbSet<Commute> commutes { get; set; }
        /// <summary>
        /// 打卡规则表
        /// </summary>
        /// <value></value>
        public DbSet<CommuteCopy> commuteCopys { get; set; }
        /// <summary>
        /// 出勤序列号
        /// </summary>
        /// <value></value>
        public DbSet<IncardSerialNumber> incardSerialNumbers { get; set; }

        /// <summary>
        /// 项目
        /// </summary>
        /// <value></value>
        public DbSet<Project> projects { get; set; }
        /// <summary>
        /// 系统公告
        /// </summary>
        /// <value></value>
        public DbSet<Notice> notices { get; set; }
        /// <summary>
        /// 出勤
        /// </summary>
        /// <value></value>
        public DbSet<Outcard> outcards { get; set; }
        /// <summary>
        /// 聊天室
        /// </summary>
        /// <value></value>
        public DbSet<ChatRoom> chatRooms { get; set; }
        /// <summary>
        /// 聊天消息
        /// </summary>
        /// <value></value>
        public DbSet<ChatMsg> chatMsgs { get; set; }
    }

}