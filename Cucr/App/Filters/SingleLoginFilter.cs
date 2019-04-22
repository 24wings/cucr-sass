using System;
using System.Collections;
using System.Linq;
using Cucr.CucrSaas.App.DataAccess;
using Cucr.CucrSaas.App.DTO;
using Cucr.CucrSaas.App.Service;
using Cucr.CucrSaas.ZC.Provider;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace Cucr.CucrSaas.App.Filters
{

    /// <summary>
    /// 获取用户token
    /// </summary>

    public class SingleLoginFilter : IActionFilter
    {
        /// <summary>
        /// 白名单
        /// </summary>
        /// /// <value></value>
        public string[] whiteList = new[] { "appLogin", "Test", "ZC", "Common", "User" };

        private ICommonService commonService { get; set; }
        private IUserService userService { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        private SysContext sysContext { get; set; }
        /// <summary>
        /// 单点登录
        /// </summary>
        /// <param name="_commonService"></param>
        /// <param name="_userService"></param>
        /// <param name="_sysContext"></param>
        public SingleLoginFilter(ICommonService _commonService, IUserService _userService, SysContext _sysContext)
        {
            this.commonService = _commonService;
            this.userService = _userService;
            this.sysContext = _sysContext;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var exist = (from url in this.whiteList where context.HttpContext.Request.Path.ToString().Contains(url) select url).Count();
            if (this.whiteList.Contains(context.HttpContext.Request.Path.ToString()) || exist > 0)
            {
                Console.WriteLine("白名单");
            }
            else
            {

                Console.WriteLine("===没有找到Authcation请求头值==");
                var token = this.commonService.getAuthenticationHeader();
                if (token == "" || token == null)
                {
                    context.Result = new JsonResult(new CommonRtn { success = false, message = "用户尚未登陆", code = 400 });
                }
                else
                {
                    var tokenUserCount = (from user in this.sysContext.users where user.token.Contains(token.Substring(0, 20)) select user).Count();
                    if (tokenUserCount <= 0)
                    {
                        Console.WriteLine("===========error======");
                        context.Result = new JsonResult(new CommonRtn { success = false, message = "你已经在其他设备登录", code = 400 });
                    }
                }

            }

        }
        /// <summary>
        ///  执行完成 JSON序列化
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is ObjectResult)
            {
                {
                    var objectResult = context.Result as ObjectResult;
                    var settings = new JsonSerializerSettings()
                    {
                        ContractResolver = new NullToEmptyStringResolver(),
                        DateFormatString = "yyyy-MM-dd HH:mm",
                        DefaultValueHandling = DefaultValueHandling.Populate
                    };
                    context.Result = new JsonResult(objectResult.Value, settings);

                }

            }

        }
    }

}