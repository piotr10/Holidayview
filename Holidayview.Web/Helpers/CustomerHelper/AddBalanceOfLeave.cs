using System.Collections.Generic;
using System.Linq;
using Holidayview.Application.Interfaces;
using Holidayview.Application.ViewModels.CustomerVm;
using Holidayview.Domain.Model;
using Holidayview.Infrastructure;

namespace Holidayview.Web.Helpers.CustomerHelper
{
    public class AddBalanceOfLeave
    {
        private readonly Context _context;
        private readonly ICustomerService _customerService;

        public AddBalanceOfLeave(Context context, ICustomerService customerService)
        {
            _context = context;
            _customerService = customerService;
        }

        public ICollection<LeaveBalance> AddNewBalanceOfLeave(NewCustomerVm model, List<Vacation> vacations, int id)
        {
            vacations = (from vacation1 in _context.Vacations
                         select vacation1).ToList();
            var vacationValue = vacations.Where(x => x.Id == model.VacationId).Select(x => x.LeaveDimension);

            var bal = new LeaveBalance
            {
                BalanceOfLeave = vacationValue.FirstOrDefault(),
                LeaveLeft = vacationValue.FirstOrDefault(),
                LeaveTaken = 0,
                CustomerId = id
            };
            _customerService.AddLeaveBalance(bal);

            return model.LeaveBalances;
        }
    }
}