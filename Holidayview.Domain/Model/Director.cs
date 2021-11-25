using System.Collections.Generic;

namespace Holidayview.Domain.Model
{
    public class Director
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        
        //Customer
       // public int CustomerRef { get; set; }
       // public Customer Customer { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}