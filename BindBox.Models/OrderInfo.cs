namespace BindBox.Models
{
    public class OrderInfo
    {
        public int OrderInfoId { get; set; }
        /// <summary>
        /// 订单单号
        /// </summary>
        public string Order { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public string OrderState { get; set; }
        /// <summary>
        /// 商品数量
        /// </summary>
        public string Count { get; set; }
        /// <summary>
        /// 商品总价
        /// </summary>
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// 订单金额
        /// </summary>
        public decimal ActualPrice { get; set; }
        /// <summary>
        /// 运费
        /// </summary>
        public decimal Freight { get; set; } = 0;
        /// <summary>
        /// 订单支付渠道
        /// </summary>
        public string Channel { get; set; } = "支付宝";
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }= DateTime.Now;
        /// <summary>
        /// 付款时间
        /// </summary>
        public DateTime? PaymentTime { get; set; }
        /// <summary>
        /// 发货时间
        /// </summary>
        public DateTime? DeliverTime { get; set; }
        public AddressInfo? AddressInfo { get; set; }
        public Draw? Draw { get; set; }
    }
}
