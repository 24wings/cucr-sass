using System;
using System.ComponentModel.DataAnnotations;
using Cucr.CucrSaas.App.Entity.Sys;

namespace Cucr.CucrSaas.App.DTO {

    /// <summary>
    /// App搜索用户
    /// </summary>
    public class AppSearchUserInput {

        /// <summary>
        /// 关键字
        /// </summary>
        /// <value></value>
        public string keyword { get; set; }

    }
}