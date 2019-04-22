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
    /// 我的  模块
    /// </summary>
    [Route("api/CucrSaas/App/[controller]")]
    [ApiController]

    public class MyController : ControllerBase
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
        public MyController(OAContext _oaContext,
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
        /// 重置密码
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public CommonRtn resetPassword([FromForm] ResetPasswordInput input)
        {
            var tokenUser = this.userService.getUserFromAuthcationHeader();
            var user = this.sysContext.users.Find(tokenUser.id);
            if (user != null)
            {
                if (DESEncrypt.DecryptString(user.loginPassword) == input.oldPassword)
                {
                    user.loginPassword = DESEncrypt.Encrypt(input.newPassword);
                    this.sysContext.SaveChanges();
                    return CommonRtn.Success(new Dictionary<string, object> { }, "修改密码成功");
                }
                else
                {
                    return CommonRtn.Error("旧密码错误");
                }

            }
            else
            {
                return CommonRtn.Error("用户尚未登录");
            }

        }



        /// <summary>
        /// 获取个人消息设置
        /// /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public CommonRtn getMyMsgSetting()
        {
            var tokenUser = this.userService.getUserFromAuthcationHeader();
            var user = this.sysContext.users.Find(tokenUser.id);
            return CommonRtn.Success(new Dictionary<string, object> { { "msgEnable", user.msgEnable } });
        }
    }
}