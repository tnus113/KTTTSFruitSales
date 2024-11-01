namespace btn.Models
{
    public class ImportBill
    {
        public ImportBill()
        {
            ImportBillDetails = new HashSet<ImportBillDetail>();
        }
        public int ImportBillId { get; set; }
        public int EmployeeId { get; set; }
        public int ProviderId { get; set; }
        public DateTime ImportsDate { get; set; }
        public decimal TotalMoney { get; set; }
        public virtual Employee? Employee { get; set; }
        public virtual Provider? Provider { get; set; }
        public virtual ICollection<ImportBillDetail> ImportBillDetails { get; set; }
    }
}
