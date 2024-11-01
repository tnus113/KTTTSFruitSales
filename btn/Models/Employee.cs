namespace btn.Models
{
    public class Employee
    {
        public Employee()
        {
            SellBills = new HashSet<SellBill>();
            ImportBills = new HashSet<ImportBill>();
        }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public virtual ICollection<SellBill> SellBills { get; set; }
        public virtual ICollection<ImportBill> ImportBills { get; set; }
    }
}
