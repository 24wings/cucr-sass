namespace Cucr.CucrSaas.App.DTO
{
    /// <summary>
    /// 考勤打卡
    /// </summary>
    public class IncardInfoOutput
    {
        /// <summary>
        /// 经度
        /// </summary>
        /// <value></value>
        public decimal? lat { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        /// <value></value>
        public decimal? lng { get; set; }
        /// <summary>
        /// 打卡限制距离
        /// </summary>
        /// <value></value>
        public int? distance { get; set; }
    }
}
