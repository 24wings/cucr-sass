using Cucr.CucrSaas.App.Entity.OA;

namespace Cucr.CucrSaas.App.DTO
{
    /// <summary>
    /// app用户登录实体
    /// </summary>
    public class IncardDayOutput
    {
        /// <summary>
        /// 上午出勤
        /// </summary>
        /// <value></value>
        public Incard morning { get; set; } = new Incard { result = IncardTimeResult.None };
        /// <summary>
        /// 下午出勤
        /// </summary>
        /// <value></value>
        public Incard afternoon { get; set; } = new Incard { result = IncardTimeResult.None };
    }
}