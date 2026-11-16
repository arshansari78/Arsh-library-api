using MyFirstBackend.ViewModels;
using MyFirstBackend.ViewModels.Params;
using MyFirstBackend.ViewModels.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstBackend.Services
{
    public interface IApplicationUser
    {
        public Task<RLoginVm> Authenticate(PLoginVm model);

        public Task<RApplicationUserListVm> GetAll();

        public Task<ApiResultVm> ChangePassword(PChangePassword model);

        public Task<ApiResultVm> Add(ApplicationUserVm model);
    }
}
