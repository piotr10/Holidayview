using AutoMapper;
using Holidayview.Application.Mapping;

namespace Holidayview.Application.ViewModels.CustomerVm
{
    public class LeaveBalanceForListVm : IMapFrom<Holidayview.Domain.Model.Customer>
    {
        public int Id { get; set; }
        public double BalanceOfLeave { get; set; } //Saldo urlopu
        public double LeaveLeft { get; set; } //Pozostało urlopu
        public double LeaveTaken { get; set; } //Ilość dni wybranych
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Holidayview.Domain.Model.Customer, Application.ViewModels.CustomerVm.LeaveBalanceForListVm>();
        }
    }
}