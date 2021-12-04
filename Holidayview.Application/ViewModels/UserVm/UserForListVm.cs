using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Holidayview.Application.Mapping;
using Microsoft.AspNetCore.Identity;

namespace Holidayview.Application.ViewModels.UserVm
{
    public class UserForListVm : IMapFrom<IdentityUser>
    {
        public string Id { get; set; }
        public string UserName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<IdentityUser, UserForListVm>();
        }
    }
}
