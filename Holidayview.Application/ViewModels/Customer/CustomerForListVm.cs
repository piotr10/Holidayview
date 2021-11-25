using AutoMapper;
using Holidayview.Application.Mapping;

namespace Holidayview.Application.ViewModels.Customer
{
    public class CustomerForListVm : IMapFrom<Holidayview.Domain.Model.Customer>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Holidayview.Domain.Model.Customer, CustomerForListVm>();

        }
    }
}