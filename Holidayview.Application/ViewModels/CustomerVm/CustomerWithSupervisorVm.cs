using System.Collections.Generic;
using AutoMapper;
using Holidayview.Application.Mapping;
using Holidayview.Domain.Model;

namespace Holidayview.Application.ViewModels.CustomerVm
{
    public class CustomerWithSupervisorVm : IMapFrom<CustomerWithSupervisor>
    {
        public int Id { get; set; }
        public string Leader { get; set; }
        public string Manager { get; set; }
        public string Director { get; set; }
        public int CustomerTypeId { get; set; }
        public List<CustomerTypeVm> CustomerTypes { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CustomerWithSupervisor, Application.ViewModels.CustomerVm.CustomerWithSupervisorVm>();
        }
    }
}