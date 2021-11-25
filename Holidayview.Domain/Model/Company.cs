using System.Collections.Generic;

namespace Holidayview.Domain.Model
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Customer
        public virtual ICollection<Customer> Customers { get; set; }
    }
}