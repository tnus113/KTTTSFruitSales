using System.ComponentModel.DataAnnotations;

namespace btn.Models
{
    public class Customer
    {
        public Customer()
        {
            SellBills = new HashSet<SellBill>();
        }
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<SellBill> SellBills { get; set; }
    }
}
