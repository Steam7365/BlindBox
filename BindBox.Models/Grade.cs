namespace BindBox.Models
{
    /// <summary>
    /// 盲盒商品等级表
    /// </summary>
    public class Grade
    {
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        /// <summary>
        /// 概率
        /// </summary>
        public decimal Probability { get; set; }
        public bool IsDelete { get; set; }
        public List<CommdityDetail> CommdityDetails { get; set; }
    }
}
