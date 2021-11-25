using AutoMapper;
using Holidayview.Application.Mapping;
using Holidayview.Domain.Model;
using System.Collections.Generic;

namespace Holidayview.Application.ViewModels.Customer
{
    public class NewCustomerVm : IMapFrom<Domain.Model.Customer>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int IndividualId { get; set; }
        public bool IsActive { get; set; }
        public string Email { get; set; }
        public int CompanyId { get; set; }
        public int DirectorId { get; set; }
        public int ManagerId { get; set; }
        public int LeaderId { get; set; }
        public int DisableId { get; set; }
        public int VacationId { get; set; }
        public ICollection<LeaveBalance> LeaveBalances { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Application.ViewModels.Customer.NewCustomerVm, Domain.Model.Customer>().ReverseMap();              
        }
    }
}