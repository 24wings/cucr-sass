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
    /// App登录注册授权接口
    /// </summary>
    [Route("api/CucrSaas/App/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
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
        public AuthController(OAContext _oaContext,
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
        /// 发送短信注册验证码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public CommonRtn sendSignupAuthcode([FromForm] AppSingupInput input)
        {
            var code = Guid.NewGuid().ToString().Substring(0, 4);
            var smsResponseData = this.smsService.sendSignupAuthcode(input.phone, code);
            var message = new Message { bizId = smsResponseData.BizId, phone = input.phone, code = code, isAuthcode = true };
            this.sysContext.messages.Add(message);
            this.sysContext.SaveChanges();
            return new CommonRtn { success = true, message = "", resData = new Dictionary<string, object> { { "response", smsResponseData } } };
        }

        /// <summary>
        /// app登录
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public CommonRtn appLogin([FromForm]AppUserLoginInput loginInput)
        {

            var exisitUser = (from user in this.sysContext.users where user.phone == loginInput.phone select user).FirstOrDefault();
            if (exisitUser != null)
            {
                // if (DESEncrypt.DecryptString(exisitUser.loginPassword) == loginInput.loginPassword)
                // {
                var loginIp = this.commonService.getRequestIp();
                exisitUser.loginNumber++;
                exisitUser.loginIP = loginIp;
                exisitUser.mechineId = loginInput.mechineId;
                var token = this.userService.getUserToken(
                    new AppTokenOutput
                    {
                        user = new User
                        {
                            id = exisitUser.id,
                            phone = exisitUser.phone,
                            companyId = exisitUser.companyId,
                            companyFrameworkId = exisitUser.companyFrameworkId
                        }
                    });
                exisitUser.token = token;
                Console.WriteLine("companyFrameowrkId:" + this.userService.decodeToken(token).user.companyFrameworkId);
                Console.WriteLine("cpmid" + exisitUser.companyFrameworkId);
                Console.WriteLine("companyId" + exisitUser.companyId);
                this.sysContext.SaveChanges();

                return new CommonRtn { success = true, message = "登录成功", resData = new Dictionary<string, object>() { { "token", token }, { "user", exisitUser } } };
                // }
                // else
                // {
                // return CommonRtn.Error("登录失败,用户密码错误");
                // }
            }
            else
            {

                return new CommonRtn { success = false, message = "登录失败,用户不存在", };
            }

        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public CommonRtn signup([FromForm] SignupInput input)
        {
            var exisitUser = (from user in this.sysContext.users where user.phone == input.phone select user).Count();
            var message = (from msg in this.sysContext.messages where msg.phone == input.phone orderby msg.createTime descending select msg).First();
            if (message == null)
            {
                return CommonRtn.Error("请先发送短信验证码");
            }
            if (message.code != input.authcode)
            {
                return CommonRtn.Error("短信验证码错误");
            }
            if (exisitUser > 0)
            {
                return new CommonRtn { success = false, message = "用户已经注册" };
            }
            else
            {
                var user = new User
                {
                    phone = input.phone,
                    loginPassword = DESEncrypt.Encrypt(input.loginPassword),
                    id = Guid.NewGuid().ToString()
                };
                this.sysContext.users.Add(user);
                this.sysContext.SaveChanges();
                return new CommonRtn { success = true, message = "注册成功" };
            }
        }
        /// <summary>
        /// 忘记密码
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public CommonRtn forgotPassword([FromForm] AppForgotPasswordInput input)
        {
            var userExist = (from user in this.sysContext.users where user.phone == input.phone select user).First();
            if (userExist != null)
            {
                var msg = (from message in this.sysContext.messages where message.phone == input.phone orderby message.createTime select message).First();
                if (msg != null)
                {
                    if (msg.code == input.authcode)
                    {
                        userExist.loginPassword = DESEncrypt.Encrypt(input.newPassword);
                        var token = userService.getUserToken(new AppTokenOutput { user = userExist });
                        return CommonRtn.Success(new Dictionary<string, object> { { "token", token } });
                    }
                    else
                    {
                        return CommonRtn.Error("短信验证码错误");
                    }
                }
                else
                {
                    return CommonRtn.Error("请先发送短信验证码");
                }
            }
            else
            {
                return CommonRtn.Error("手机号尚未注册为用户");
            }
        }

    }
}