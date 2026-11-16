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
    public class BookRepository : IBook
    {
        private readonly ApplicationDbContext context;
        public BookRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<ApiResultVm> Add(BookVm model)
        {
            ApiResultVm result = new ApiResultVm();
            try
            {
                Book book = new Book
                {
                    Name = model.Name,
                    Author = model.Author,
                    Publication = model.Publication,
                    Category = model.Category,
                };
                context.Books.Add(book);
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
                var res = await context.Books.FindAsync(Id);
                if (res == null)
                {
                    result = new ApiResultVm { Succeeded = false, Message = "Invalid item to delete" };
                    return result;
                }
                context.Books.Remove(res);
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
        public async Task<RBookListVm> GetAll(int PageNo, int PageSize)
        {
            RBookListVm result = new RBookListVm();
            try
            {
                var res = context.Books.ToPagedList(PageNo, PageSize);
                if (res != null)
                {
                    List<BookVm> bookVms = new List<BookVm>();

                    foreach (var item in res)
                    {
                        BookVm vm = new BookVm
                        {
                            Id = item.Id,
                            Name = item.Name,
                            Author = item.Author,
                            Publication = item.Publication,
                            Category = item.Category
                        };
                        bookVms.Add(vm);
                    }
                    result.Data = bookVms;
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
        public async Task<RBookVm> GetById(int Id)
        {
            RBookVm result = new RBookVm();
            try
            {
                var res = await context.Books.FindAsync(Id);
                if (res != null)
                {
                    BookVm book = new BookVm()
                    {
                        Id = res.Id,
                        Name = res.Name,
                        Author = res.Author,
                        Publication = res.Publication,
                        Category = res.Category,
                    };
                    result.Data = book;
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
        public async Task<ApiResultVm> Update(BookVm model)
        {
            ApiResultVm result = new ApiResultVm();
            try
            {
                var res = await context.Books.FindAsync(model.Id);
                if (res == null)
                    return new ApiResultVm { Succeeded = false, Message = "Invalid Item" };

                res.Id = model.Id;
                res.Name = model.Name;
                res.Author = model.Author;
                res.Publication = model.Publication;
                res.Category = model.Category;

                context.Books.Update(res);
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

