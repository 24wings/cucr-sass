using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Cucr.CucrSaas.App.DataAccess;
using Cucr.CucrSaas.App.DTO;
using Cucr.CucrSaas.App.Entity.OA;
using Cucr.CucrSaas.App.Entity.Sys;
using Cucr.CucrSaas.App.Service;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using JWT;
using JWT.Algorithms;
using JWT.Builder;
using JWT.Serializers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
namespace Cucr.CucrSaas.App.Controllers
{



    /// <summary>
    /// App登录注册授权接口
    /// </summary>
    [Route("api/CucrSaas/App/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        private ICommonService commonService { get; set; }
        /// <summary>
        /// OA数据访问对象
        /// </summary>
        /// <value></value>
        public OAContext oaContext { get; set; }
        /// <summary>
        /// 系统数据库访问
        /// </summary>
        /// <value></value>
        public SysContext sysContext { get; set; }
        /// <summary>
        /// 用户接口
        /// </summary>
        /// <value></value>
        public IUserService userService { get; set; }
        /// <summary>
        /// 短信验证码
        /// </summary>
        /// <value></value>
        public ISmsService smsService { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_oaContext"></param>
        /// <param name="_sysContext"></param>
        /// <param name="_commonService"></param>
        /// <param name="_userService"></param>
        /// <param name="_smsService"></param>
        public TestController(OAContext _oaContext,
            SysContext _sysContext,
            ICommonService _commonService,
            IUserService _userService,
            ISmsService _smsService
        )
        {
            this.oaContext = _oaContext;
            this.sysContext = _sysContext;
            this.commonService = _commonService;
            this.userService = _userService;
            this.smsService = _smsService;
        }

        /// <summary>
        /// 用户列表
        /// </summary>

        /// <returns></returns>
        [HttpGet("[action]")]
        public LoadResult userList([FromQuery] DataSourceLoadOptions options)
        {

            return DataSourceLoader.Load(this.sysContext.users, options);
        }
        /// <summary>
        /// 实体列表
        /// /// </summary>
        /// <param name="companyFramework"></param>
        [HttpPost("[action]")]
        public void entityList([FromBody] CompanyFramework companyFramework)
        {

        }
        /// <summary>
        /// 实体列表
        /// /// </summary>
        /// <param name="user"></param>
        [HttpPost("[action]")]
        public void entityList2([FromBody] User user)
        {

        }

        /// <summary>
        /// 实体列表
        /// /// </summary>
        /// <param name="user"></param>
        [HttpPost("[action]")]
        public void entityList3([FromBody] WorkReport user)
        {

        }
        /// <summary>
        /// 实体列表
        /// /// </summary>
        /// <param name="user"></param>
        [HttpPost("[action]")]
        public void entityList4([FromBody] WorkOrder user)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        [HttpGet]
        public void entityList5([FromBody] Incard user)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        [HttpGet("[action]")]
        public Rtn<Incard> entityList6([FromBody] Incard user)
        {
            Rtn<Incard> incard = null;
            return incard;
        }
        /// <summary>
        /// 测试流上传文件
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public Rtn<long> testuplad([FromForm]TestFileUpload input)
        {

            var filePath = "d:/abc.png";
            var i = input.file.Length;
            var steam = input.file.OpenReadStream();

            // System.IO.File.WriteAllBytes("c:/",)
            // var fileStream = System.IO.File.Create("D:/a", (int)i, FileOptions.RandomAccess);

            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(System.IO.File.Create(filePath, (int)i, FileOptions.RandomAccess | FileOptions.WriteThrough)))
            {
                // file.WriteLine("your text here");
                // file.Write(input.file.OpenReadStream());

                // file.Dispose();
                // file.Close();
                // input.file.OpenReadStream().Dispose();
                //   fos = new FileStream(stea, FileMode.Create, FileAccess.ReadWrite);


            }

            // var newFile = System.IO.File.Open("D:\a", FileMode.CreateNew);
            // input.file.CopyTo(newFile);
            // newFile.Close();



            return Rtn<long>.Success(i);
        }
    }
}