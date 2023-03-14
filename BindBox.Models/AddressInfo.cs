namespace BindBox.Models
{
    public class AddressInfo
    {
        public int AddressInfoId { get; set; }
        /// <summary>
        /// 省
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// 市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 区
        /// </summary>
        public string Area { get; set; }
        /// <summary>
        /// 详情地址
        /// </summary>
        public string AddressDetails { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 备用手机号
        /// </summary>
        public string? Phone2 { get; set; }
        /// <summary>
        /// 是否为默认地址
        /// </summary>
        public bool IsDefault { get; set; }=false;
        public UserInfo UserInfo { get; set; }
        public bool IsDelete { get; set; }
    }
}
