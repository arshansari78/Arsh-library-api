using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstBackend.Services;
using MyFirstBackend.ViewModels;
using MyFirstBackend.ViewModels.Params;


namespace MyFirstBackend.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]

    public class ApplicationUserController : ControllerBase
    {
        private readonly IApplicationUser repo;
        public ApplicationUserController(IApplicationUser _repo)
        {
            repo = _repo;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate(PLoginVm model)

        {
            return Ok(await repo.Authenticate(model));
        }
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            return Ok(await repo.GetAll());
        }
         [HttpPost]

         public async Task<IActionResult> ChangePassword(PChangePassword model)
         {
             return Ok(await repo.ChangePassword(model));
         }

        [HttpPost]

        public async Task<IActionResult> Add(ApplicationUserVm model)
        {
            return Ok(await repo.Add(model));
        }
    }
}