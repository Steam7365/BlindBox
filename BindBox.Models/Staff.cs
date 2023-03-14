
namespace BindBox.Models
{
    /// <summary>
    /// 员工信息
    /// </summary>
    public class Staff
    {
        /// <summary>
        /// 员工编号
        /// </summary>
        public int StaffId { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string StaffName { get; set; }
        /// <summary>
        /// 工资
        /// </summary>
        public decimal StaffWages { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string StaffGender { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string StaffPhone { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        public string StaffCode { get; set; }
        /// <summary>
        /// 入职时间
        /// </summary>
        public DateTime StaffEntryTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 职位
        /// </summary>
        public string StaffPosition { get; set; } = "员工";
        /// <summary>
        /// 状态
        /// </summary>
        public string? StaffState { get; set; } = "在职";
        /// <summary>
        /// 头像
        /// </summary>
        public string? Image { get; set; }
        /// <summary>
        /// 省
        /// </summary>
        public string? Province { get; set; }
        /// <summary>
        /// 市
        /// </summary>
        public string? City { get; set; }
        /// <summary>
        /// 区
        /// </summary>
        public string? Area { get; set; }
        /// <summary>
        /// 详情地址
        /// </summary>
        public string? Details { get; set; }
        public bool IsDelete { get; set; }=false;

        public List<Login> Logins { get; set; }
    }
}
