using AutoMapper;
using Holidayview.Application.Mapping;
using Holidayview.Domain.Model;
using System.Collections.Generic;
using System.ComponentModel;

namespace Holidayview.Application.ViewModels.Customer
{
    public class NewCustomerVm : IMapFrom<Domain.Model.Customer>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [DisplayName("Individual ID")]
        public int IndividualId { get; set; }
        public bool IsActive { get; set; }
        public string Email { get; set; }
        [DisplayName("Position")]
        public int CustomerTypeId { get; set; }
        [DisplayName("Company")]
        public int CompanyId { get; set; }
        [DisplayName("Director")]
        public int DirectorId { get; set; }
        [DisplayName("Manager")]
        public int ManagerId { get; set; }
        [DisplayName("Leader")]
        public int LeaderId { get; set; }
        [DisplayName("Disable")]
        public int DisableId { get; set; }
        [DisplayName("Vacation")]
        public int VacationId { get; set; }
        //public List<Vacation> Vacations { get; set; }
        public List<CustomerTypeVm> CustomerTypes { get; set; }
        public ICollection<LeaveBalance> LeaveBalances { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Application.ViewModels.Customer.NewCustomerVm, Domain.Model.Customer>().ReverseMap();              
        }
    }
}