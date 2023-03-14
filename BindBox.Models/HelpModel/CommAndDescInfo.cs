namespace BindBox.Models.HelpModel
{
    public class CommAndDescInfo
    {
        public CommInfo CommInfo { get; set; }
        public List<DescInfo> DescInfos { get; set; }
    }

    public class DescInfo
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
    }

    public class CommInfo
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

        public int? FKGradeId { get; set; }
    }

}
