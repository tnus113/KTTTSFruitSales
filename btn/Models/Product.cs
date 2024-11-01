namespace btn.Models
{
    public class Product
    {
        public Product()
        {
            ImportBillDetails = new HashSet<ImportBillDetail>();
            SellBillDetails = new HashSet<SellBillDetail>();
        }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Unit {  get; set; }
        public string ProvidePlace { get; set; }
        public string Uses { get; set; }
        public string Color { get; set; }
        public int Amount { get; set; }
        public decimal MoneyOnImport { get; set; }
        public decimal MoneyOnSell { get; set; }
        public string Character {  get; set; }
        public virtual ICollection<ImportBillDetail> ImportBillDetails { get; set; }
        public virtual ICollection<SellBillDetail> SellBillDetails { get; set; }
    }
}
