namespace btn.Models
{
    public class Provider
    {
        public Provider()
        {
            ImportBills = new HashSet<ImportBill>();
        }
        public int ProviderID { get; set; }
        public string ProviderName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<ImportBill> ImportBills { get; set; }
    }
}
