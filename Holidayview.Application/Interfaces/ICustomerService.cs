﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Holidayview.Application.ViewModels.Customer;
using Holidayview.Domain.Model;

namespace Holidayview.Application.Interfaces
{
    public interface ICustomerService
    {
        ListCustomerForListVm GetAllCustomersForList(int pageSize, int pageNu, string searchString);
        Task<int> AddCustomer(NewCustomerVm customer);
        void AddLeaveBalance(LeaveBalance balance);
        CustomerDetailsVm GetCustomerDetails(int? customerId);
        NewCustomerVm GetCustomerForEdit(int id);
        void UpdateCustomer(NewCustomerVm model);
        void DeleteCustomer(int id);

        NewCustomerVm SetParametersToVm(NewCustomerVm model);
        IQueryable<CustomerTypeVm> GetCustomerTypes();
        IQueryable<CustomerWithSupervisorVm> GetCustomerWithSupervisors();
    }
}