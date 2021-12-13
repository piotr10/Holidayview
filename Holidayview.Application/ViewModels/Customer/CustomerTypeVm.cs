using AutoMapper;
using Holidayview.Application.Mapping;
using Holidayview.Domain.Model;

namespace Holidayview.Application.ViewModels.Customer
{
    public class CustomerTypeVm : IMapFrom<CustomerType>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CustomerType, CustomerTypeVm>();
        }
    }
}