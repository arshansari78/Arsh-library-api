using Microsoft.EntityFrameworkCore;
using MyFirstBackend.Models;
using MyFirstBackend.Services;
using MyFirstBackend.ViewModels;
using MyFirstBackend.ViewModels.Result;
using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList.Extensions;

     
    


namespace MyFirstBackend.Repositories
{
    public class AllotmentRepository : IAllotment

    {
        private readonly ApplicationDbContext context;
        public AllotmentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<ApiResultVm> Add(AllotmentVm model)
        {
            ApiResultVm result = new ApiResultVm();
            try
            {
                Allotment allotment = new Allotment
                {
                    BookId = model.BookId,
                    Id = model.Id,
                    StudentId = model.StudentId,
                    Note = model.Note,
                    OnDate = model.OnDate,
                };
                context.Allotments.Add(allotment);
                var res = await context.SaveChangesAsync();
                if (res > 0) result = new ApiResultVm { Succeeded = true, Message = "Success" };
                else result = new ApiResultVm { Succeeded = false, Message = "Server Error" };

            }
            catch (Exception ex)
            {
                result = new ApiResultVm { Succeeded = false, Message = ex.Message };
            }
            return result;
        }
        public async Task<ApiResultVm> Delete(int Id)
        {
            ApiResultVm result = new ApiResultVm();
            try
            {
                var res = await context.Allotments.FindAsync(Id);
                if (res == null)
                {
                    result = new ApiResultVm { Succeeded = false, Message = "Invalid item to delete" };
                    return result;
                }
                context.Allotments.Remove(res);
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
        public async Task<RAllotmentListVm> GetAll(int PageNo, int PageSize)
        {
            RAllotmentListVm result = new RAllotmentListVm();
            try
            {
                var res = context.Allotments
                    .Include(x => x.Book)
                    .Include(x => x.Student)
                    .ToPagedList(PageNo, PageSize);

                if (res != null)
                {
                    List<AllotmentVm> allotmentVms = new List<AllotmentVm>();

                    foreach (var item in res)
                    {
                        AllotmentVm vm = new AllotmentVm
                        {
                            Id = item.Id,
                            BookId = item.BookId,
                            Book = item.Book == null ? null : new BookVm
                            {
                                Id = item.Book.Id,
                                Name = item.Book.Name,
                                Author = item.Book.Author,
                                Publication = item.Book.Publication,
                                Category = item.Book.Category,
                            },
                            StudentId = item.StudentId,
                            Student = item.Student == null ? null : new StudentVm
                            {
                                Id = item.Student.Id,
                                Name = item.Student.Name,
                                Address = item.Student.Address,
                                DOB = item.Student.DOB,
                                PhoneNo = item.Student.PhoneNo,
                            },
                            Note = item.Note,
                            OnDate = item.OnDate
                        };
                        allotmentVms.Add(vm);
                    }

                    result.Data = allotmentVms;
                    result.Result = new ApiResultVm { Message = "success", Succeeded = true };
                }
                else
                {
                    result.Result = new ApiResultVm { Message = "No data found", Succeeded = false };
                }
            }
            catch (Exception ex)
            {
                result.Result = new ApiResultVm { Message = ex.Message, Succeeded = false };
            }
            return result;
        }
        public async Task<RAllotmentVm> GetById(int Id)
        {
            RAllotmentVm result = new RAllotmentVm();
            try
            {
                var res = await context.Allotments.FindAsync(Id);
                if (res != null)
                {
                    AllotmentVm allotment = new AllotmentVm()
                    {
                        Id = res.Id,
                        BookId = res.BookId,
                        StudentId = res.StudentId,
                        Note = res.Note,
                        OnDate = res.OnDate
                    };
                    result.Data = allotment;
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
        public async Task<RAllotmentListVm> GetByStudentId(int StudentId)
        {
            RAllotmentListVm result = new RAllotmentListVm();
            try
            {
                var res = await context.Allotments
                    .Where(e => e.StudentId == StudentId)
                    .Include(x => x.Book)
                    .Include(x => x.Student)
                    .ToListAsync();
                if (res != null)
                {
                    List<AllotmentVm> vms = new List<AllotmentVm>();
                    foreach (var item in res)
                                             {
                        AllotmentVm vm = new AllotmentVm
                        {
                            Id = item.Id,
                            BookId = item.BookId,
                            Book = item.Book == null ? null : new BookVm
                            {
                                Id = item.Book.Id,
                                Name = item.Book.Name,
                                Author = item.Book.Author,
                                Publication = item.Book.Publication,
                                Category = item.Book.Category,
                            },

                            StudentId = item.StudentId,
                            Student = item.Student == null ? null : new StudentVm
                            {
                                Id = item.Student.Id,
                                Name = item.Student.Name,
                                Address = item.Student.Address,
                                DOB = item.Student.DOB,
                               
                                PhoneNo = item.Student.PhoneNo,
                            },
                            OnDate = item.OnDate,
                            Note = item.Note,
                        };
                        vms.Add(vm);
                    }
                    result.Data = vms;
                    result.Result = new ApiResultVm { Succeeded = true, Message = "Sussess" };
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
        public async Task<ApiResultVm> Update(AllotmentVm model)
        {
            ApiResultVm result = new ApiResultVm();
            try
            {
                var res = await context.Allotments.FindAsync(model.Id);
                if (res == null)
                    return new ApiResultVm { Succeeded = false, Message = "Invalid Item" };

                res.Id = model.Id;
                res.BookId = model.BookId;
                res.StudentId = model.StudentId;
                res.Note = model.Note;
                res.OnDate = model.OnDate;

                context.Allotments.Update(res);
                var res2 = await context.SaveChangesAsync();
                result = new ApiResultVm { Succeeded = true, Message = "Updated Successfully! Updated Count:" + res2 };
            }
            catch (Exception ex)
            {
                result = new ApiResultVm { Succeeded = false, Message = ex.Message };
            }
            return result;
        }
    }
}
