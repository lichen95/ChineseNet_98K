using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Dysmsapi.Model.V20170525;
using System;
using System.Text;

namespace ChineseNet_98K.Reception.Content
{
    using Models;

    public class NoteHelper
    {
        public static Note SendSms(string phone)
        {
            String product = "Dysmsapi";//短信API产品名称（短信产品名固定，无需修改）
            String domain = "dysmsapi.aliyuncs.com";//短信API产品域名（接口地址固定，无需修改）
            String accessKeyId = "LTAIfhYWlDfiiRL3";//你的accessKeyId，参考本文档步骤2
            String accessKeySecret = "oJ6GnnmNIdaiwTVFYgl6tSkQ995znV";//你的accessKeySecret，参考本文档步骤2
            IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", accessKeyId, accessKeySecret);
            //IAcsClient client = new DefaultAcsClient(profile);
            //SingleSendSmsRequest request = new SingleSendSmsRequest();
            //初始化ascClient,暂时不支持多region（请勿修改）
            DefaultProfile.AddEndpoint("cn-hangzhou", "cn-hangzhou", product, domain);
            IAcsClient acsClient = new DefaultAcsClient(profile);
            SendSmsRequest request = new SendSmsRequest();
            try
            {
                //必填:待发送手机号。支持以逗号分隔的形式进行批量调用，批量上限为1000个手机号码,批量调用相对于单条调用及时性稍有延迟,验证码类型的短信推荐使用单条调用的方式，发送国际/港澳台消息时，接收号码格式为00+国际区号+号码，如“0085200000000”
                request.PhoneNumbers = phone;
                //必填:短信签名-可在短信控制台中找到
                request.SignName = "98K小说中文网";
                //必填:短信模板-可在短信控制台中找到，发送国际/港澳台消息时，请使用国际/港澳台短信模版
                request.TemplateCode = "SMS_151234035";
                //获取手机验证码
                string cord = GetPhoneCode();
                //可选:模板中的变量替换JSON串,如模板内容为"亲爱的${name},您的验证码为${code}"时,此处的值为
                request.TemplateParam = "{\"code\":\"" + cord + "\"}";
                //可选:outId为提供给业务方扩展字段,最终在短信回执消息中将此值带回给调用者
                //request.OutId = "yourOutId";
                //请求失败这里会抛ClientException异常
                SendSmsResponse sendSmsResponse = acsClient.GetAcsResponse(request);
                Note n = new Note
                {
                    Msg = sendSmsResponse.Message,
                    Verification = cord
                };
                return n;
            }
            catch (ServerException)
            {
                return null;
            }
            catch (ClientException)
            {
                return null;
            }
        }

        /// <summary>
        /// 获取手机验证码
        /// </summary>
        /// <returns></returns>
        public static string GetPhoneCode()
        {
            Random objDom = new Random();
            StringBuilder BuilderString = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                BuilderString.Append(i);
            }
            string PhoneCodeString = "";
            for (int i = 0; i < 6; i++)
            {
                int index = objDom.Next(0, BuilderString.Length);
                PhoneCodeString += index;
                BuilderString.Remove(index, 1);
            }
            return PhoneCodeString;
        }
    }
}