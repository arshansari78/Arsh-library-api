using Microsoft.EntityFrameworkCore;
using MyFirstBackend.Models;
using MyFirstBackend.Services;
using MyFirstBackend.ViewModels;
using MyFirstBackend.ViewModels.Result;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;
using System.Text;
using X.PagedList.Extensions;

namespace MyFirstBackend.Repositories
{
    public class StudentRepository : IStudent
    {
        private readonly ApplicationDbContext context;
        public StudentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<ApiResultVm> Add(StudentVm model)
        {
            ApiResultVm result = new ApiResultVm();
            try
            {
                Student student = new Student
                {
                    Name = model.Name,
                    Address = model.Address,
                    DOB = model.DOB,
                   
                    PhoneNo=model.PhoneNo
                };
                context.Students.Add(student);
                var res = await context.SaveChangesAsync();
                if (res > 0) result = new ApiResultVm { Succeeded = true, Message = "Success" };
                else result = new ApiResultVm { Succeeded = false, Message = "Server Error" };

            }
            catch (Exception ex)
            {
                result = new ApiResultVm { Succeeded = false, Message = 
                    ex.Message };
            }
            return result;
        }
        public async Task<ApiResultVm> Delete(int Id)
        {
            ApiResultVm result = new ApiResultVm();
            try
            {
                var res = await context.Students.FindAsync(Id);
                if (res == null)
                {
                    result = new ApiResultVm { Succeeded = false, Message = "Invalid item to delete" };
                    return result;
                }
                context.Students.Remove(res);
                var res2 = await context.SaveChangesAsync();
                if (res2 > 0)
                {
                    result = new ApiResultVm { Succeeded = true, Message = "Deleted Successfully" };
                }
                else
                {
                    result = new ApiResultVm { Succeeded = false, Message = "Server Error" };
                }
                return result;
            }
            catch (Exception ex)
            {
                {
                    result = new ApiResultVm { Succeeded = false, Message = ex.Message };
                    return result;
                }

            }
        }
        public async Task<RStudentListVm> GetAll(int PageNo, int PageSize)
        {
            RStudentListVm result = new RStudentListVm();
            try
            {
                var res = context.Students.ToPagedList(PageNo, PageSize);
                if (res != null)
                {
                    List<StudentVm> studentVms = new List<StudentVm>();

                    foreach (var item in res)
                    {
                        StudentVm vm = new StudentVm
                        {
                            Id = item.Id,
                            Name = item.Name,
                            PhoneNo=item.PhoneNo,
                            Address = item.Address,
                            DOB = item.DOB
                        };
                        studentVms.Add(vm);
                    }
                    result.Data = studentVms;
                    result.Result = new ApiResultVm { Message = "success", Succeeded = true };
                }
                else
                {
                    result.Result = new ApiResultVm { Message = "Success", Succeeded = false };
                }

            }
            catch (Exception ex)
            {
                result.Result = new ApiResultVm { Message = ex.Message, Succeeded = false };
            }
            return result;
        }
        public async Task<RStudentVm> GetById(int Id)
        {
            RStudentVm result = new RStudentVm();
            try
            {
                var res = await context.Students.FindAsync(Id);
                if (res != null)
                {
                    StudentVm student = new StudentVm()
                    {
                        Id = res.Id,
                        Name = res.Name,
                        Address = res.Address,
                       
                        PhoneNo = res.PhoneNo,
                        DOB = res.DOB,

                    };
                    result.Data = student;
                    result.Result = new ApiResultVm { Succeeded = true, Message = "success" };
                }
                else
                {
                    result.Result = new ApiResultVm { Succeeded = false, Message = "Server Error" };
                }
            }
            catch (Exception ex)
            {
                result.Result = new ApiResultVm { Succeeded = false, Message = ex.Message };
            }
            return result;
        }
        public async Task<ApiResultVm> Update(StudentVm model)
        {
            ApiResultVm result = new ApiResultVm();
            try
            {
                var res = await context.Students.FindAsync(model.Id);
                if (res == null)
                    return new ApiResultVm { Succeeded = false, Message = "Invalid Item" };

                res.Address = model.Address;
                res.Name = model.Name;
                res.DOB = model.DOB;
                res.PhoneNo = model.PhoneNo;
               


                context.Students.Update(res);
                var res2 = await context.SaveChangesAsync();
                result = new ApiResultVm { Succeeded = true, Message = "Updated Successfully! Updated Count:" + res2 };
            }
            catch (Exception ex)
            {
                result = new ApiResultVm { Succeeded = false, Message = "Invalid Item" };
            }
            return result;
        }
    }
}
