using System.Collections.Generic;
using Cucr.CucrSaas.App.Entity.OA;

namespace Cucr.CucrSaas.App.DTO {
    /// <summary>
    /// 出勤月汇总
    /// </summary>
    public class IncardMonthOutput {

        /// <summary>
        /// 正常出勤
        /// </summary>
        /// <value></value>
        public List<Incard> normal { get; set; }
        /// <summary>
        /// 迟到
        /// </summary>
        public List<Incard> late { get; set; }
        /// <summary>
        /// 早退
        /// </summary>
        public List<Incard> early { get; set; }
        /// <summary>
        /// 未打卡
        /// </summary>
        public List<Incard> unCard { get; set; }
        /// <summary>
        /// 请假
        /// </summary>
        public List<Incard> leave { get; set; }
        /// <summary>
        /// 外勤
        /// </summary>
        public List<Incard> outCard { get; set; }

    }
}