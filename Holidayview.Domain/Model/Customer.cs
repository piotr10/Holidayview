using System;
using System.Collections.Generic;

namespace Holidayview.Domain.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int IndividualId { get; set; }
        public bool IsActive { get; set; }

        //Customer types e.g. manager / TL / director
        public int CustomerTypeId { get; set; }
        public virtual CustomerType CustomerType { get; set; }

        //Leave balance - Bilans urlopowy
        public virtual ICollection<LeaveBalance> LeaveBalances { get; set; }

        //Email (do celów identyfikacji z mailem z logowania aby użytkownik
        //widział tylko swoje wnioski)
        public string Email { get; set; }

        //Company
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        //Director
        public int DirectorId { get; set; }
        public virtual Director Director { get; set; }

        //Manager
        public int ManagerId { get; set; }
        public virtual Manager Manager { get; set; }

        //Leader
        public int LeaderId { get; set; }
        public virtual Leader Leader { get; set; }

        //Disable (niepełnosprawny TAK lub NIE)
        public int DisableId { get; set; }
        public virtual Disable Disable { get; set; }

        //Leave dimension (wymiar urlopu: 20/26/dla niepełnosprawnych
        public int VacationId { get; set; }
        public virtual Vacation Vacation { get; set; }
    }
}