using System.Collections.Generic;

namespace Holidayview.Domain.Model
{
    public class CustomerWithSupervisor
    {
        public int Id { get; set; }
        public string Leader { get; set; }
        public string Manager { get; set; }
        public string Director { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}