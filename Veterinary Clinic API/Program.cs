using Veterinary_Clinic_API.App.RepositorysInterface.ICreate;
using Veterinary_Clinic_API.App.RepositorysInterface.IDelete;
using Veterinary_Clinic_API.App.RepositorysInterface.IGet;
using Veterinary_Clinic_API.App.RepositorysInterface.IUpdate;
using Veterinary_Clinic_API.App.ServicesInterface.ICreateService;
using Veterinary_Clinic_API.App.ServicesInterface.IDeleteService;
using Veterinary_Clinic_API.App.ServicesInterface.IGetService;
using Veterinary_Clinic_API.App.ServicesInterface.IUpdateService;
using Veterinary_Clinic_API.App.UseCases.ClientService;
using Veterinary_Clinic_API.App.UseCases.ConsultService;
using Veterinary_Clinic_API.App.UseCases.DoctorService;
using Veterinary_Clinic_API.App.UseCases.SecretariatService;
using Veterinary_Clinic_API.Infra.Repositorys.Create;
using Veterinary_Clinic_API.Infra.Repositorys.Delete;
using Veterinary_Clinic_API.Infra.Repositorys.Get;
using Veterinary_Clinic_API.Infra.Repositorys.Update;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Repository

builder.Services.AddScoped<ICreateSecretariatR, CreateSecretariat>();
builder.Services.AddScoped<ICreateClientR, CreateClient>();
builder.Services.AddScoped<ICreateConsultR, CreateConsult>();
builder.Services.AddScoped<ICreateDoctorR, CreateDoctor>();

builder.Services.AddScoped<IDeleteSecretariatR, DeleteSecretariat>();
builder.Services.AddScoped<IDeleteClientR, DeleteClient>();
builder.Services.AddScoped<IDeleteConsultR, DeleteCosult>();
builder.Services.AddScoped<IDeleteDoctorR, DeleteDoctor>();

builder.Services.AddScoped<IGetSecretariatR, GetSecretariat>();
builder.Services.AddScoped<IGetClientR, GetClient>();
builder.Services.AddScoped<IGetConsultR, GetConsult>();
builder.Services.AddScoped<IGetDoctorR, GetDoctor>();

builder.Services.AddScoped<IUpdateSecretariatR, UpdateSecretariat>();
builder.Services.AddScoped<IUpdateClientR, UpdateClient>();
builder.Services.AddScoped<IUpdateConsultR, UpdateConsult>();
builder.Services.AddScoped<IUpdateDoctorR, UpdateDoctor>();

//Use Cases

builder.Services.AddScoped<ICreateSecretariat, CreateSecreService>();
builder.Services.AddScoped<ICreateClient, CreateClientService>();
builder.Services.AddScoped<ICreateConsult, CreateConsultService>();
builder.Services.AddScoped<ICreateDoctor, CreateDoctorService>();

builder.Services.AddScoped<IDeleteSecretariat, DeleteSecreService>();
builder.Services.AddScoped<IDeleteClient, DeleteClientService>();
builder.Services.AddScoped<IDeleteConsult, DeleteConsultService>();
builder.Services.AddScoped<IDeleteDoctor, DeleteDoctorService>();

builder.Services.AddScoped<IUpdateSecretariat, UpdateSecreService>();
builder.Services.AddScoped<IUpdateClient, UpdateClientService>();
builder.Services.AddScoped<IUpdateConsult, UpdateConsultService>();
builder.Services.AddScoped<IUpdateDoctor, UpdateDoctorService>();

builder.Services.AddScoped<IGetSecretariat, GetSecreService>();
builder.Services.AddScoped<IGetClient, GetClientService>();
builder.Services.AddScoped<IGetConsult, GetConsultService>();
builder.Services.AddScoped<IGetDoctor, GetDoctorService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
