using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstBackend.Services;
using MyFirstBackend.ViewModels;

namespace MyFirstBackend.Api.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AllotmentController : ControllerBase
    {
        private readonly IAllotment repo;
        public AllotmentController(IAllotment _repo)
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
        [HttpGet]
        public async Task<IActionResult> GetByStudentId(int StudentId)
        {
            return Ok(await repo.GetByStudentId(StudentId));
        }
        [HttpPost]
        public async Task<IActionResult> Add(AllotmentVm model)
        {
            return Ok(await repo.Add(model));
        }
        [HttpPost]
        public async Task<IActionResult> Update(AllotmentVm model)
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
