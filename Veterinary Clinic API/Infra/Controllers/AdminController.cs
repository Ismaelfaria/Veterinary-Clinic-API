using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Veterinary_Clinic_API.App.ServicesInterface.ICreateService;
using Veterinary_Clinic_API.App.ServicesInterface.IDeleteService;
using Veterinary_Clinic_API.App.ServicesInterface.IGetService;
using Veterinary_Clinic_API.App.ServicesInterface.IUpdateService;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.Infra.Controllers
{
    [Route("api/AdminHome")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ICreateAdmS _serviceCreate;
        private readonly IGetAdminS _serviceGet;

        public AdminController(ICreateAdmS serviceCreate, IGetAdminS serviceGet)
        {
            _serviceCreate = serviceCreate;
            _serviceGet = serviceGet;
        }

        [HttpPost]
        public IActionResult CreatingRegistry([FromForm] Admin admin)
        {
            try
            {
                var register = _serviceCreate.admCreate(admin);
                return Created();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro do Post(Controller): {ex.Message}");
            }
        }
    }
}
