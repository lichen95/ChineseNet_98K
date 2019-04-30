using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ChineseNet_98K.Entity;
using ChineseNet_98K.IBLL;
using ChineseNet_98K.Reception.Content;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ChineseNet_98K.Reception.Controllers
{
    public class EmailController : Controller
    {
        //加载appsetting.json
        static IConfiguration configuration = new ConfigurationBuilder()
         .SetBasePath(Directory.GetCurrentDirectory())
         .AddJsonFile("appsettings.json").Build();

        /// <summary>
        /// 获取地址
        /// </summary>
        private static readonly string name = configuration["Email:Name"];
        private static readonly string pwd = configuration["Email:Pwd"];

        public IAuthorLR_BLL iAuthorLR_BLL { get; }
        public IUsers_BLL iUsers_BLL { get; }

        public static string Yzm = "";

        public EmailController(IAuthorLR_BLL _IAuthorLR_BLL, IUsers_BLL _iUsers_BLL)
        {
            iAuthorLR_BLL = _IAuthorLR_BLL;
            iUsers_BLL = _iUsers_BLL;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 验证重复笔名
        /// </summary>
        /// <param name="Pseudonym"></param>
        /// <returns></returns>
        public int QueryByPseudonym(string Pseudonym)
        {
            var result = 0;
            var list = iAuthorLR_BLL.Query().Where(m => m.Pseudonym.Equals(Pseudonym)).ToList();
            if (list != null)
            {
                result = list.Count;
            }
            else
            {
                result = 0;
            }
            return result;
        }
        
        /// <summary>
        /// 注册作者
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public int AuthorAdd(Authors a)
        {
            var result = 0;
            if (a.Yzm.ToUpper() == Yzm)
            {
                a.IsContract = 0;
                a.State = 0;
                a.CreateDate = DateTime.Now;
                result = iAuthorLR_BLL.Add(a);
                if (result > 0)
                {
                    a.AuthorId = result;
                    CookieHelper.SetCookies("AId", HttpUtility.UrlEncode(JsonConvert.SerializeObject(a)), 720);
                    var body = "<p><b>尊敬的用户" + a.Pseudonym + "</b></p>";
                    body += "<p>祝贺您成功申请成为本站作者。请您妥善保管好账号信息，以免给您带来不必要的损失！</P>";
                    SendEmail(a.Email, "98K小说中文网", body);
                    result = iUsers_BLL.UpState(a.UserId);
                    var model = HttpUtility.UrlDecode(CookieHelper.GetCookies("UID"));
                    Users user = JsonConvert.DeserializeObject<Users>(model);
                    user.State = 1;
                    CookieHelper.SetCookies("UID", HttpUtility.UrlEncode(JsonConvert.SerializeObject(user)), 5040);
                }
            }
            else
            {
                result = -1;
            }
            return result;
        }

        /// <summary>
        /// 发送验证码
        /// </summary>
        /// <param name="qqEmail"></param>
        /// <returns></returns>
        [HttpPost]
        public bool lead(string qqEmail)
        {
            Yzm = createrandom(6);
            var result = SendEmail(qqEmail, "98K小说中文网", "您的验证码是:" + Yzm);
            return result;
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="mailTo">要发送的邮箱</param>
        /// <param name="mailSubject">邮箱主题</param>
        /// <param name="mailContent">邮箱内容</param>
        /// <returns>返回发送邮箱的结果</returns>
        public bool SendEmail(string mailTo, string mailSubject, string mailContent)
        {
            // 设置发送方的邮件信息,例如使用网易的smtp
            string smtpServer = "smtp.qq.com"; //SMTP服务器
            string mailFrom = name; //登陆用户名
            string userPassword = pwd;//授权码 bocgqqqjmkjgbccg

            // 邮件服务设置
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式
            smtpClient.Host = smtpServer; //指定SMTP服务器
            smtpClient.Credentials = new System.Net

            .NetworkCredential(mailFrom, userPassword);//用户名和密码

            // 发送邮件设置        
            MailMessage mailMessage = new MailMessage(mailFrom, mailTo); // 发送人和收件人
            mailMessage.Subject = mailSubject;//主题
            mailMessage.Body = mailContent;//内容
            mailMessage.BodyEncoding = Encoding.UTF8;//正文编码
            mailMessage.IsBodyHtml = true;//设置为HTML格式
            mailMessage.Priority = MailPriority.High;//优先级
            smtpClient.EnableSsl = true;   //QQ邮箱 需要加为true
            try
            {
                smtpClient.Send(mailMessage); // 发送邮件
                return true;
            }
            catch (SmtpException)
            {
                return false;
            }
        }

        /// <summary>
        /// 生成6位数字和大写字母的验证码
        /// </summary>
        /// <param name="codelengh">验证码位数</param>
        /// <returns></returns>
        private string createrandom(int codelengh)
        {
            int rep = 0;
            string str = string.Empty;
            long num2 = DateTime.Now.Ticks + rep;
            rep++;
            Random random = new Random(((int)(((ulong)num2) & 0xffffffffL)) | ((int)(num2 >> rep)));
            for (int i = 0; i < codelengh; i++)
            {
                char ch;
                int num = random.Next();
                if ((num % 2) == 0)
                {
                    ch = (char)(0x30 + ((ushort)(num % 10)));
                }
                else
                {
                    ch = (char)(0x41 + ((ushort)(num % 0x1a)));
                }
                str = str + ch.ToString();
            }
            return str;
        }
    }
}