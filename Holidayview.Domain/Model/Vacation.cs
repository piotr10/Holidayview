using System.Collections.Generic;

namespace Holidayview.Domain.Model
{
    public class Vacation
    {
        public int Id { get; set; }
        public int LeaveDimension { get; set; }

        //Customer
        public virtual ICollection<Customer> Customers { get; set; }
    }
}