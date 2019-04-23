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
using Cucr.CucrSaas.App.Entity;
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
namespace Cucr.CucrSaas.App.Controllers {

    /// <summary>
    /// 出勤
    /// </summary>
    [Route ("api/CucrSaas/App/[controller]")]
    [ApiController]

    public class ChatRoomController : ControllerBase {

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
        /// 出勤业务
        /// </summary>
        /// <value></value>
        public IIncardService incardService { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_oaContext"></param>
        /// <param name="_sysContext"></param>
        /// <param name="_commonService"></param>
        /// <param name="_userService"></param>
        /// <param name="_incardService"></param>
        public ChatRoomController (OAContext _oaContext,
            SysContext _sysContext,
            ICommonService _commonService, IUserService _userService,
            IIncardService _incardService

        ) {

            this.oaContext = _oaContext;
            this.sysContext = _sysContext;
            this.commonService = _commonService;
            this.userService = _userService;
            this.incardService = _incardService;
        }
        /// <summary>
        /// 列出用户聊天室
        /// </summary>
        /// <returns></returns>
        [HttpPost ("[action]")]
        public Rtn<List<ChatRoom>> listChatRoom ([FromForm] ListChatRoomInput input) {
            var tokenUser = this.userService.getUserFromAuthcationHeader ();
            var rooms = (from r in this.oaContext.chatRooms where r.userId == tokenUser.id || r.joinUserIds.Contains (tokenUser.id) && r.status == ChatRoomStatus.Active orderby r.lastMsgTime descending select r)
                .Skip (input.page * input.pageSize)
                .Take (input.pageSize)
                .ToList ();
            return Rtn<List<ChatRoom>>.Success (rooms);
        }

        /// <summary>
        /// 创建聊天室
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost ("[action]")]
        public Rtn<ChatRoom> createChatRoom ([FromForm] CreateChatRoomInput input) {
            var tokenUser = this.userService.getUserFromAuthcationHeader ();
            var companyFrameworkIds = input.companyFrameworkIds.Split (";");
            // 待加入的用户列表
            var userList = new List<User> ();
            foreach (var cId in companyFrameworkIds) {
                var users = (from u in this.sysContext.users where u.companyFrameworkId == cId select u).ToList ();
                foreach (var u in users) {
                    userList.Add (u);
                }
            }

            var joinUserIds = String.Join (";", (from u in userList select u.id).ToArray ()) + ";" + input.userIds;
            var joinUserNum = joinUserIds.Trim ().Split (";").Length;
            var newChatRoom = new ChatRoom {
                userId = tokenUser.id,
                status = ChatRoomStatus.Active,
                joinUserIds = joinUserIds,
                joinUserNum = joinUserNum,
                name = input.name,

            };
            // new ChatMsg{content}
            return Rtn<ChatRoom>.Success (newChatRoom);

        }
    }
}