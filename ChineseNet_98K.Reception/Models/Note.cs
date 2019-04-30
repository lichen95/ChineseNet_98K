namespace ChineseNet_98K.Reception.Models
{
    /// <summary>
    /// 登录注册帮助类
    /// </summary>
    public class Note
    {
        /// <summary>
        /// 验证码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        public string Verification { get; set; }
    }
}
