using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Holidayview.Application.Interfaces;
using Holidayview.Application.Services;
using Holidayview.Application.ViewModels.Customer;
using Holidayview.Domain.Model;
using Holidayview.Infrastructure;
using Holidayview.Web.Helpers.CustomerHelper;
using Holidayview.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Internal;

namespace Holidayview.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly Context _context;

        public CustomerController(ICustomerService customerService, Context context)
        {
            _customerService = customerService;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index(int pageSize = 2, int page = 1, string searchFilter = "")
        {
            var model = _customerService.GetAllCustomersForList(pageSize, page, searchFilter);
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int pageSize, int? pageNo, string searchString)
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }

            if (searchString is null)
            {
                searchString = String.Empty;
            }

            var model = _customerService.GetAllCustomersForList(pageSize, pageNo.Value, searchString);
            return View(model);
        }

        public IActionResult AddCustomer()
        {
            #region Dropdownlist
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name");
            ViewData["DirectorId"] = new SelectList(_context.Directors, "Id", "Name", "Surname");
            ViewData["ManagerId"] = new SelectList(_context.Managers, "Id", "Name", "Surname");
            ViewData["LeaderId"] = new SelectList(_context.Leaders, "Id", "Name", "Surname");
            ViewData["DisableId"] = new SelectList(_context.Disables, "Id", "Name");
            ViewData["VacationId"] = new SelectList(_context.Vacations, "Id", "LeaveDimension");
            #endregion

            var model = new NewCustomerVm();

            _customerService.SetParametersToVm(model);
            return View(model);
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCustomer(NewCustomerVm model)
        {
            try
            {
                #region Dropdownlist
                ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", model.CompanyId);
                ViewData["DirectorId"] = new SelectList(_context.Directors, "Id", "Name", model.DirectorId);
                ViewData["ManagerId"] = new SelectList(_context.Managers, "Id", "Name", model.ManagerId);
                ViewData["LeaderId"] = new SelectList(_context.Leaders, "Id", "Name", model.LeaderId);
                ViewData["DisableId"] = new SelectList(_context.Disables, "Id", "Name", model.DisableId);
                ViewData["VacationId"] = new SelectList(_context.Vacations, "Id", "LeaveDimension", model.VacationId);
                #endregion

                List<Vacation> vacation = new List<Vacation>();
                AddBalanceOfLeave balanceOfLeave = new AddBalanceOfLeave(_context, _customerService);
                model.IsActive = true;
                model.CustomerWithSupervisors = _customerService.CheckCustomerWithSupervisorList(model.CustomerWithSupervisors);
                var id = await _customerService.AddCustomer(model);
                balanceOfLeave.AddNewBalanceOfLeave(model, vacation, id);

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }
        
        public IActionResult Edit(int id)
        {
            var customer = _customerService.GetCustomerForEdit(id);
            #region Dropdownlist
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name");
            ViewData["DirectorId"] = new SelectList(_context.Directors, "Id", "Name");
            ViewData["ManagerId"] = new SelectList(_context.Managers, "Id", "Name");
            ViewData["LeaderId"] = new SelectList(_context.Leaders, "Id", "Name");
            ViewData["DisableId"] = new SelectList(_context.Disables, "Id", "Name");
            ViewData["VacationId"] = new SelectList(_context.Vacations, "Id", "LeaveDimension");
            #endregion
            return View(customer);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, NewCustomerVm model, List<LeaveBalance> balanceEdit)
        {
            #region Dropdownlist
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", model.CompanyId);
            ViewData["DirectorId"] = new SelectList(_context.Directors, "Id", "Name", model.DirectorId);
            ViewData["ManagerId"] = new SelectList(_context.Managers, "Id", "Name", model.ManagerId);
            ViewData["LeaderId"] = new SelectList(_context.Leaders, "Id", "Name", model.LeaderId);
            ViewData["DisableId"] = new SelectList(_context.Disables, "Id", "Name", model.DisableId);
            ViewData["VacationId"] = new SelectList(_context.Vacations, "Id", "LeaveDimension", model.VacationId);
            #endregion

            if (id != model.Id)
            {
                TempData["errorsavechanges"] = "Error";
                return NotFound();                
            }

            if (ModelState.IsValid)
            {
                var balance = (from bal in _context.LeaveBalances
                    select bal).ToList();
                var leave = (from lea in _context.Customers
                    select lea).ToList();

                var idEdit = leave.Where(x => x.Id == id).ToList();
                var idBalanceOfLeave = idEdit.Where(x => x.Id == id).Select(x => x.LeaveBalances).ToList();


                foreach (var idBalance in idBalanceOfLeave)
                {
                    var editBalanceOfLeave = idBalance.Where(x => x.CustomerId == id).Select(x=>x.BalanceOfLeave);
                    var editLeaveTaken = idBalance.Where(x => x.CustomerId == id).Select(x=>x.LeaveTaken);
                    var editLeaveLeft = idBalance.Where(x => x.CustomerId == id).Select(x=>x.LeaveLeft);
                    var editCustomerId = idBalance.Where(x => x.CustomerId == id).Select(x=>x.CustomerId);
                    var editId = idBalance.Where(x => x.CustomerId == id).Select(x=>x.Id);

                    model.LeaveBalances = new List<LeaveBalance>() { };

                    model.LeaveBalances.Add(new LeaveBalance()
                    {
                        BalanceOfLeave = editBalanceOfLeave.FirstOrDefault(),
                        LeaveTaken = editLeaveTaken.FirstOrDefault(),
                        LeaveLeft = editLeaveLeft.FirstOrDefault(),
                        CustomerId = editCustomerId.FirstOrDefault(),
                        Id = editId.FirstOrDefault()
                    });
                }

                _customerService.UpdateCustomer(model);
                TempData["editsavechanges"] = "Save changes";
            }

            return View(model);
        }
               
        public IActionResult Delete(int id)
        {
            _customerService.DeleteCustomer(id);
            return RedirectToAction("Index");
        }
               
        public IActionResult Details(int? id)
        {
            if (id != null)
            {   
                var customerModelFirstCustomer = _customerService.GetCustomerDetails(id);
                return View(customerModelFirstCustomer);
            }

            var customerModel = _customerService.GetCustomerDetails(id);
            return View(customerModel);
        }
    }
}
