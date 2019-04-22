using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cucr.CucrSaas.App.Entity.OA
{
    /// <summary>
    /// 序列号
    /// </summary>
    [Table("oa_incardserialnumber")]
    public class IncardSerialNumber
    {
        /// <summary>
        /// ID
        /// </summary>
        /// <value></value>
        public string Id { get; set; }
        /// <summary>
        /// 出勤卡id
        /// </summary>
        /// <value></value>
        public string inCardId { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        /// <value></value>
        public string UserId { get; set; }
        /// <summary>
        /// 出勤序列号时间
        /// </summary>
        /// <value></value>
        public IncardSerialNumberType type { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public TimeSpan? time { get; set; }
        /// <summary>
        /// 打卡时间段
        /// </summary>
        /// <value></value>
        public InCardTimeType timeSlot { get; set; }
        /// <summary>
        /// 录入人
        /// </summary>
        /// <value></value>
        public string inputPerson { get; set; }
        /// <summary>
        /// 录入时间
        /// </summary>
        /// <value></value>
        public int? inputTime { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        /// <value></value>
        public int orderBy { get; set; }
        /// <summary>
        /// 保留字段1
        /// </summary>
        /// <value></value>
        public string reservedSpace1 { get; set; }
        /// <summary>
        /// 保留字段2
        /// </summary>
        /// <value></value>
        public string reservedSpace2 { get; set; }
        /// <summary>
        /// 保留字段3
        /// </summary>
        /// <value></value>
        public string reservedSpace3 { get; set; }
    }

    /// <summary>
    /// 打卡类型
    /// </summary>
    public enum IncardSerialNumberType
    {
        /// <summary>
        /// 正常打卡
        /// </summary>
        Normal,
        /// <summary>
        /// 补卡
        /// </summary>
        Fixed
    }

}