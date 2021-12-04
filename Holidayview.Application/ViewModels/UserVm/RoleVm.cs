using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Holidayview.Application.Mapping;

using Microsoft.AspNetCore.Identity;

namespace Holidayview.Application.ViewModels.UserVm
{
    public class RoleVm : IMapFrom<IdentityRole>
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<IdentityRole, RoleVm>();
        }
    }
}
