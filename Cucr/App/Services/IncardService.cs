using System;
using System.Collections.Generic;
using System.Linq;
using Cucr.CucrSaas.App.DataAccess;
using Cucr.CucrSaas.App.Entity.OA;
using Cucr.CucrSaas.App.Entity.Sys;

namespace Cucr.CucrSaas.App.Service {
    /// <summary>
    /// 出勤业务
    /// </summary>
    public interface IIncardService {
        /// <summary>
        /// 刷新出勤记录
        /// </summary>
        /// <param name="ruleCopy"></param>
        /// <param name="tokenUser"></param>
        /// <returns></returns>
        List<Incard> refershIncard (CommuteCopy ruleCopy, User tokenUser);
    }
    /// <summary>
    /// 出勤
    /// </summary>
    public class IncardService : IIncardService {

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
        public IncardService (OAContext _oaContext,
            SysContext _sysContext,
            ICommonService _commonService, IUserService _userService) {
            this.oaContext = _oaContext;
            this.sysContext = _sysContext;
            this.commonService = _commonService;
            this.userService = _userService;
        }
        /// <summary>
        /// 刷新出勤记录
        /// </summary>
        /// <returns></returns>
        public List<Incard> refershIncard (CommuteCopy ruleCopy, User tokenUser) {
            var todayZeroClockSeconds = (int) new DateTime (DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0, 0).Subtract (new DateTime (1970, 1, 1, 0, 0, 0)).TotalSeconds;
            var tomorrowZeroClockSeconds = todayZeroClockSeconds + 24 * 60 * 60;
            var todayZeroSeconds = (int) DateTime.Now.Subtract (new DateTime (1970, 1, 1, 0, 0, 0)).TotalSeconds;
            var tomorrowZeroSeconds = todayZeroSeconds + 24 * 60 * 60;

            // 重新汇总当天打卡情况
            var incardSeris = (from s in this.oaContext.incardSerialNumbers where s.inputTime >= todayZeroClockSeconds &&
                s.inputTime <= tomorrowZeroClockSeconds && s.UserId == tokenUser.id select s).ToList ();

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
            return incards;
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
    }
}