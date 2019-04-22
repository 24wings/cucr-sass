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
namespace Cucr.CucrSaas.App.Controllers {
    /// <summary>
    /// 考勤打卡
    /// </summary>
    public class ClockInput {
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
    [Route ("api/CucrSaas/App/[controller]")]
    [ApiController]

    public class IncardController : ControllerBase {

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
        public IncardController (OAContext _oaContext,
            SysContext _sysContext,
            ICommonService _commonService, IUserService _userService) {
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
        // [HttpGet ("[action]")]
        public CommonRtn getIncardDayInfo ([FromQuery] DataSourceLoadOptions options) {

            return new CommonRtn {
                success = true,
                    message = "",
                    resData = new Dictionary<string, object> { { "incards", DataSourceLoader.Load (this.oaContext.incards, options) }
                    }
            };
        }

        /// <summary>
        /// 打卡
        /// </summary>
        /// <returns></returns>
        [HttpPost ("[action]")]
        public CommonRtn clock ([FromForm] ClockInput input) {
            var tokenUser = this.userService.getUserFromAuthcationHeader ();
            var company = this.sysContext.companys.Find (tokenUser.companyId);
            if (company != null) {
                if (company.lat != null && company.lng != null) {
                    var max = new Decimal (100);
                    Console.WriteLine ((int) (company.lat * max) + ":" + ((int) (input.lat * max)));
                    if ((int) (company.lat * max) == ((int) (input.lat * max)) && (int) (company.lng * max) == ((int) (input.lng * max))) {
                        // 今日零点
                        var todayZeroClockSeconds = (int) new DateTime (DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0, 0).Subtract (new DateTime (1970, 1, 1, 0, 0, 0)).TotalSeconds;
                        var tomorrowZeroClockSeconds = todayZeroClockSeconds + 24 * 60 * 60;
                        var todayZeroSeconds = (int) DateTime.Now.Subtract (new DateTime (1970, 1, 1, 0, 0, 0)).TotalSeconds;
                        var tomorrowZeroSeconds = todayZeroSeconds + 24 * 60 * 60;
                        var copyRules = (from rule in this.oaContext.commuteCopys where rule.companyId == tokenUser.companyId && rule.datatime == todayZeroSeconds select rule).ToList ();
                        if (copyRules.Count <= 0) {

                            var rule = (from c in this.oaContext.commutes where c.companyId == tokenUser.companyId select c).FirstOrDefault ();

                            if (rule != null) {
                                var ruleCopy = (from c in this.oaContext.commuteCopys where c.companyId == rule.companyId select c).FirstOrDefault ();
                                if (ruleCopy == null) {
                                    var zeroDateTime = new DateTime (1970, 1, 1, 0, 0, 0, 0);
                                    ruleCopy = new CommuteCopy {
                                        companyId = rule.companyId,
                                        morningWorkTime = rule.morningWorkTime,
                                        morningGoOffWork = rule.morningGoOffWork,
                                        afternoonWorkTime = rule.afternoonWorkTime,
                                        afternoonGoOffWork = rule.afternoonGoOffWork,
                                        beginPunchInterval1 = rule.beginPunchInterval1,
                                        endPunchInterval1 = rule.endPunchInterval1,
                                        beginPunchInterval2 = rule.beginPunchInterval2,
                                        endPunchInterval2 = rule.endPunchInterval2,
                                        beginPunchInterval3 = rule.beginPunchInterval3,
                                        endPunchInterval3 = rule.endPunchInterval3,
                                        beginPunchInterval4 = rule.beginPunchInterval4,
                                        endPunchInterval4 = rule.endPunchInterval4,
                                        datatime = todayZeroSeconds,
                                        putCardNumber = rule.putCardNumber,
                                    };
                                    this.oaContext.commuteCopys.Add (ruleCopy);
                                    this.oaContext.SaveChanges ();

                                }
                                var now = DateTime.Now;
                                var nowSeconds = DateTime.Now.Subtract (new DateTime (now.Year, now.Month, now.Day, 0, 0, 0, 0)).TotalSeconds;
                                var incardSeri = new IncardSerialNumber {
                                    UserId = tokenUser.id,
                                    type = IncardSerialNumberType.Normal,
                                    timeSlot = InCardTimeType.First,
                                    time = DateTime.Now.Subtract (new DateTime (now.Year, now.Month, now.Day, 0, 0, 0, 0)),
                                    inputTime = (int) DateTime.Now.Subtract (new DateTime (1970, 1, 1, 0, 0, 0, 0)).TotalSeconds
                                };
                                // 进入打卡流水
                                this.oaContext.incardSerialNumbers.Add (incardSeri);
                                this.oaContext.SaveChanges ();
                                // 重新汇总当天打卡情况
                                var incardSeris = (from s in this.oaContext.incardSerialNumbers where s.inputTime >= todayZeroClockSeconds &&
                                    s.inputTime <= tomorrowZeroClockSeconds select s).ToList ();

                                var query = (from c in this.oaContext.incards where c.inputTime >= todayZeroClockSeconds && c.inputTime <= tomorrowZeroClockSeconds select c).ToList ();
                                Console.WriteLine (todayZeroClockSeconds + ":" + tomorrowZeroClockSeconds + "->" + query.Count);
                                query.ForEach (c => {
                                    this.oaContext.incards.Remove (c);
                                });
                                this.oaContext.SaveChanges ();
                                if (ruleCopy.putCardNumber == 2) {
                                    // 早班有效打卡
                                    var normalMorning = (from c in incardSeris where c.time >= ruleCopy.beginPunchInterval1 && c.time <= ruleCopy.morningWorkTime orderby c.time ascending select c).FirstOrDefault ();
                                    if (normalMorning != null) {
                                        this.addIncard (InCardTimeType.First, IncardTimeResult.Normal, tokenUser.id, tokenUser.companyId, normalMorning.time);
                                    } else {
                                        // 早班迟到卡
                                        var lateMorning = (from c in incardSeris where c.time >= ruleCopy.morningWorkTime && c.time <= ruleCopy.morningGoOffWork orderby c.time ascending select c).FirstOrDefault ();
                                        if (lateMorning != null)
                                            this.addIncard (InCardTimeType.First, IncardTimeResult.Late, tokenUser.id, tokenUser.companyId, lateMorning.time);
                                    }

                                    var normalAfternoon = (from c in incardSeris where c.time >= ruleCopy.afternoonGoOffWork && ruleCopy.endPunchInterval4 >= c.time select c).FirstOrDefault ();
                                    if (normalAfternoon != null) {
                                        this.addIncard (InCardTimeType.Fourth, IncardTimeResult.Normal, tokenUser.id, tokenUser.companyId, normalAfternoon.time);
                                    } else {
                                        var lateAfternoon = (from c in incardSeris where c.time >= ruleCopy.beginPunchInterval4 select c).FirstOrDefault ();
                                        if (lateAfternoon != null)
                                            this.addIncard (InCardTimeType.Fourth, IncardTimeResult.Early, tokenUser.id, tokenUser.companyId, lateAfternoon.time);
                                    }
                                }
                                var incards = (from i in this.oaContext.incards where i.inputTime >= todayZeroSeconds && i.inputTime < tomorrowZeroSeconds select i).ToList ();
                                return CommonRtn.Success (new Dictionary<string, object> { { "copyRules", copyRules },
                                    { "ruleCopy", ruleCopy },
                                    { "incardSeris", incardSeris },
                                    { "incards", incards }

                                }, "打卡成功");

                            } else {

                                return CommonRtn.Error ("该时间段不能打卡");
                            }
                        } else {
                            var copyRule = copyRules[0];
                            return CommonRtn.Success (new Dictionary<string, object> { { "rules", copyRules } }, "新增记录,且打卡成功");
                        }

                    } else {
                        return CommonRtn.Error ("距离过远");
                    }
                } else {
                    return CommonRtn.Error ("公司尚未设置经纬度,请快去设置吧");
                }

            } else {
                return CommonRtn.Error ("公司不存在");
            }

        }

        private void addIncard (InCardTimeType? cardType, IncardTimeResult? result, string userId, string companyId, TimeSpan? time) {
            var now = DateTime.Now;
            var newIncard = new Incard ();
            newIncard.cardTimeType = cardType;
            newIncard.result = result;
            newIncard.cardType = IncardType.Normal;
            newIncard.userId = userId;
            newIncard.companyId = companyId;
            newIncard.createTime = new DateTime ();
            newIncard.inputTime = (int) DateTime.Now.Subtract (new DateTime (1970, 1, 1, 0, 0, 0, 0, 0)).TotalSeconds;
            newIncard.time = time;
            this.oaContext.incards.Add (newIncard);
            this.oaContext.SaveChanges ();

        }

        /// <summary>
        /// 考勤
        /// </summary>
        /// <returns></returns>
        [HttpPost ("[action]")]
        public Rtn<List<Incard>> todayIncardStatus () {

            var tokenUser = this.userService.getUserFromAuthcationHeader ();
            var today = new DateTime (DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0, 0);
            var todaySeconds = (int) DateTime.Now.Subtract (today).TotalSeconds;

            var data = (from d in this.oaContext.incards where d.userId == tokenUser.id && d.inputTime >= todaySeconds select d).ToList ();
            foreach (var item in data) {
                item.daliySegment = item.time.Value.TotalSeconds >= 12 * 60 * 60 ? IncardDaliySegment.Afternoon : IncardDaliySegment.Monring;
            }

            return Rtn<List<Incard>>.Success (data);
        }
        /// <summary>
        /// 列出某天的出勤状态
        /// 2018-02-04 00:00
        /// </summary>
        /// <param name="daySeconds">时间戳 例如2018-02-04 00:00</param>
        /// <returns></returns>
        [HttpPost ("[action]")]
        public Rtn<List<Incard>> somedayIncardStatus ([FromForm (Name = "daySeconds")] DateTime daySeconds) {

            var tokenUser = this.userService.getUserFromAuthcationHeader ();
            var todaySeconds = daySeconds.Subtract (new DateTime (1970, 1, 1, 0, 0, 0)).TotalSeconds;
            var tomorrowSeconds = todaySeconds + 24 * 60 * 60;

            var data = (from d in this.oaContext.incards where d.userId == tokenUser.id &&
                d.inputTime >= todaySeconds &&
                d.inputTime <= tomorrowSeconds select d).ToList ();

            return Rtn<List<Incard>>.Success (data);
        }

        /// <summary>
        /// 获取公司打卡信息
        /// lat 
        /// lng
        /// distance   距离米
        ///  </summary>
        /// <returns></returns>
        [HttpPost ("[action]")]

        public Rtn<IncardInfoOutput> incardInfo () {
            var tokenUser = this.userService.getUserFromAuthcationHeader ();
            var company = this.sysContext.companys.Find (tokenUser.companyId);
            return Rtn<IncardInfoOutput>.Success (new IncardInfoOutput { distance = company.distance, lng = company.lng, lat = company.lat });
        }

        /// <summary>
        /// 列出出勤月记录
        /// </summary>
        /// <returns></returns>
        [HttpPost ("[action]")]
        public Rtn<IncardMonthOutput> incardMonth ([FromForm (Name = "year")] int year = 2019, [FromForm (Name = "month")] int month = 1) {
            var startTime = (int) new DateTime (year, month, 1, 0, 0, 0, 0, 0).Subtract (new DateTime (1970, 1, 1, 0, 0, 0, 0)).TotalSeconds;
            int endTime;
            if (month != 12) {
                endTime = (int) new DateTime (year, month, 1, 0, 0, 0, 0, 0).Subtract (new DateTime (1970, 1, 1, 0, 0, 0, 0)).TotalSeconds;
            } else {
                endTime = (int) new DateTime (year + 1, 1, 1, 0, 0, 0, 0, 0).Subtract (new DateTime (1970, 1, 1, 0, 0, 0, 0)).TotalSeconds;
            }
            var data = (from i in this.oaContext.incards where i.inputTime >= startTime && i.inputTime <= endTime select i).ToList ();
            foreach (var item in data) {
                item.daliySegment = item.time.Value.TotalSeconds >= 12 * 60 * 60 ? IncardDaliySegment.Afternoon : IncardDaliySegment.Monring;
            }
            var output = new IncardMonthOutput ();
            output.normal = (from i in data where i.result == IncardTimeResult.Normal select i).ToList ();
            output.early = (from i in data where i.result == IncardTimeResult.Early select i).ToList ();
            output.late = (from i in data where i.result == IncardTimeResult.Late select i).ToList ();
            output.leave = (from i in data where i.result == IncardTimeResult.Leave select i).ToList ();
            output.outCard = (from i in data where i.result == IncardTimeResult.OutCard select i).ToList ();
            output.unCard = (from i in data where i.result == IncardTimeResult.UnCard select i).ToList ();
            return Rtn<IncardMonthOutput>.Success (output);

        }
    }
}