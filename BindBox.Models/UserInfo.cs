namespace BindBox.Models
{
    /// <summary>
    /// 客户信息
    /// </summary>
    public class UserInfo
    {
        public int UserInfoId { get; set; }
        public string UserName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string UserGender { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public string UserNumber { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string UserPwd { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string? UserPhone { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string? HeadPortrait { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birthday { get; set; }
        public bool IsDelete { get; set; }
        public List<Draw> Draws { get; set; }
        public List<AddressInfo> AddressInfos { get; set; }
    }
}
