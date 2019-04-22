using System;
using System.Collections.Generic;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Http;
using Aliyun.Acs.Core.Profile;
using Newtonsoft.Json;

namespace Cucr.CucrSaas.App.Service {
    /// <summary>
    /// 发送短信响应体数据
    /// </summary>
    public class SendSmsResponseData {
        /// <summary>
        /// 消息
        /// 成功为OK
        /// </summary>
        /// <value></value>
        public string Message { get; set; }
        /// <summary>
        /// 请求Id
        /// </summary>
        /// <value></value>
        public string RequestId { get; set; }
        /// <summary>
        /// 流水号
        /// </summary>
        /// <value></value>
        public string BizId { get; set; }
        /// <summary>
        /// 状态吗
        /// 成功为OK
        /// </summary>
        /// <value></value>
        public string Code { get; set; }

    }

    /// <summary>
    /// 发送短信接口
    /// </summary>
    public interface ISmsService {
        /// <summary>
        /// 发送短信接口
        /// </summary>
        /// <param name="phoneNumbers"></param>
        /// <param name="signName"></param>
        /// <param name="templateCode"></param>
        /// <param name="templateParam"></param>
        /// <returns></returns>
        CommonResponse sendSms (string phoneNumbers, string signName, string templateCode, string templateParam);
        /// <summary>
        /// 发送注册验证码
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        SendSmsResponseData sendSignupAuthcode (string phone, string code);

    }
    /// <summary>
    /// 短信服务
    /// </summary>
    public class SmsService : ISmsService {

        /// <summary>
        /// 发送短信验证码
        /// </summary>
        /// <returns></returns>
        public CommonResponse sendSms (string phoneNumbers, string signName, string templateCode, string templateParam = "{}") {
            IClientProfile profile = DefaultProfile.GetProfile ("cn-hangzhou", "LTAIcMnaxxUG7dbk", "VhNgQZrGYz7dXpiCUS8r36mbLgy6db");
            DefaultAcsClient client = new DefaultAcsClient (profile);
            CommonRequest request = new CommonRequest ();
            request.Method = MethodType.POST;
            request.Domain = "dysmsapi.aliyuncs.com";
            request.Version = "2017-05-25";
            request.Action = "SendSms";
            // request.Protocol = ProtocolType.HTTP;
            request.AddQueryParameters ("PhoneNumbers", phoneNumbers);
            request.AddQueryParameters ("SignName", signName);
            request.AddQueryParameters ("TemplateCode", templateCode);
            request.AddQueryParameters ("TemplateCode", templateCode);
            request.AddQueryParameters ("TemplateParam", templateParam);

            try {
                CommonResponse response = client.GetCommonResponse (request);
                Console.WriteLine (System.Text.Encoding.Default.GetString (response.HttpResponse.Content));

                return response;
            } catch (ServerException e) {
                Console.WriteLine (e);
                return null;
            } catch (ClientException e) {
                Console.WriteLine (e);
                return null;
            }
        }
        /// <summary>
        /// 发送注册验证码
        /// </summary>
        /// <returns></returns>
        public SendSmsResponseData sendSignupAuthcode (string phone, string code) {
            var commonResponse = sendSms (phone, "邦为科技", "SMS_140731181", "{\"code\":\"" + code + "\"}");
            var data = System.Text.Encoding.Default.GetString (commonResponse.HttpResponse.Content);
            return JsonConvert.DeserializeObject<SendSmsResponseData> (data);

        }
    }
}