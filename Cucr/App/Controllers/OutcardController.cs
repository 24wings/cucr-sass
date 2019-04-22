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
namespace Cucr.CucrSaas.App.Controllers {

    /// <summary>
    /// 外勤
    /// </summary>
    [Route ("api/CucrSaas/App/[controller]")]
    [ApiController]

    public class OutcardController : ControllerBase {

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
        public OutcardController (OAContext _oaContext,
            SysContext _sysContext,
            ICommonService _commonService, IUserService _userService) {
            this.oaContext = _oaContext;
            this.sysContext = _sysContext;
            this.commonService = _commonService;
            this.userService = _userService;
        }

        /// <summary>
        /// 创建外勤
        /// </summary>
        /// <returns></returns>
        [HttpPost ("[action]")]
        public Rtn<Outcard> createOutcard ([FromForm] CreateOutcardInput input) {
            var tokenUser = this.userService.getUserFromAuthcationHeader ();
            var newOutcard = new Outcard {
                companyId = tokenUser.companyId,
                userId = tokenUser.id,
                noticePerson = input.noticePersonIds,
                content = input.content,
                kqType = KqType.Field,
                title = input.title,
                time = DateTime.Now.Subtract (new DateTime (DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0, 0)),
                cardType = CardType.CheckIn,
                inputTime = DateUtil.getNowSeconds ()
            };
            var encluserIds = input.encluserIds.Split (";");
            var enclusers = (from e in this.oaContext.enclosures where encluserIds.Contains (e.id) select e).ToList ();
            foreach (var e in enclusers) {
                e.fjId = newOutcard.id;
            }
            this.oaContext.Add (newOutcard);
            this.oaContext.SaveChanges ();
            return Rtn<Outcard>.Success (newOutcard);
        }

    }
}