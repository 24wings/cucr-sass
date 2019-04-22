using System.ComponentModel.DataAnnotations.Schema;

namespace Cucr.CucrSaas.App.Entity.OA
{
    /// <summary>
    /// 项目表
    /// </summary>
    [Table("sys_project")]
    public class Project : BaseEntity
    {
        /// <summary>
        /// 公司Id
        /// </summary>
        /// <value></value>
        public string companyId { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        /// <value></value>
        public string projectName { get; set; }

    }
}