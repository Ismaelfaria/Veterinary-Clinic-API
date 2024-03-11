using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Veterinary_Clinic_API.App.ServicesInterface.ICreateService;
using Veterinary_Clinic_API.App.ServicesInterface.IDeleteService;
using Veterinary_Clinic_API.App.ServicesInterface.IGetService;
using Veterinary_Clinic_API.App.ServicesInterface.IUpdateService;

namespace Veterinary_Clinic_API.Infra.Controllers
{
    [Route("api/Doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly ICreateDoctor _serviceCreate;
        private readonly IDeleteDoctor _serviceDelete;
        private readonly IGetDoctor _serviceGet;
        private readonly IUpdateDoctor _serviceUpdate;

        public DoctorController(ICreateDoctor serviceCreate, IDeleteDoctor serviceDelete, IGetDoctor serviceGet, IUpdateDoctor serviceUpdate)
        {
            _serviceCreate = serviceCreate;
            _serviceDelete = serviceDelete;
            _serviceGet = serviceGet;
            _serviceUpdate = serviceUpdate;
        }
    }
}
