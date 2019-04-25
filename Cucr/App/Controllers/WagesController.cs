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
    /// 工资条查询
    /// </summary>
    public class WagesSearchInput
    {
        /// <summary>
        /// 年份月份时间戳
        /// </summary>
        /// <value></value>
        public DateTime yearMonth { get; set; }

    }

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
        /// 获取用户某月工资条
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public Rtn<Wages> getUserWagesMonth([FromForm]WagesSearchInput input)
        {
            var instance = this.userService.getUserFromAuthcationHeader();
            var startTime = (int)input.yearMonth.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds;
            var endTime = (int)input.yearMonth.AddMonths(1).Subtract(new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
            Console.WriteLine("startTime:" + startTime + " endtime:" + endTime);
            var wages = (from w in this.oaContext.wageses where w.grantTime >= startTime && w.grantTime <= endTime && w.userId == instance.id select w).FirstOrDefault();
            if (wages == null)
            {
                return Rtn<Wages>.Error("该月份暂无工资条");

            }
            return Rtn<Wages>.Success(wages);


        }

    }
}