namespace BindBox.Models
{
    /// <summary>
    /// 盲盒中奖
    /// </summary>
    public class Draw
    {
        public string DrawId { get; set; }
        public CommdityDetail? CommdityDetail { get; set; }
        public UserInfo? UserInfo { get; set; }
        public bool IsDelete { get; set; }
    }
}
