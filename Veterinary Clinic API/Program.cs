using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Veterinary_Clinic_API.App.Mapping.Profilers;
using Veterinary_Clinic_API.App.RepositorysInterface.ICreate;
using Veterinary_Clinic_API.App.RepositorysInterface.IDelete;
using Veterinary_Clinic_API.App.RepositorysInterface.IGet;
using Veterinary_Clinic_API.App.RepositorysInterface.IUpdate;
using Veterinary_Clinic_API.App.ServicesInterface.ICreateService;
using Veterinary_Clinic_API.App.ServicesInterface.Token;
using Veterinary_Clinic_API.App.UseCases.Adm;
using Veterinary_Clinic_API.App.UseCases.ClientService;
using Veterinary_Clinic_API.App.UseCases.ConsultService;
using Veterinary_Clinic_API.App.UseCases.DoctorService;
using Veterinary_Clinic_API.App.UseCases.SecretariatService;
using Veterinary_Clinic_API.App.UseCases.Token;
using Veterinary_Clinic_API.App.Validator;
using Veterinary_Clinic_API.Domain.Entitys;
using Veterinary_Clinic_API.Infra.Context;
using Veterinary_Clinic_API.Infra.Repositorys.Create;
using Veterinary_Clinic_API.Infra.Repositorys.Delete;
using Veterinary_Clinic_API.Infra.Repositorys.Get;
using Veterinary_Clinic_API.Infra.Repositorys.Update;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Cabeçalho de autorização JWT está usando o esquema de Bearer \r\n\r\n Digite um 'Bearer' antes de colocar um token."
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
{
    {
    new OpenApiSecurityScheme
    {
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    },
    Array.Empty<string>()
    }
});
});

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

//DBContext settings
var ConnectionString = builder.Configuration.GetConnectionString("UserDatabase");
builder.Services.AddDbContext<ContextVeterinaryClinic>(o => o.UseSqlServer(ConnectionString));

//Repository
builder.Services.AddScoped<ICreateSecretariatR, CreateSecretariat>();
builder.Services.AddScoped<ICreateClientR, CreateClient>();
builder.Services.AddScoped<ICreateConsultR, CreateConsult>();
builder.Services.AddScoped<ICreateDoctorR, CreateDoctor>();
builder.Services.AddScoped<ICreateAdmR, CreateAdm>();

builder.Services.AddScoped<IDeleteSecretariatR, DeleteSecretariat>();
builder.Services.AddScoped<IDeleteClientR, DeleteClient>();
builder.Services.AddScoped<IDeleteConsultR, DeleteCosult>();
builder.Services.AddScoped<IDeleteDoctorR, DeleteDoctor>();

builder.Services.AddScoped<IGetSecretariatR, GetSecretariat>();
builder.Services.AddScoped<IGetClientR, GetClient>();
builder.Services.AddScoped<IGetConsultR, GetConsult>();
builder.Services.AddScoped<IGetDoctorR, GetDoctor>();
builder.Services.AddScoped<IGetAdminR, GetAdmin>();

builder.Services.AddScoped<IUpdateSecretariatR, UpdateSecretariat>();
builder.Services.AddScoped<IUpdateClientR, UpdateClient>();
builder.Services.AddScoped<IUpdateConsultR, UpdateConsult>();
builder.Services.AddScoped<IUpdateDoctorR, UpdateDoctor>();

//Use Cases
builder.Services.AddScoped<ISecretariat, SecreService>();
builder.Services.AddScoped<IClient, ClientServiceS>();
builder.Services.AddScoped<IConsult, ConsultServiceS>();
builder.Services.AddScoped<IDoctor, DoctorService>();
builder.Services.AddScoped<IAdmS, AdmS>();

//Jwt
builder.Services.AddScoped<ITokenServiceD, TokenDoctorService>();
builder.Services.AddScoped<ITokenServiceS, TokenSecretariatService>();
builder.Services.AddScoped<ITokenServiceA, TokenAdminService>();

//Validator
builder.Services.AddTransient<IValidator<Doctor>, ValidatorDoctor>();
builder.Services.AddTransient<IValidator<Client>, ValidatorClient>();
builder.Services.AddTransient<IValidator<Consultation>, ValidatorConsult>();
builder.Services.AddTransient<IValidator<Secretariat>, ValidatorSecret>();

//AutoMapper
builder.Services.AddAutoMapper(typeof(AdminProfile));
builder.Services.AddAutoMapper(typeof(ClientProfile));
builder.Services.AddAutoMapper(typeof(DoctorProfile));
builder.Services.AddAutoMapper(typeof(ConsultProfile));
builder.Services.AddAutoMapper(typeof(SecretProfile));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
