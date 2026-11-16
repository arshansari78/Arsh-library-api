using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstBackend.Services;
using MyFirstBackend.ViewModels;

namespace MyFirstBackend.Api.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent repo;
        public StudentController(IStudent _repo)
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
        public async Task<IActionResult> Add(StudentVm model)
        {
            return Ok(await repo.Add(model));
        }
        [HttpPost]
        public async Task<IActionResult> Update(StudentVm model)
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
