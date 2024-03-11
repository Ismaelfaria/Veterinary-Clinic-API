using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Veterinary_Clinic_API.App.ServicesInterface.ICreateService;
using Veterinary_Clinic_API.App.ServicesInterface.IDeleteService;
using Veterinary_Clinic_API.App.ServicesInterface.IGetService;
using Veterinary_Clinic_API.App.ServicesInterface.IUpdateService;

namespace Veterinary_Clinic_API.Infra.Controllers
{
    [Route("api/SecretariatHome")]
    [ApiController]
    public class SecretariaController : ControllerBase
    {
        private readonly ICreateSecretariat _serviceCreate;
        private readonly IDeleteSecretariat _serviceDelete;
        private readonly IGetSecretariat _serviceGet;
        private readonly IUpdateSecretariat _serviceUpdate;

        public SecretariaController(ICreateSecretariat serviceCreate, IDeleteSecretariat serviceDelete, IGetSecretariat serviceGet, IUpdateSecretariat serviceUpdate)
        {
            _serviceCreate = serviceCreate;
            _serviceDelete = serviceDelete;
            _serviceGet = serviceGet;
            _serviceUpdate = serviceUpdate;
        }
    }
}
