using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Cucr.CucrSaas.App.Service {

    /// <summary>
    /// 用户业务接口
    /// </summary>
    public interface ICommonService {
        /// <summary>
        /// 获取请求ip
        /// </summary>
        /// <returns></returns>
        string getRequestIp ();
        /// <summary>
        /// 获取认证请求头
        /// </summary>
        /// <returns></returns>
        string getAuthenticationHeader ();
    }

    /// <summary>
    /// 用户业务具体实现
    /// </summary>
    public class CommonService : ICommonService {
        private IHttpContextAccessor accessor;

        /// <summary>
        /// 通用业务
        /// </summary>
        /// <param name="_accessor"></param>
        public CommonService (IHttpContextAccessor _accessor) {
            this.accessor = _accessor;
        }
        /// <summary>
        /// 获取请求ip
        /// </summary>
        /// <returns></returns>
        public string getRequestIp () {
            return this.accessor.HttpContext.Connection.RemoteIpAddress.ToString ();
        }
        /// <summary>
        /// 获取认证请求头
        /// </summary>
        /// <returns></returns>
        public string getAuthenticationHeader () {
            // Console.WriteLine (JsonConvert.SerializeObject (this.accessor.HttpContext.Request.Headers));
            // Console.WriteLine (this.accessor.HttpContext.Request.Headers["Authorization"]);
            return this.accessor.HttpContext.Request.Headers["Authorization"];
        }
    }

}