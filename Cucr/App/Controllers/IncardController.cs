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
    /// 考勤打卡
    /// </summary>
    public class ClockInput
    {
        /// <summary>
        /// Latitude 纬度
        /// </summary>
        /// <value></value>
        public decimal lat { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        /// <value></value>
        public decimal lng { get; set; }
    }

    /// <summary>
    /// 出勤
    /// </summary>
    [Route("api/CucrSaas/App/[controller]")]
    [ApiController]

    public class IncardController : ControllerBase
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
        public IncardController(OAContext _oaContext,
            SysContext _sysContext,
            ICommonService _commonService, IUserService _userService,
            IIncardService _incardService

        )
        {

            this.oaContext = _oaContext;
            this.sysContext = _sysContext;
            this.commonService = _commonService;
            this.userService = _userService;
            this.incardService = _incardService;
        }


        /// <summary>
        /// 打卡
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public Rtn<bool> clock([FromForm] ClockInput input)
        {
            var tokenUser = this.userService.getUserFromAuthcationHeader();
            var company = this.sysContext.companys.Find(tokenUser.companyId);
            if (company != null)
            {
                if (company.lat != null && company.lng != null)
                {
                    var max = new Decimal(100);
                    Console.WriteLine((int)(company.lat * max) + ":" + ((int)(input.lat * max)));
                    if ((int)(company.lat * max) == ((int)(input.lat * max)) && (int)(company.lng * max) == ((int)(input.lng * max)))
                    {
                        // 今日零点
                        var ruleCopy = this.incardService.getUserCompanyCommuteCopy(tokenUser);
                        // 添加打卡流水
                        var now = DateTime.Now;
                        var nowSeconds = DateTime.Now.Subtract(new DateTime(now.Year, now.Month, now.Day, 0, 0, 0, 0)).TotalSeconds;
                        var incardSeri = new IncardSerialNumber
                        {
                            UserId = tokenUser.id,
                            type = IncardSerialNumberType.Normal,
                            timeSlot = InCardTimeType.First,
                            time = DateTime.Now.Subtract(new DateTime(now.Year, now.Month, now.Day, 0, 0, 0, 0)),
                            inputTime = (int)DateTime.Now.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds
                        };
                        // 进入打卡流水
                        this.oaContext.incardSerialNumbers.Add(incardSeri);
                        this.oaContext.SaveChanges();
                        if (ruleCopy != null)
                        {
                            this.incardService.refershIncard(ruleCopy, tokenUser);
                            return Rtn<bool>.Success(true, "打卡成功");

                        }
                        else
                        {
                            return Rtn<bool>.Error("尚未添加公司打卡规则");
                        }

                    }
                    else
                    {

                        return Rtn<bool>.Error("该时间段不能打卡");
                    }

                }
                else
                {
                    return Rtn<bool>.Error("距离过远");
                }
            }
            else
            {
                return Rtn<bool>.Error("公司尚未设置经纬度,请快去设置吧");
            }

        }

        /// <summary>
        /// 考勤
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public Rtn<List<Incard>> todayIncardStatus()
        {
            var tokenUser = this.userService.getUserFromAuthcationHeader();
            var todaySeconds = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).Subtract(new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
            var tomorrowSeconds = todaySeconds + 24 * 60 * 60;
            Console.WriteLine("today:" + todaySeconds + " tomorrow:" + tomorrowSeconds);
            var data = (from d in this.oaContext.incards
                        where d.userId == tokenUser.id &&
d.inputTime >= todaySeconds &&
d.inputTime <= tomorrowSeconds
                        select d).ToList();
            foreach (var item in data)
            {
                item.daliySegment = item.time.Value.TotalSeconds >= 12 * 60 * 60 ? IncardDaliySegment.Afternoon : IncardDaliySegment.Monring;
            }
            return Rtn<List<Incard>>.Success(data);
        }
        /// <summary>
        /// 列出某天的出勤状态
        /// 2018-02-04 00:00
        /// </summary>
        /// <param name="daySeconds">时间戳 例如2018-02-04 00:00</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public Rtn<List<Incard>> somedayIncardStatus([FromForm(Name = "daySeconds")] DateTime daySeconds)
        {

            var tokenUser = this.userService.getUserFromAuthcationHeader();
            var todaySeconds = daySeconds.Subtract(new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
            var tomorrowSeconds = todaySeconds + 24 * 60 * 60;

            var data = (from d in this.oaContext.incards
                        where d.userId == tokenUser.id &&
d.inputTime >= todaySeconds &&
d.inputTime <= tomorrowSeconds
                        select d).ToList();

            foreach (var item in data)
            {
                item.daliySegment = item.time.Value.TotalSeconds >= 12 * 60 * 60 ? IncardDaliySegment.Afternoon : IncardDaliySegment.Monring;
            }

            return Rtn<List<Incard>>.Success(data);
        }

        /// <summary>
        /// 获取公司打卡信息
        /// lat 
        /// lng
        /// distance   距离米
        ///  </summary>
        /// <returns></returns>
        [HttpPost("[action]")]

        public Rtn<IncardInfoOutput> incardInfo()
        {
            var tokenUser = this.userService.getUserFromAuthcationHeader();
            var company = this.sysContext.companys.Find(tokenUser.companyId);
            return Rtn<IncardInfoOutput>.Success(new IncardInfoOutput { distance = company.distance, lng = company.lng, lat = company.lat });
        }

        /// <summary>
        /// 列出出勤月记录
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public Rtn<IncardMonthOutput> incardMonth([FromForm(Name = "year")] int year = 2019, [FromForm(Name = "month")] int month = 1)
        {
            var tokenUser = this.userService.getUserFromAuthcationHeader();
            var startTime = (int)new DateTime(year, month, 1, 0, 0, 0, 0, 0).Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds;
            int endTime;
            if (month != 12)
            {
                endTime = (int)new DateTime(year, month, 1, 0, 0, 0, 0, 0).Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds;
            }
            else
            {
                endTime = (int)new DateTime(year + 1, 1, 1, 0, 0, 0, 0, 0).Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds;
            }
            var data = (from i in this.oaContext.incards where i.inputTime >= startTime && i.inputTime <= endTime select i).ToList();
            foreach (var item in data)
            {
                item.daliySegment = item.time.Value.TotalSeconds >= 12 * 60 * 60 ? IncardDaliySegment.Afternoon : IncardDaliySegment.Monring;
            }
            // 外勤记录
            var outCards = (from c in this.oaContext.outcards where c.userId == tokenUser.id && c.inputTime >= startTime && c.inputTime <= c.inputTime select c).ToList();

            var output = new IncardMonthOutput();
            output.normal = (from i in data where i.result == IncardTimeResult.Normal select i).ToList();
            output.early = (from i in data where i.result == IncardTimeResult.Early select i).ToList();
            output.late = (from i in data where i.result == IncardTimeResult.Late select i).ToList();
            output.leave = (from i in data where i.result == IncardTimeResult.Leave select i).ToList();
            output.outCard = (from i in data where i.result == IncardTimeResult.OutCard select i).ToList();
            output.unCard = (from i in data where i.result == IncardTimeResult.UnCard select i).ToList();
            // 外勤记录
            foreach (var o in outCards)
            {
                var day = o.getInputTime().Day;
                foreach (var d in outCards)
                {
                    if (d.getInputTime().Day != day)
                    {
                        var newIncard = new Incard
                        {
                            result = IncardTimeResult.OutCard,
                            time = d.time,
                            inputTime = d.inputTime,
                            userId = d.userId,
                            daliySegment = d.time.Value.TotalSeconds >= 12 * 60 * 60 ? IncardDaliySegment.Afternoon : IncardDaliySegment.Monring
                        };
                        output.outCard.Add(newIncard);
                    }
                }
            }
            return Rtn<IncardMonthOutput>.Success(output);

        }
    }
}