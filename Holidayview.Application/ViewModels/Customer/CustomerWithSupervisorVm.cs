using AutoMapper;
using Holidayview.Application.Mapping;
using Holidayview.Domain.Model;

namespace Holidayview.Application.ViewModels.Customer
{
    public class CustomerWithSupervisorVm : IMapFrom<CustomerType>
    {
        public int Id { get; set; }
        public string Leader { get; set; }
        public string Manager { get; set; }
        public string Director { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CustomerWithSupervisor, CustomerWithSupervisorVm>();
        }
    }
}