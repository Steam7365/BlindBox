using System.Collections.Generic;

namespace BindBox.Models.HelpModel
{
    public class CommdityDetailListViewModel
    {
        /// <summary>
        /// 商品集合
        /// </summary>
        public IEnumerable<CommdityDetail> CommdityDetails { get; set; }
        /// <summary>
        /// 分页信息
        /// </summary>

        public PagingInfo PagingInfo { get; set; }

        /// <summary>
        /// 选择的商品类别
        /// </summary>
        public int Gid { get; set; }

        public string SearchInfo{ get; set; }
    }
}
