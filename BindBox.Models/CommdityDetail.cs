namespace BindBox.Models
{
    /// <summary>
    /// 盲盒细分商品
    /// </summary>
    public class CommdityDetail
    {
        public int CommdityDetailId { get; set; }
        public string ComminfoName { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string ComminfoSpec { get; set; }
        /// <summary>
        /// 参考价格
        /// </summary>
        public decimal ComminfoPrice { get; set; }
        /// <summary>
        /// 官方价格
        /// </summary>
        public decimal? OfficiaPrice { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string? ComminfoImg { get; set; }
        /// <summary>
        /// 盲盒商品等级
        /// </summary>
        public Grade? Grade { get; set; }
        public int? FKGradeId { get; set; }
        public bool IsDelete { get; set; }
        public List<BoxCommodity> BoxCommodities { get; set; }
        public List<DescribeType> DescribeTypes { get; set; }
        public List<Draw> Draws { get; set; }
    }
}
