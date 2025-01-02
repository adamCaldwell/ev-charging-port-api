using EVChargingPort.API.Application.Services;
using EVChargingPort.API.Infrastructure.DbContexts;
using EVChargingPort.API.Infrastructure.Profiles;
using EVChargingPort.API.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
 
// Add services to the container.
builder.Services.AddScoped<IApplicationService, ApplicationService>();
builder.Services.AddScoped<IVrnService, VrnService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationContext>(dbContextOptions
    => dbContextOptions.UseSqlite("Data Source = Applications.db"));

builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();

builder.Services.AddAutoMapper(typeof(ApplicationProfile));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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