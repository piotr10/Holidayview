using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Holidayview.Application.Mapping;
using Microsoft.AspNetCore.Identity;

namespace Holidayview.Application.ViewModels.UserVm
{
    public class UserDetailVm : IMapFrom<IdentityUser>
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public List<string> UserRoles { get; set; }
        public List<RoleVm> Roles { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<IdentityUser, UserDetailVm>();
        }
    }
}
