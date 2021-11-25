using System.Threading.Tasks;
using Holidayview.Application.ViewModels.Customer;

namespace Holidayview.Application.Interfaces
{
    public interface ICustomerService
    {
        ListCustomerForListVm GetAllCustomersForList(int pageSize, int pageNu, string searchString);
        Task<int> AddCustomer(NewCustomerVm customer);
        CustomerDetailsVm GetCustomerDetails(int? customerId);
        NewCustomerVm GetCustomerForEdit(int id);
        void UpdateCustomer(NewCustomerVm model);
        void DeleteCustomer(int id);
    }
}