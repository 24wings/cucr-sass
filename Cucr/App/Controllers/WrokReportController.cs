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
using Cucr.CucrSaas.Common.Util;
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
    /// App登录注册授权接口
    /// </summary>
    [Route("api/CucrSaas/App/[controller]")]
    [ApiController]

    // [Authorize]
    public class WorkReportController : ControllerBase
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
        /// 
        /// </summary>
        /// <param name="_oaContext"></param>
        /// <param name="_sysContext"></param>
        /// <param name="_commonService"></param>
        /// <param name="_userService"></param>
        public WorkReportController(OAContext _oaContext,
            SysContext _sysContext,
            ICommonService _commonService, IUserService _userService)
        {
            this.oaContext = _oaContext;
            this.sysContext = _sysContext;
            this.commonService = _commonService;
            this.userService = _userService;
        }

        /// <summary>
        /// 搜索OA工作报告
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]

        public Rtn<System.Collections.IEnumerable> searchWorkReport([FromForm] SearchWorkReportInput input)
        {
            var options = new DataSourceLoadOptions();
            var tokenUser = this.userService.getUserFromAuthcationHeader();
            options.Skip = input.pageSize * input.page;
            options.Take = input.pageSize;
            if (input.workReportType == Cucr.CucrSaas.App.DTO.WorkReportObjectType.MySubmitted)
            {
                var query = (from workreport in this.oaContext.workreports where workreport.subPersonId == tokenUser.id select workreport);
                var data = DataSourceLoader.Load(query, options).data;
                return Rtn<System.Collections.IEnumerable>.Success(data);

            }
            else
            if (input.workReportType == Cucr.CucrSaas.App.DTO.WorkReportObjectType.MyRecive)
            {
                var query = (from workreport in this.oaContext.workreports where workreport.ccPersonIds == tokenUser.id select workreport);
                var data = DataSourceLoader.Load(query, options).data;
                return Rtn<System.Collections.IEnumerable>.Success(data);

            }
            else
            {
                var query = (from workreport in this.oaContext.workreports where ("," + workreport.noticePersonIds + ",").Contains("," + tokenUser.id + ",") select workreport);
                var data = DataSourceLoader.Load(query, options).data;
                return Rtn<System.Collections.IEnumerable>.Success(data);
            }
        }
        /// <summary>
        /// 根据关键字搜索工作报告
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        [HttpPost("[action]")]
        public CommonRtn searchWorkReportByKeyword([FromForm] SearchWorkReportByKeyword input)
        {
            var tokenUser = this.userService.getUserFromAuthcationHeader();
            var query = (from workreport in this.oaContext.workreports
                         where workreport.title.Contains(input.keyword) && (
(workreport.subPersonId == tokenUser.id) ||
(workreport.inputPerson == tokenUser.id) ||
("," + workreport.ccPersonIds + ",").Contains("," + tokenUser.id + ","))

                         select workreport);
            var options = new DataSourceLoadOptions();
            options.Skip = input.page * input.pageSize;
            options.Take = input.pageSize;
            var data = DataSourceLoader.Load(query, options).data;
            return CommonRtn.Success(new Dictionary<string, object> { { "data", data } });
        }

        /// <summary>
        /// 
        /// 获取报告详情
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public CommonRtn getWorkReportInfo([FromQuery] GetWorkReportInput input)
        {
            var token = this.commonService.getAuthenticationHeader();
            var appUser = this.userService.decodeToken(token);
            if (appUser.user.mechineId == input.mechineId)
            {
                var workReport = this.oaContext.workreports.Find(input.workReportId);
                return new CommonRtn { success = true, resData = new Dictionary<string, object> { { "data", workReport } } };
            }
            else
            {
                return new CommonRtn { success = false, message = "设备不一致" };
            }

        }

        /// <summary>
        /// 添加工作报告
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public Rtn<WorkReport> addOaWorkReportInfo([FromForm] CreateWorkReportInput input)
        {
            var tokenUser = this.userService.getUserFromAuthcationHeader();
            var newWorkreport = new WorkReport
            {
                type = input.type,
                title = input.title,
                subTime = DateUtil.getNowSeconds(),
                subPersonId = tokenUser.id,
                noticePersonIds = input.noticePersonIds,
                workorderDetailedId = input.workorderDetailedId,
                content = input.content,
                ccPersonIds = input.ccPersonIds
            };
            if (input.enclosure != null)
            {
                var enclosures = input.enclosure.Split(";");
                foreach (var enclosureId in enclosures)
                {
                    var enclusure = this.oaContext.enclosures.Find(enclosureId);
                    if (enclusure != null)
                    {
                        enclusure.fjId = newWorkreport.id;
                    }
                }
                this.oaContext.SaveChanges();
            }


            this.oaContext.workreports.Add(newWorkreport);
            this.oaContext.SaveChanges();
            return Rtn<WorkReport>.Success(newWorkreport);
        }

        /// <summary>
        /// 删除工作报告
        /// </summary>
        /// <returns></returns>
        [HttpDelete("[action]")]
        public CommonRtn deleteWorkReportInfo(string workReportId)
        {
            var token = this.commonService.getAuthenticationHeader();
            var tokenInstance = this.userService.decodeToken(token);
            if (tokenInstance?.user.id != null)
            {

                var workReport = this.oaContext.workreports.Find(workReportId);
                if (workReport != null)
                {
                    return new CommonRtn
                    {
                        success = true,
                        message = "",
                        resData = new Dictionary<string, object> { { "data", workReport } }
                    };

                }
                else
                {
                    return new CommonRtn { success = false, message = "工作报告不存在" };
                }

            }
            else
            {
                return new CommonRtn { success = false, message = "请先登录" };
            }

        }

        /// <summary>
        /// 获取工作报告评论
        /// </summary>
        /// <param name="workReportId"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public Rtn<List<Comment>> getWorkreportComments([FromForm(Name = "workReportId")] string workReportId)
        {
            var tokenUser = this.userService.getUserFromAuthcationHeader();
            var comments = (from c in this.oaContext.comments where c.dyId == workReportId select c).ToList();
            foreach (var c in comments)
            {
                var enclusers = (from e in this.oaContext.enclosures where e.fjId == c.id select e).ToList();
                c.enclusures = (from e in enclusers where e.fjType != "image" select e).ToList();
                c.images = (from e in enclusers where e.fjType == "image" select e).ToList();
            }
            return Rtn<List<Comment>>.Success(comments);
        }


        /// <summary>
        /// 创建工作报告评论
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public Rtn<Comment> createWorkreportComment([FromForm] CreateWorkReportCommentInput input)
        {

            var tokenUser = this.userService.getUserFromAuthcationHeader();
            var newComment = new Comment
            {
                id = Guid.NewGuid().ToString(),
                personid = tokenUser.id,
                parentId = input.parentId,
                content = input.content,
                dyId = input.workReportId
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

    }
}