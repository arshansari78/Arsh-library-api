using MyFirstBackend.ViewModels;
using MyFirstBackend.ViewModels.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstBackend.Services
{
    public interface IAllotment
    {
        public Task<RAllotmentListVm> GetAll(int PageNo,int PageSize);

        public Task<RAllotmentVm> GetById(int id);

        public Task<RAllotmentListVm> GetByStudentId(int studentId); 
        
        public Task<ApiResultVm> Add(AllotmentVm model);

        public Task<ApiResultVm> Update(AllotmentVm model);

        public Task<ApiResultVm> Delete(int id);
    }
}
