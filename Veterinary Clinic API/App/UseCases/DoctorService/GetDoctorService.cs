using Veterinary_Clinic_API.App.RepositorysInterface.IDelete;
using Veterinary_Clinic_API.App.RepositorysInterface.IGet;
using Veterinary_Clinic_API.App.ServicesInterface.IGetService;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.UseCases.DoctorService
{
    public class GetDoctorService : IGetDoctor
    {
        private readonly IGetDoctorR _getRepository;

        public GetDoctorService(IGetDoctorR getRepository)
        {
            _getRepository = getRepository;
        }

        public IEnumerable<Doctor> FindAll()
        {
            return _getRepository.FindAll();
        }

        public Doctor FindByRegister(int doctorRegister)
        {
            return _getRepository.FindByRegister(doctorRegister);
        }

        public Doctor FindByUserName(string name)
        {
            return _getRepository.FindByUserName(name);
        }
    }
}
