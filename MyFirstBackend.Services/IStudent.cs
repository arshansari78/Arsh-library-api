using System;
using System.Collections.Generic;
using System.Text;
using MyFirstBackend.ViewModels;
using MyFirstBackend.ViewModels.Result;

namespace MyFirstBackend.Services
{
    public interface IStudent
    {
        public Task<RStudentListVm> GetAll(int PageNo, int PageSize);

        public Task<RStudentVm> GetById(int id);

        public Task<ApiResultVm> Add(StudentVm model);


        public Task<ApiResultVm> Update(StudentVm model);

        public Task<ApiResultVm> Delete(int id);
    }
}
