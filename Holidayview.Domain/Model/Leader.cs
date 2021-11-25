using System.Collections.Generic;

namespace Holidayview.Domain.Model
{
    public class Leader
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        //Customer
        public virtual ICollection<Customer> Customers { get; set; }
    }
}