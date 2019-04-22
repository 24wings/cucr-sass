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
    /// 工资条
    /// </summary>
    [Route("api/CucrSaas/App/[controller]")]
    [ApiController]

    public class WagesController : ControllerBase
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
        public WagesController(OAContext _oaContext,
            SysContext _sysContext,
            ICommonService _commonService, IUserService _userService)
        {
            this.oaContext = _oaContext;
            this.sysContext = _sysContext;
            this.commonService = _commonService;
            this.userService = _userService;
        }
        /// <summary>
        /// 
        /// 获取出勤记录列表
        /// 可以设置日期
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public CommonRtn getUserWages([FromQuery] DataSourceLoadOptions options)
        {
            var token = this.commonService.getAuthenticationHeader();
            var instance = this.userService.decodeToken(token);
            if (instance?.user != null)
            {
                var query = from wages in this.oaContext.wageses where wages.userId == instance.user.id select wages;
                var result = DataSourceLoader.Load(query, options);

                return new CommonRtn
                {
                    success = true,
                    message = "",
                    resData = new Dictionary<string, object> { { "data", result }
                        }
                };
            }
            else
            {
                return new CommonRtn
                {
                    success = false,
                    message = "用户尚未登录"
                };
            };
        }

    }
}