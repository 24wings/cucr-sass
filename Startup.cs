using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Cucr.CucrSaas.App.DataAccess;
using Cucr.CucrSaas.App.Filters;
using Cucr.CucrSaas.App.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using NSwag;
using NSwag.AspNetCore;
using NSwag.SwaggerGeneration.Processors.Security;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
namespace Cucr {
    /// <summary>
    /// 程序启动类
    /// </summary>
    public class Startup {
        /// <summary>
        /// 程序启动类的构造函数
        /// </summary>
        /// <param name="configuration"></param>
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }
        /// <summary>
        /// 程序配置对象
        /// </summary>
        /// <value></value>
        public IConfiguration Configuration { get; }

        /// <summary>
        ///  This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices (IServiceCollection services) {
            // Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            // Encoding encoding = Encoding.GetEncoding("GB2312");
            services.AddCors (options => {
                options.AddPolicy ("AllowAllOrigin", builder => {
                    builder
                        .AllowAnyOrigin ()
                        .AllowAnyMethod ()
                        .AllowAnyHeader ()
                        .AllowCredentials ()

                    ;
                });
            });
            services.AddMvc ().SetCompatibilityVersion (CompatibilityVersion.Version_2_1);
            services.AddMvc (option => {
                option.Filters.Add (typeof (SingleLoginFilter));
            });

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles (configuration => {
                configuration.RootPath = "ClientApp/dist";
            });
            //
            // var connection = "Server=39.97.180.241;Database=ef;User=root;Password=yj704104;";

            //Allow Zero Datetime=True
            var connection = "Data Source=47.100.63.224;Database=cucrsaasdb;User Id=root;Password=8US7DJ3WB5v;Convert Zero Datetime=True;Allow User Variables=True;";
            // var zcUrl = "Data Source=101.132.96.199;Database=clkrzc;User Id=root;Password=123456;Convert Zero Datetime=True;Allow User Variables=True; ";
            //var connection = @"Server=localhost;Initial Catalog=master;Integrated Security=True";
            services
                .AddDbContext<OAContext> (options => options.UseMySql (connection))
                .AddDbContext<SysContext> (options => options.UseMySql (connection))

            ;
            //解决中文被编码
            services.AddSingleton (HtmlEncoder.Create (UnicodeRanges.All));

            services.AddMvc ().SetCompatibilityVersion (CompatibilityVersion.Version_2_1);

            services.AddHttpClient ();
            services.AddSwaggerDocument (config => {

                config.Version = "v1";
                config.OperationProcessors.Add (new OperationSecurityScopeProcessor ("JWT"));
                config.DocumentProcessors.Add (new SecurityDefinitionAppender ("JWT", new SwaggerSecurityScheme {
                    Type = SwaggerSecuritySchemeType.ApiKey,
                        Name = "Authorization",
                        In = SwaggerSecurityApiKeyLocation.Header,
                        Description = "Type into the textbox: Bearer {your JWT token}. You can get a JWT token from /Authorization/Authenticate."
                }));

                // Post process the generated document
                config.PostProcess = d => {
                    d.Info.Title = "创联科技Sass服务";
                    d.Consumes = (ICollection<string>) new List<string> { "application/x-www-form-urlencoded" };
                    d.Info.Description = "创联凯尔Sass服务平台,Oa,金融";
                    d.Info.Contact = new SwaggerContact { Url = "https://www.yuque.com/jieyang/cucr-sass", Name = "在线开发文档", Email = "2121718893@qq.com" };
                };
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor> ();
            services.AddScoped<ICommonService, CommonService> ();
            services.AddSingleton<IUserService, UserService> ();
            services.AddSingleton<ISmsService, SmsService> ();
            services.AddSingleton<IIncardService, IncardService> ();

        }

        /// <summary>
        ///This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            // app.UseAuthentication ();

            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                app.UseExceptionHandler ("/Error");
            }

            app.UseHttpsRedirection ();
            app.UseStaticFiles ();
            app.UseCookiePolicy ();
            app.UseStaticFiles ();
            // app.UseSpaStaticFiles();
            app.UseCors ("AllowAllOrigin");

            app.UseMvc (routes => {
                routes.MapRoute (
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
            var settings = new SwaggerDocumentMiddlewareSettings ();
            settings.PostProcess = (document, request) => {

                // document.BaseUrl = "http://192.168.1.99:5000";
                document.Info.Version = "v3";

            };
            app.UseSwaggerUi3 ();

            app.UseSwagger ();

            // app.UseSpa (spa => {
            //     // To learn more about options for serving an Angular SPA from ASP.NET Core,
            //     // see https://go.microsoft.com/fwlink/?linkid=864501
            //     spa.Options.SourcePath = "ClientApp";
            //     if (env.IsDevelopment ()) {
            //         spa.UseAngularCliServer (npmScript: "start");
            //     }
            // });
        }

    }
}