using System.Collections.Generic;

namespace Cucr.CucrSaas.App.DTO
{

    /// <summary>
    /// 通用响应体
    /// </summary>
    public class CommonRtn
    {

        /// <summary>
        /// 消息
        /// </summary>
        /// <value></value>
        public string message { get; set; }
        /// <summary>
        /// 是否成功
        /// </summary>
        /// <value></value>
        public bool success { get; set; }
        /// <summary>
        /// 返回给前端的数据
        /// </summary>
        /// <value></value>
        public Dictionary<string, object> resData { get; set; }
        /// <summary>
        ///  状态码
        /// </summary>
        /// <value></value>
        public int code { get; set; }
        /// <summary>
        /// 便捷方法返回错误消息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static CommonRtn Error(string message)
        {
            return new CommonRtn { success = false, message = message, code = 200 };
        }
        /// <summary>
        /// 便捷方法返回正确消息
        /// </summary>
        /// <param name="resData"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static CommonRtn Success(Dictionary<string, object> resData, string message = "")
        {
            return new CommonRtn { success = true, message = message, resData = resData, code = 200 };
        }

    }

    /// <summary>
    /// 返回给前端的数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Rtn<T>
    {
        /// <summary>
        /// 消息
        /// </summary>
        /// <value></value>
        public string message { get; set; }
        /// <summary>
        /// 是否成功
        /// </summary>
        /// <value></value>
        public bool success { get; set; }
        /// <summary>
        /// 返回给前端的数据
        /// </summary>
        /// <value></value>
        public Response<T> resData { get; set; }
        /// <summary>
        ///  状态码
        /// </summary>
        /// <value></value>
        public int code { get; set; }
        /// <summary>
        /// 便捷方法返回错误消息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Rtn<T> Error(string message)
        {
            return new Rtn<T> { success = false, message = message, resData = new Response<T> { }, code = 400 };
        }
        /// <summary>
        /// 便捷方法返回正确消息
        /// </summary>
        /// <param name="data"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Rtn<T> Success(T data, string message = "")
        {
            return new Rtn<T> { success = true, message = message, resData = new Response<T> { data = data }, code = 200 };
        }
    }
    /// <summary>
    /// 响应体数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Response<T>
    {
        /// <summary>
        /// 数据
        /// </summary>
        /// <value></value>
        public T data { get; set; }
    }
}