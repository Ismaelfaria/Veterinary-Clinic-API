using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Veterinary_Clinic_API.App.Dto;
using Veterinary_Clinic_API.App.RepositorysInterface.IGet;
using Veterinary_Clinic_API.App.ServicesInterface.Token;

namespace Veterinary_Clinic_API.App.UseCases.Token
{
    public class TokenDoctorService : ITokenServiceD
    {
        private readonly IConfiguration _configuration;
        private readonly IGetDoctorR _respositoryUser;

        public TokenDoctorService(IConfiguration configuration, IGetDoctorR respositoryByUserName)
        {
            _configuration = configuration;
            _respositoryUser = respositoryByUserName;
        }

        public string GenerateToken(LoginDto login)
        {
            var userDatabase = _respositoryUser.FindByUserName(login.UserName);

            if (login.UserName != userDatabase.UserName || login.Password != userDatabase.Password)
            {
                return string.Empty;
            }

            var secretKey = new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? string.Empty));
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];

            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: new[]
                {
                    new Claim(ClaimTypes.Name, userDatabase.UserName),
                    new Claim(ClaimTypes.Role, userDatabase.Role),
                },
                expires: DateTime.Now.AddHours(2),
                signingCredentials: signinCredentials);

            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return token;
        }
    }
}
