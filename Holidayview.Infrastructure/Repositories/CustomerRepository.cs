using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Holidayview.Domain.Interfaces;
using Holidayview.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Holidayview.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Context _context;

        public CustomerRepository(Context context)
        {
            _context = context;
        }

        //Dodajemy klienta
        public async Task<int> AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer.Id;
        }
        public void AddLeaveBalance(LeaveBalance balance)
        {
            _context.LeaveBalances.Add(balance);
            _context.SaveChanges();
        }
        
        //Usuwamy klienta 
        public void DeleteCustomer(int customerId)
        {
            var customer =  _context.Customers.Find(customerId);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
        }

        /*
        //Uzyskujemy wielu klientów
        public async Task<IQueryable<Customer>> GetCustomersById(int? customerId)
        {
            var customer = _context.Customers.Where(x => x.Id == customerId);
            return customer;
        }
        
        //Uzyskujemy wielu klientów wersja z projektu warehouse      
        public IQueryable<Customer> GetAllCustomers()
        {
            IQueryable<Customer> customers = _context.Customers;
            return customers;
        }
        
        //Uzyskujemy jednego konkretnego klienta
        public async Task<Customer> GetOneCustomerById(int? customerId)
        {
            var customer = _context.Customers.FirstOrDefaultAsync(x => x.Id == customerId);
            return await customer;
        }
        */

        public IQueryable<Customer> GetAllActiveCustomers()
        {
            return _context.Customers.Where(x => x.IsActive);
        }


        /*//Jeżeli nie zadziala metoda GetAllActiveCustomers i wywali tylko jednego użytkownika to zastosuj poniższą
         //Lub metoda powyżej GetAllCustomers zaimplementowana z innego projektu
        public List<Customer> GetActiveCustomers()
        {
            var customerIsActive = _context.Customers.Where(x => x.IsActive).ToList();
            return customerIsActive;
        }
        */
        /*
        public IQueryable<Customer> GetAllActiveCustomers()
           {
           //var imageModel = _context.Images.Where(p => p.IsActive);
           //var imageModel = _context.Images;
           IQueryable<Customer> customers = _context.Customers;
           return customers;
           }
        */

        /*public Customer GetCustomer(int customerId)
        {
            /*
            var director = (from list in _context.Customers
                select list.Director).ToList();

            var name = director.Where(x => x.Id == customerId).Select(x => x.Name);
            var surnname = director.Where(x => x.Id == customerId).Select(x => x.Surname);
            #1#
            return _context.Customers.FirstOrDefault(x => x.Id == customerId);
        }*/

        public Customer GetCustomer(int? customerId)
        {
            return _context.Customers
            .Include(x => x.Company)
            .Include(x => x.Director)
            .Include(x => x.Manager)
            .Include(x => x.Leader)
            .Include(x => x.Disable)
            .Include(x => x.Vacation)
            .Include(x => x.LeaveBalances)
            .FirstOrDefault(x => x.Id == customerId);
        }
        

        public void UpdateCustomer(Customer customer)
        {
            _context.Attach(customer);
            #region IsModified = true
            _context.Entry(customer).Property("Id").IsModified = false;
            _context.Entry(customer).Property("Name").IsModified = true;
            _context.Entry(customer).Property("Surname").IsModified = true;
            _context.Entry(customer).Property("IndividualId").IsModified = true;
            _context.Entry(customer).Property("IsActive").IsModified = true;
            _context.Entry(customer).Property("Email").IsModified = true;
            _context.Entry(customer).Property("CompanyId").IsModified = true;
            _context.Entry(customer).Property("DirectorId").IsModified = true;
            _context.Entry(customer).Property("ManagerId").IsModified = true;
            _context.Entry(customer).Property("LeaderId").IsModified = true;
            _context.Entry(customer).Property("DisableId").IsModified = true;
            _context.Entry(customer).Property("VacationId").IsModified = true;

            customer.LeaveBalances.Each(type => _context.Entry(type).State = EntityState.Modified);

            /*
            _context.Entry(customer).Property("LeaveBalances.Id").IsModified = true;
            _context.Entry(customer).Property("LeaveBalances.BalanceOfLeave").IsModified = true;
            _context.Entry(customer).Property("LeaveBalances.LeaveLeft").IsModified = true;
            _context.Entry(customer).Property("LeaveBalances.LeaveTaken").IsModified = true;
            _context.Entry(customer).Property("LeaveBalances.CustomerId").IsModified = true;
            */
            #endregion

            _context.SaveChanges();
        }
        public IQueryable<CustomerType> GetCustomerTypes()
        {
            var cusTypes = _context.CustomerTypes.AsNoTracking();
            return cusTypes;
        }

        public IQueryable<CustomerWithSupervisor> GetCustomerWithSupervisors()
        {
            var cusTypes = _context.CustomerWithSupervisors.AsNoTracking();
            return cusTypes;
        }
    }
}
