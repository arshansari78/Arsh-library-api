using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstBackend.Services;
using MyFirstBackend.ViewModels;

namespace MyFirstBackend.Api.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBook repo;
        public BookController(IBook _repo)
        {
            repo = _repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(int PageNo, int PageSize)
        {
            return Ok(await repo.GetAll(PageNo, PageSize));
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int Id)
        {
            return Ok(await repo.GetById(Id));
        }
        [HttpPost]
        public async Task<IActionResult> Add(BookVm model)
        {
            return Ok(await repo.Add(model));
        }
        [HttpPost]
        public async Task<IActionResult> Update(BookVm model)
        {
            return Ok(await repo.Update(model));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            return Ok(await repo.Delete(Id));
        }
    }
}
