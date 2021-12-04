using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Holidayview.Application.Interfaces;
using Holidayview.Application.ViewModels.UserVm;

namespace Holidayview.Web.Controllers
{
    //[Authorize (Roles = "Admin")]
    public class UserRolesController : Controller
    {
        private readonly IUserService _userService;
        public UserRolesController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("Users/All")]
        public IActionResult Index()
        {
            var model = _userService.GetAllUsers();
            return View(model);
        }

        public IActionResult AddRolesToUser(string id)
        {
            var userVm = _userService.GetUserDetails(id);
            return PartialView("AddRolesToUser", userVm);
        }

        [HttpPost]
        public async Task<IActionResult> AddRolesToUser(UserDetailVm user)
        {
            await _userService.ChangeUserRolesAsync(user.Id, user.UserRoles);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteUser(string id)
        {
            await _userService.DeleteUserAsync(id);
            return RedirectToAction("Index");
        }
    }
}
