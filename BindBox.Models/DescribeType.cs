namespace BindBox.Models
{
    /// <summary>
    /// 商品描述
    /// </summary>
    public class DescribeType
    {
        public int DescribeTypeId { get; set; }
        /// <summary>
        /// 描述标题
        /// </summary>
        public string DescTitle { get; set; }
        /// <summary>
        /// 描述内容
        /// </summary>
        public string DescContent { get; set; }
        public CommdityDetail? CommdityDetails { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}
