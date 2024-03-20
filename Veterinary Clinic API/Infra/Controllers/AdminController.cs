using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Veterinary_Clinic_API.App.Mapping.Models.InputModels;
using Veterinary_Clinic_API.App.ServicesInterface.ICreateService;
using Veterinary_Clinic_API.App.ServicesInterface.IGetService;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.Infra.Controllers
{
    [Route("api/AdminHome")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ICreateAdmS _serviceCreate;
        private readonly IGetAdminS _serviceGet;
        private readonly IMapper _mapper;

        public AdminController(ICreateAdmS serviceCreate, IGetAdminS serviceGet, IMapper mapper)
        {
            _serviceCreate = serviceCreate;
            _serviceGet = serviceGet;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreatingRegistry([FromForm] InputAdmin admin)
        {
            try
            {
                var mapp = _mapper.Map<Admin>(admin);

                var register = _serviceCreate.admCreate(mapp);
                return Created();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro do Post(Controller): {ex.Message}");
            }
        }
    }
}
