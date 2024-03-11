using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Veterinary_Clinic_API.App.ServicesInterface.ICreateService;
using Veterinary_Clinic_API.App.ServicesInterface.IDeleteService;
using Veterinary_Clinic_API.App.ServicesInterface.IGetService;
using Veterinary_Clinic_API.App.ServicesInterface.IUpdateService;

namespace Veterinary_Clinic_API.Infra.Controllers
{
    [Route("api/ConsultHome")]
    [ApiController]
    public class ConsultController : ControllerBase
    {
        private readonly ICreateConsult _serviceCreate;
        private readonly IDeleteConsult _serviceDelete;
        private readonly IGetConsult _serviceGet;
        private readonly IUpdateConsult _serviceUpdate;

        public ConsultController(ICreateConsult serviceCreate, IDeleteConsult serviceDelete, IGetConsult serviceGet, IUpdateConsult serviceUpdate)
        {
            _serviceCreate = serviceCreate;
            _serviceDelete = serviceDelete;
            _serviceGet = serviceGet;
            _serviceUpdate = serviceUpdate;
        }
    }
}
