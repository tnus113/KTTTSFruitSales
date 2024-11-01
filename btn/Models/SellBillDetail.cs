namespace btn.Models
{
    public class SellBillDetail
    {
        public int SellBillDetailId { get; set; }
        public int SellBillId { get; set; }
        public int? ProductId { get; set; }
        public decimal ProductSellAmount { get; set; }
        public decimal SellDiscount { get; set; }
        public decimal SellMoney => ProductSellAmount * (1 - SellDiscount / 100);
        public virtual SellBill? SellBill { get; set; }
        public virtual Product? Product { get; set; }
    }
}
