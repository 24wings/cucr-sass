using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Cucr.CucrSaas.App.DataAccess;
using Cucr.CucrSaas.App.DTO;
using Cucr.CucrSaas.App.Entity.OA;
using Cucr.CucrSaas.App.Entity.Sys;
using Cucr.CucrSaas.App.Service;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using JWT;
using JWT.Algorithms;
using JWT.Builder;
using JWT.Serializers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
namespace Cucr.CucrSaas.App.Controllers
{
    /// <summary>
    /// 工单搜索输入
    /// </summary>
    public class WorkOrderSearchInput
    {
        /// <summary>
        /// 0 给我的工单1我指派的gongdan
        /// </summary>
        /// <value></value>
        public int type { get; set; }
        /// <summary>
        /// 分页
        /// </summary>
        /// <value></value>
        public int page { get; set; } = 0;
        /// <summary>
        /// 分页数量
        /// </summary>
        /// <value></value>
        public int pageSize { get; set; } = 10;
        /// <summary>
        ///  wctype
        /// 0待分配，1.待执行，2.执行中，3.待确认，4.已完成（完成），5.已取消，6.已超期
        /// </summary>
        /// <value></value>
        public int status { get; set; } = -1;
    }
    /// <summary>
    /// 
    /// </summary>
    public class WorkOrderQueryInput
    {

        /// <summary>
        /// 关键字
        /// </summary>
        /// <value></value>
        public string keyword { get; set; }
        /// <summary>
        /// 页面
        /// </summary>
        /// <value></value>
        public int page { get; set; } = 0;
        /// <summary>
        /// 数据数量
        /// </summary>
        /// <value></value>
        public int pageSize { get; set; } = 10;
    }
    /// <summary>
    /// App登录注册授权接口
    /// </summary>
    [Route("api/CucrSaas/App/[controller]")]
    [ApiController]

    public class WorkOrderController : ControllerBase
    {

        private ICommonService commonService { get; set; }
        /// <summary>
        /// OA数据访问对象
        /// </summary>
        /// <value></value>
        public OAContext oaContext { get; set; }
        /// <summary>
        /// 系统数据库访问
        /// </summary>
        /// <value></value>
        public SysContext sysContext { get; set; }
        /// <summary>
        /// 用户接口
        /// </summary>
        /// <value></value>
        public IUserService userService { get; set; }
        /// <summary>
        /// 短信验证码
        /// </summary>
        /// <value></value>
        public ISmsService smsService { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_oaContext"></param>
        /// <param name="_sysContext"></param>
        /// <param name="_commonService"></param>
        /// <param name="_userService"></param>
        /// <param name="_smsService"></param>
        public WorkOrderController(OAContext _oaContext,
            SysContext _sysContext,
            ICommonService _commonService,
            IUserService _userService,
            ISmsService _smsService
        )
        {
            this.oaContext = _oaContext;
            this.sysContext = _sysContext;
            this.commonService = _commonService;
            this.userService = _userService;
            this.smsService = _smsService;
        }

        /// <summary>
        /// 列出工作工单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public Rtn<List<WorkOrder>> listWorkOrders([FromForm] WorkOrderSearchInput input)
        {
            if (input.type == 0)
            {
                return this.listWorkOrdersGiveMe(input.page, input.pageSize, (int)input.status);
            }
            else
            {
                return this.listWorkOrderFromMe(input.page, input.pageSize, (int)input.status);
            }

        }

        /// <summary>
        /// 关键字搜索工单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        [HttpPost("[action]")]
        public Rtn<List<WorkOrder>> searchWorkOrders([FromForm] WorkOrderQueryInput input)

        {
            var tokenUser = this.userService.getUserFromAuthcationHeader();
            var workOrders = (from workOrder in this.oaContext.workOrders
                              where (workOrder.userId == tokenUser.id ||
workOrder.assignId == tokenUser.id) &&
workOrder.title.Contains(input.keyword)
                              select workOrder)
                .Skip(input.page * input.pageSize).Take(input.pageSize).ToList();
            return Rtn<List<WorkOrder>>.Success(workOrders);

        }

        /// <summary>
        /// 列出分配给我工单
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public Rtn<List<WorkOrder>> listWorkOrdersGiveMe([FromForm(Name = "page")] int page = 0, [FromForm(Name = "pageSize")] int pageSize = 10, [FromForm(Name = "status")] int status = -1)
        {

            var tokenUser = this.userService.getUserFromAuthcationHeader();

            var workOrders = (from workOrder in this.oaContext.workOrders where workOrder.assignId == tokenUser.id select workOrder).Skip(page * pageSize).Take(pageSize).ToList();
            return Rtn<List<WorkOrder>>.Success(workOrders);
        }

        /// <summary>
        /// 获取我指派的工单
        /// </summary>
        /// <returns></returns>
        // [HttpGet ("[action]")]
        private Rtn<List<WorkOrder>> listWorkOrderFromMe(int page = 0, int pageSize = 10, int status = -1)
        {
            var tokenUser = this.userService.getUserFromAuthcationHeader();
            if (status == -1)
            {
                var workOrders = (from workOrder in this.oaContext.workOrders where workOrder.userId == tokenUser.id select workOrder).Skip(page * pageSize).Take(pageSize).ToList();
                return Rtn<List<WorkOrder>>.Success(workOrders);
            }
            else
            {
                var workOrders = (from workOrder in this.oaContext.workOrders where workOrder.userId == tokenUser.id && (int)workOrder.wctype == status select workOrder)
                .Skip(page * pageSize).Take(pageSize).ToList();
                return Rtn<List<WorkOrder>>.Success(workOrders);
            }

        }

        /// <summary>
        /// 指派工单
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public Rtn<WorkOrder> createWorkOrder([FromForm] CreateWorkOrderInput input)
        {
            var tokenUser = this.userService.getUserFromAuthcationHeader();
            var workOrderType = WorkOrderStatus.Wait;
            if (input.assignId == null || input.assignId == String.Empty)
            {
                workOrderType = WorkOrderStatus.UnSubmiited;
            }

            var newWorkOrder = new WorkOrder
            {
                title = input.title,
                userId = tokenUser.id,
                assignId = input.assignId,
                projectId = input.projectId,
                wctype = workOrderType,
                cycle = input.cycle,
                companyId = tokenUser.companyId,
                useworkingHours = 0,
                timeout = false,
                noticePerson = input.noticePerson,
                name = tokenUser.name,
                beoverdueTime = input.beoverdueTime,
                explain = input.explain,
                enclosure = input.enclosure


            };
            this.oaContext.workOrders.Add(newWorkOrder);
            return Rtn<WorkOrder>.Success(newWorkOrder);
        }



        /// <summary>
        /// 获取工单详情
        /// </summary>
        /// <param name="workkorderId"></param>
        /// <returns></returns>

        [HttpPost("[action]")]
        public Rtn<WorkOrder> getWorkOrderInfo([FromForm(Name = "workOrderId")] string workkorderId)
        {
            var workOrder = this.oaContext.workOrders.Find(workkorderId);
            if (workOrder != null)
            {
                if (workOrder.enclosure != null)
                {
                    var enIds = workOrder.enclosure.Split(";");
                    var enclosures = (from e in this.oaContext.enclosures where enIds.Contains(e.id) select e).ToList();
                    workOrder.enclosures = (from e in workOrder.enclosures
                                            where e.fjType != "image"
                                            select e).ToList();
                    workOrder.images = (from e in workOrder.enclosures
                                        where e.fjType == "image"
                                        select e).ToList();

                }
                workOrder.assign = this.sysContext.users.Find(workOrder.assignId);
                workOrder.user = this.sysContext.users.Find(workOrder.userId);
                if (workOrder.noticePerson != null)
                {
                    var noticePersonIds = workOrder.noticePerson.Split(";");
                    workOrder.noticePersons = (from user in this.sysContext.users where noticePersonIds.Contains(user.id) select user).ToList();
                }
                return Rtn<WorkOrder>.Success(workOrder);
            }
            else
            {
                return Rtn<WorkOrder>.Error("不存在的工单");
            }
        }


        /// <summary>
        /// 创建工单评论
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public Rtn<Comment> createWorkOrderComment([FromForm] CreateWorkOrderCommentInput input)
        {
            var tokenUser = this.userService.getUserFromAuthcationHeader();
            var newComment = new Comment
            {
                id = Guid.NewGuid().ToString(),
                personid = tokenUser.id,
                parentId = input.parentId,
                content = input.content,
                dyId = input.workOrderId
            };
            var enclosureIds = input.enclusureIds.Split(";");
            var enclusures = (from e in this.oaContext.enclosures where enclosureIds.Contains(e.id) select e).ToList();
            foreach (var e in enclusures)
            {
                e.fjId = newComment.id;
            }

            this.oaContext.Add(newComment);
            this.oaContext.SaveChanges();
            return Rtn<Comment>.Success(newComment);
        }

        /// <summary>
        /// 列出工单评论
        /// </summary>
        /// <returns></returns>
        public Rtn<List<Comment>> listWorkOrderComment([FromForm(Name = "workOrderId")] string workOrderId)
        {
            var comments = (from c in this.oaContext.comments where c.dyId == workOrderId select c).ToList();
            foreach (var c in comments)
            {
                var enclusers = (from e in this.oaContext.enclosures where e.fjId == c.id select e).ToList();
                c.enclusures = (from e in enclusers where e.fjType != "image" select e).ToList();
                c.images = (from e in enclusers where e.fjType == "image" select e).ToList();
            }
            return Rtn<List<Comment>>.Success(comments);
        }




    }
}