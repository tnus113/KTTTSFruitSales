namespace btn.Models
{
    public class ImportBillDetail
    {
        public int ImportBillDetailId { get; set; }
        public int ImportBillId { get; set; }
        public int? ProductId { get; set; }
        public decimal ProductImportAmount { get; set; }
        public decimal ImportDiscount { get; set; }
        public decimal ImportMoney => ProductImportAmount * (1 - ImportDiscount / 100);
        public virtual ImportBill? ImportBill { get; set; }
        public virtual Product? Product { get; set; }
    }
}
