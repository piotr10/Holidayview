using System.Collections.Generic;

namespace Holidayview.Domain.Model
{
    public class CustomerWithSupervisor
    {
        public int Id { get; set; }
        public string Leader { get; set; }
        public string Manager { get; set; }
        public string Director { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        //Customer types e.g. manager / TL / director
        public int CustomerTypeId { get; set; }
        public virtual CustomerType CustomerType { get; set; }
    }
}