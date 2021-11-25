using System.Collections.Generic;
using AutoMapper;
using Holidayview.Application.Mapping;
using Holidayview.Domain.Model;

namespace Holidayview.Application.ViewModels.Customer
{
    public class CustomerDetailsVm : IMapFrom<Holidayview.Domain.Model.Customer>
    {
        public int Id { get; set; }
        public string CustomerFullName { get; set; }
        public string Email { get; set; }
        public List<LeaveBalanceForListVm> LeaveBalances { get; set; }
        public string Company { get; set; }
        public string DirectorFullName { get; set; }
        public string ManagerFullName { get; set; }
        public string LeaderFullName { get; set; }
        public string Disable { get; set; }
        public string Vacation { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Holidayview.Domain.Model.Customer, CustomerDetailsVm>()
                .ForMember(s => s.CustomerFullName,
                    opt => opt.MapFrom(d => d.Surname + " " + d.Name))
                .ForMember(s => s.Company,
                    opt => opt.MapFrom(d => d.Company.Name))
                .ForMember(s => s.DirectorFullName,
                    opt => opt.MapFrom(d => d.Director.Surname + " " + d.Director.Name))
                .ForMember(s => s.ManagerFullName,
                    opt => opt.MapFrom(d => d.Manager.Surname + " " + d.Manager.Name))
                .ForMember(s => s.LeaderFullName,
                    opt => opt.MapFrom(d => d.Leader.Surname + " " + d.Leader.Name))
                .ForMember(s => s.Disable,
                    opt => opt.MapFrom(d => d.Disable.Name))
                .ForMember(s => s.Vacation,
                    opt => opt.MapFrom(d => d.Vacation.LeaveDimension))
                .ForMember(s => s.LeaveBalances,
                    opt => opt.MapFrom(d => d.LeaveBalances));
                //.ForMember(s => s.LeaveBalances, opt => opt.Ignore());

            /* profile.CreateMap<Holidayview.Domain.Model.LeaveBalance, CustomerDetailsVm>()
                 .ForMember(s => s.LeaveBalances, opt => opt.MapFrom(d => d.BalanceOfLeave))
                 .ForMember(s => s.LeaveBalances, opt => opt.MapFrom(d => d.LeaveLeft))
                 .ForMember(s => s.LeaveBalances, opt => opt.MapFrom(d => d.LeaveTaken));*/
        }
    }
}