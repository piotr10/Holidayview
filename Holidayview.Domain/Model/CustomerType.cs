using System.Collections.Generic;

namespace Holidayview.Domain.Model
{
    public class CustomerType //e.g. manager/ TL / director
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public virtual ICollection<CustomerWithSupervisor> CustomerWithSupervisors { get; set; }
    }
}