using System.Linq;
using System.Threading.Tasks;
using Holidayview.Domain.Model;

namespace Holidayview.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<int> AddCustomer(Customer customer);
        void DeleteCustomer(int customerId);
        // Task<IQueryable<Customer>> GetCustomersById(int? customerId);
        // IQueryable<Customer> GetAllCustomers();
        // Task<Customer> GetOneCustomerById(int? customerId);
        IQueryable<Customer> GetAllActiveCustomers();
        Customer GetCustomer(int? customerId);
        void UpdateCustomer(Customer customer);
        void AddLeaveBalance(LeaveBalance balance);
    }
}