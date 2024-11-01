namespace btn.Models
{
    public class SellBill
    {
        public SellBill()
        {
            SellBillDetails = new HashSet<SellBillDetail>();
        }
        public int SellBillId { get; set; }
        public int EmployeeId { get; set; }
        public int CustomerId { get; set; }
        public DateTime SalesDate { get; set; }
        public decimal TotalMoney { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual Employee? Employee { get; set; }
        public virtual ICollection<SellBillDetail> SellBillDetails { get; set; }
    }
}
