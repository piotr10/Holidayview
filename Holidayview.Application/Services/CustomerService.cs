using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Holidayview.Application.Interfaces;
using Holidayview.Application.ViewModels.CustomerVm;
using Holidayview.Domain.Interfaces;
using Holidayview.Domain.Model;

namespace Holidayview.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepo;
        private readonly IMapper _mapper;
        
        public CustomerService(ICustomerRepository customerRepo, IMapper mapper)
        {
            _customerRepo = customerRepo;
            _mapper = mapper;
        }

        public int AddCustomer(NewCustomerVm customer)
        {
            var cust = _mapper.Map<Customer>(customer);
            var id = _customerRepo.AddCustomer(cust);
            return id;
        }

        public void AddLeaveBalance(LeaveBalance leaveBalance)
        {
            var balance = _mapper.Map<LeaveBalance>(leaveBalance);
            _customerRepo.AddLeaveBalance(balance);
        }

        public void DeleteCustomer(int id)
        {            
            _customerRepo.DeleteCustomer(id);
        }

        public ListCustomerForListVm GetAllCustomersForList(int pageSize, int pageNo, string searchString)
        {
            var customers = _customerRepo.GetAllActiveCustomers()
                .Where(p => p.Name.StartsWith(searchString) | p.Surname.StartsWith(searchString) | p.Email.StartsWith(searchString))
                .ProjectTo<CustomerForListVm>(_mapper.ConfigurationProvider).ToList();
            var customersToShow = customers.Skip(pageSize*(pageNo-1)).Take(pageSize).ToList();

            var customerList = new ListCustomerForListVm()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                Customers = customersToShow,                
                Count = customers.Count
            };
            #region Stara metoda
            /*
            ListCustomerForListVm result = new ListCustomerForListVm();
            result.Customers = new List<CustomerForListVm>();
            foreach (var customer in customers)
            {
                var custVm = new CustomerForListVm()
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Surname = customer.Surname,
                    Email = customer.Email
                };
                result.Customers.Add(custVm);
            }
            result.Count = result.Customers.Count;
            */
            #endregion

            return customerList;
        }

        /*public CustomerDetailsVm GetCustomerDetails(int? customerId)
        {
            var customer = _customerRepo.GetCustomer(customerId);
            #region Stara metoda
            /*
            var customerVm1 = new CustomerDetailsVm();

            List<Director> dirt = new List<Director>();

            var query = (from cust in _customerRepo.GetAllActiveCustomers()
                select cust).ToList();

            foreach (var dirtList in dirt)
            {
                var add = new Director()
                {
                    Id = dirtList.Id,
                    Name = dirtList.Name,
                    Surname = dirtList.Surname
                };
                dirt.Add(add);
            }

            customerVm1.Id = customer.Id;
            customerVm1.CustomerFullName = customer.Name + " " + customer.Surname;
            customerVm1.Email = customer.Email;
            customerVm1.DirectorFullName = dirt.Where(x => x.Id == customerId).Select(x => x.Name) + " " + dirt.Where(x => x.Id == customerId).Select(x => x.Surname);
            customerVm1.ManagerFullName = customer.Manager.Name + " " + customer.Manager.Surname;
            customerVm1.LeaderFullName = customer.Leader.Name + " " + customer.Leader.Surname;
            #1#
            #endregion
            var customerVm = _mapper.Map<Customer, CustomerDetailsVm>(customer);
            #region stara metoda
            /*
            customerVm.LeaveBalances = new List<LeaveBalanceForListVm>();
            foreach (var leave in customer.LeaveBalances)
            {
                var add = new LeaveBalanceForListVm()
                {
                    Id = leave.Id,
                    BalanceOfLeave = leave.BalanceOfLeave,
                    LeaveLeft = leave.LeaveLeft,
                    LeaveTaken = leave.LeaveTaken
                };
                customerVm.LeaveBalances.Add(add);
            }#1#
            #endregion
            return customerVm;
        }*/

        public CustomerDetailsVm GetCustomerDetails(int? customerId)
        {
            var customer = _customerRepo.GetCustomer(customerId);
            
            var customerLeaveBalanceVm = new CustomerDetailsVm();
            customerLeaveBalanceVm.LeaveBalances = new List<LeaveBalance>();
            foreach (var leaveBalance in customer.LeaveBalances)
            {
                var add = new LeaveBalance()
                {
                    Id = leaveBalance.Id,
                    BalanceOfLeave = leaveBalance.BalanceOfLeave,
                    LeaveLeft = leaveBalance.LeaveLeft,
                    LeaveTaken = leaveBalance.LeaveTaken
                };
                customerLeaveBalanceVm.LeaveBalances.Add(add);
            }
            
            var customerVm = _mapper.Map<CustomerDetailsVm>(customer);
            return customerVm;
        }

        public NewCustomerVm GetCustomerForEdit(int id)
        {
            var customer = _customerRepo.GetCustomer(id);
            var customerVm = _mapper.Map<NewCustomerVm>(customer);
            return customerVm;
        }

        public void UpdateCustomer(NewCustomerVm model)
        {
            var customer = _mapper.Map<Customer>(model);
            _customerRepo.UpdateCustomer(customer);
        }

        public NewCustomerVm SetParametersToVm(NewCustomerVm model)
        {
            model.CustomerTypes = GetCustomerTypes().ToList();
            model.CustomerWithSupervisors = GetCustomerWithSupervisors().ToList();
            return model;
        }
        public List<CustomerTypeVm> CheckCustomerTypeList(List<CustomerTypeVm> customerTypes)
        {
            var cusTypesVm = new List<CustomerTypeVm>();
            cusTypesVm = customerTypes.Where(x => x.Name != null).ToList();
            return cusTypesVm;
        }

        public IQueryable<CustomerTypeVm> GetCustomerTypes() //powinna zaciągnąć się lista ze stanowiskami Director / Manager / Leader
        {
            var cusTypesVm = _customerRepo.GetCustomerTypes().ProjectTo<CustomerTypeVm>(_mapper.ConfigurationProvider);
            return cusTypesVm;
        }
        
        public List<NewCustomerWithSupervisorVm> CheckCustomerWithSupervisorList(List<NewCustomerWithSupervisorVm> customerWithSupervisors)
        {
            var supervisor = new List<NewCustomerWithSupervisorVm>();
            supervisor = customerWithSupervisors.Where(c => c.Leader != null).ToList();
            return supervisor;
        }

        public IQueryable<NewCustomerWithSupervisorVm> GetCustomerWithSupervisors() // powinna zaciągnąć się lista z imię+nazwisko przełożonego do listy rozwijanej Director/Manager/Leader
        {
            var cusTypesVm = _customerRepo.GetCustomerWithSupervisors().ProjectTo<NewCustomerWithSupervisorVm>(_mapper.ConfigurationProvider);
            return cusTypesVm;
        }
    }
}