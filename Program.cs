using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Cucr {
    /// <summary>
    /// 程序启动文件
    /// </summary>
    public class Program {
        /// <summary>
        /// 程序启动主函数
        /// </summary>
        /// <param name="args"></param>
        public static void Main (string[] args) {
            CreateWebHostBuilder (args).Build ().Run ();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder (string[] args) =>
            WebHost.CreateDefaultBuilder (args)
            .UseStartup<Startup> ()
            .UseUrls ("http://0.0.0.0.0:5000");
    }
}