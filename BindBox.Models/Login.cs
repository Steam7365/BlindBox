namespace BindBox.Models
{
    /// <summary>
    /// 后台登录表
    /// </summary>
    public class Login
    {
        public int LoginId { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public Staff? Staff { get; set; }
    }
}
