using Veterinary_Clinic_API.App.Dto;

namespace Veterinary_Clinic_API.App.ServicesInterface.Token
{
    public interface ITokenServiceA
    {
        string GenerateToken(LoginDto login);
    }
}
