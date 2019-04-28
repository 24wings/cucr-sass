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
    /// App登录注册授权接口
    /// </summary>
    [Route("api/CucrSaas/App/[controller]")]
    [ApiController]

    public class NoticeController : ControllerBase
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
        public NoticeController(OAContext _oaContext,
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
        /// 公告详情
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public Rtn<Notice> noticeInfo([FromForm(Name = "noticeId")]string noticeId)
        {

            var notice = this.oaContext.notices.Find(noticeId);
            if (notice != null)
            {
                notice.user = this.sysContext.users.Find(notice.PersonId);
                if (notice.noticePerson != null)
                {
                    var noticePersonStrArray = notice.noticePerson.Split(";").ToArray();
                    notice.noticePersonList = (from u in this.sysContext.users where noticePersonStrArray.Contains(u.id) select u).ToList();
                }
                if (notice.noticeCompanyFrameworkIds != null)
                {
                    var noticeCompanyFrameworkIdArr = notice.noticeCompanyFrameworkIds.Split(";").ToArray();
                    notice.noticeCompanyFrameworkList = (from c in this.sysContext.companyFrameworks where noticeCompanyFrameworkIdArr.Contains(c.id) select c).ToList();
                }

                var enclusures = (from e in this.oaContext.enclosures where e.fjId == notice.id select e).ToList();
                notice.imageList = (from e in enclusures where e.fjType == "image" select e).ToList();
                notice.enclusureList = (from e in enclusures where e.fjType != "image" select e).ToList();
                return Rtn<Notice>.Success(notice);
            }
            else
            {
                return Rtn<Notice>.Error("公告不存在");
            }



        }
        /// <summary>
        /// 列出能够看的公告
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public Rtn<List<Notice>> listNotices([FromForm] ListNoticesInput input)
        {
            var tokenUser = this.userService.getUserFromAuthcationHeader();
            var notices = this.getUserCanShowNotice(tokenUser);
            notices = (from n in notices

                       select new Notice
                       {
                           id = n.id,
                           title = n.title,
                           noticePerson = n.noticePerson,
                           noticePersonName = n.noticePersonName,
                           user = (from u in this.sysContext.users where u.id == n.PersonId select u).FirstOrDefault(),
                           inputTime = n.inputTime,
                           type = n.type,
                           datetime = n.datetime,
                       }).Skip(input.page * input.pageSize).Take(input.pageSize).ToList();
            foreach (var n in notices)
            {
                n.resetTime();
            }

            return Rtn<List<Notice>>.Success(notices);
        }
        /// <summary>
        /// 搜索推送消息
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public Rtn<List<Notice>> searchNotices([FromForm] SearchNoticesInput input)
        {
            var tokenUser = this.userService.getUserFromAuthcationHeader();
            var notices = this.getUserCanShowNotice(tokenUser);
            notices = (from n in notices
                       where n.title.Contains(input.keyword)
                       select new Notice
                       {
                           id = n.id,
                           title = n.title,
                           noticePerson = n.noticePerson,
                           noticePersonName = n.noticePersonName,
                           user = (from u in this.sysContext.users where u.id == n.PersonId select u).FirstOrDefault(),
                           inputTime = n.inputTime,
                           type = n.type,
                           datetime = n.datetime,
                       }).Skip(input.page * input.pageSize).Take(input.pageSize).ToList();
            foreach (var n in notices)
            {
                n.resetTime();
            }
            return Rtn<List<Notice>>.Success(notices);
        }

        /// <summary>
        /// 获取用户可以查看的推送消息
        /// </summary>
        /// <param name="tokenUser"></param>
        /// <returns></returns>
        private List<Notice> getUserCanShowNotice(User tokenUser)
        {

            var companyFrameworkNotices = (from notice in this.oaContext.notices where notice.noticeCompanyFrameworkIds.Contains(tokenUser.companyFrameworkId) select notice).ToList();
            var notices = (from notice in this.oaContext.notices where notice.noticePerson.Contains(tokenUser.id) || notice.PersonId == tokenUser.id select notice).ToList();
            companyFrameworkNotices.AddRange(notices);
            var ids = (from n in companyFrameworkNotices select n.id).ToArray().Distinct();
            return (from n in notices where ids.Contains(n.id) orderby n.inputTime descending select n).ToList();
        }

        /// <summary>
        /// 创建公告
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public Rtn<Notice> createNotice([FromForm] CreateNoticeInput input)
        {

            var tokenUser = this.userService.getUserFromAuthcationHeader();

            var newNotice = new Notice
            {
                id = Guid.NewGuid().ToString(),
                noticePerson = input.noticePerson,
                noticeCompanyFrameworkIds = input.noticeCompanyFrameworkIds,
                content = input.content
            };
            var enclosureIds = input.encluserIds.Split(";");
            var enclosures = (from e in this.oaContext.enclosures where enclosureIds.Contains(e.id) select e).ToList();
            foreach (var e in enclosures)
            {
                e.fjId = newNotice.id;
            }
            this.oaContext.Add(newNotice);
            this.oaContext.SaveChanges();

            return Rtn<Notice>.Success(newNotice);

        }

        /// <summary>
        /// 创建工单评论
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public Rtn<Comment> createNoticeComment([FromForm] CreateNoticeCommentInput input)
        {
            var tokenUser = this.userService.getUserFromAuthcationHeader();
            var newComment = new Comment
            {
                id = Guid.NewGuid().ToString(),
                personid = tokenUser.id,
                parentId = input.parentId,
                content = input.content,
                dyId = input.noticeId
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
        /// 列出公告评论
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public Rtn<List<Comment>> listNoticeComment([FromForm(Name = "noticeId")] string noticeId, [FromForm(Name = "page")] int page = 0, [FromForm(Name = "pageSize")] int pageSize = 10)
        {
            var comments = (from c in this.oaContext.comments where c.dyId == noticeId select c).ToList();
            foreach (var c in comments)
            {
                var enclusers = (from e in this.oaContext.enclosures where e.fjId == c.id select e).ToList();
                c.enclusures = (from e in enclusers
                                where e.fjType != "image"
                                select e).ToList();
                c.images = (from e in enclusers
                            where e.fjType == "image"
                            select e).ToList();
            }
            return Rtn<List<Comment>>.Success(comments);
        }
    }
}