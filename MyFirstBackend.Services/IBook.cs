using MyFirstBackend.ViewModels;
using MyFirstBackend.ViewModels.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstBackend.Services
{
    public interface IBook
    {
        public Task<RBookListVm> GetAll(int PageNo, int PageSize);

        public Task<RBookVm> GetById(int id);

        public Task<ApiResultVm> Add(BookVm model);


        public Task<ApiResultVm> Update(BookVm model);

        public Task<ApiResultVm> Delete(int id);
    }
}
