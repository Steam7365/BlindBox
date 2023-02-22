namespace BindBox.Models
{
    /// <summary>
    /// 盲盒商品
    /// </summary>
    public class BoxCommodity
    {
        public int BoxCommodityId { get; set; }
        public string CommodityName { get; set; }
        /// <summary>
        /// 封面图
        /// </summary>
        public string? CoverPhoto { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Desc { get; set; }
        public decimal Price { get; set; }
        public BoxFolder? BoxFolder { get; set; }
        public bool IsDelete { get; set; }
        public List<CommdityDetail> CommdityDetails { get; set; }
        
    }
}
