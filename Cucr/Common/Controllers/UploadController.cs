using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Cucr.CucrSaas.App.DataAccess;
using Cucr.CucrSaas.App.DTO;
using Cucr.CucrSaas.App.Entity.OA;
using Cucr.CucrSaas.App.Service;
using Cucr.CucrSaas.Common.DTO;
using DevExtreme.AspNet.Data;
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
    /// 通用控制器,例如图片,文件上传
    /// </summary>
    [Route("api/CucrSaas/Common/[controller]")]
    [ApiController]

    public class CommonController : ControllerBase
    {
        /// <summary>
        /// 系统环境
        /// </summary>
        /// <value></value>
        private SysContext sysContext { get; set; }
        private OAContext oaContext { get; set; }
        private ICommonService commonService { get; set; }
        /// <summary>
        /// 通用控制器.
        /// </summary>
        /// <param name="_sysContext"></param>
        ///  <param name="_oaContext"></param>
        public CommonController(SysContext _sysContext, OAContext _oaContext)
        {
            sysContext = _sysContext;
            oaContext = _oaContext;
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public Rtn<Enclosure> uploadFile(UploadFileInput input)
        {

            var url = this.SaveFile(input.base64, input.ext);
            var file = new Enclosure { fjName = input.fileName, fjAddress = url, fjType = input.ext };
            this.oaContext.enclosures.Add(file);
            this.oaContext.SaveChanges();
            return Rtn<Enclosure>.Success(file);

        }

        /// <summary>
        /// 图片上传接口
        /// 图片轻以base64格式上传
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public Rtn<Enclosure> uploadImage([FromForm]UploadImageInput input)
        {
            var url = this.SaveImage(input.base64, "test");
            var file = new Enclosure { fjName = input.filename, fjAddress = url, fjType = input.ext };
            this.oaContext.enclosures.Add(file);
            this.oaContext.SaveChanges();
            return Rtn<Enclosure>.Success(file);
            // return CommonRtn.Success(new Dictionary<string, object> { { "url", url } });
        }
        /// <summary>
        /// 批量图片Base64上传
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public Rtn<List<Enclosure>> uploadImageList([FromForm]UploadImageList input)
        {
            var encluserList = new List<Enclosure>();
            foreach (var image in input.imageList)
            {
                var url = this.SaveImage(image.base64, "test");
                var file = new Enclosure { fjName = image.filename, fjAddress = url, fjType = image.ext };
                this.oaContext.enclosures.Add(file);
                encluserList.Add(file);
            }
            this.oaContext.SaveChanges();
            return Rtn<List<Enclosure>>.Success(encluserList);
        }



        /// <summary>
        ///  将echarts返回的base64 转成图片
        /// </summary>
        /// <param name="image">图片的base64形式</param>
        /// <param name="proname">项目区分</param>
        private string SaveImage(string image, string proname)
        {

            var matchPng = Regex.Match(image, "data:image/png;base64,([\\w\\W]*)$");
            var matchJpg = Regex.Match(image, "data:image/jpg;base64,([\\w\\W]*)$");
            var matchJpeg = Regex.Match(image, "data:image/jpeg;base64,([\\w\\W]*)$");
            if (matchPng.Success)
            {
                image = matchPng.Groups[1].Value;
            }
            if (matchJpg.Success)
            {
                image = matchJpg.Groups[1].Value;
            }
            if (matchJpeg.Success)
            {
                image = matchJpeg.Groups[1].Value;
            }
            var photoBytes = Convert.FromBase64String(image);
            var key = Guid.NewGuid() + "/" + proname + ".png";
            OSSService.uploadFile(new MemoryStream(photoBytes), key);
            return "https://cucr.oss-cn-beijing.aliyuncs.com/" + key;

        }

        /// <summary>
        ///  将echarts返回的base64 转成图片
        /// </summary>
        /// <param name="image">文件的base64</param>
        /// <param name="ext">扩展名</param>
        private string SaveFile(string image, string ext)
        {
            var mime = ext;
            if (ext == "ico") mime = "image/x-icon";

            var match = Regex.Match(image, "data:" + mime + ";base64,([\\w\\W]*)$");
            if (match.Success)
            {
                Console.WriteLine("match");
                image = match.Groups[1].Value;
            }
            var photoBytes = Convert.FromBase64String(image);
            var key = Guid.NewGuid() + "." + ext;
            OSSService.uploadFile(new MemoryStream(photoBytes), key);
            return "https://cucr.oss-cn-beijing.aliyuncs.com/" + key;

        }
    }
}