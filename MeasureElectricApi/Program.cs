using MeasureElectricApi;
using MeasureElectricApi.DBService.Implementations;
using MeasureElectricApi.DBService.Interfaces;
using MeasureElectricData.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{
    var basePath = AppContext.BaseDirectory;

    var xmlPath = Path.Combine(basePath, "swaggerConfig.xml");
    options.IncludeXmlComments(xmlPath);
});

builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlite(AppSettings.ConnectionString));

builder.Services.AddScoped<ICompanyReporsitory, CompanyRepository>();
builder.Services.AddScoped<IBaseRepository<SubCompany>, SubCompanyRepository>();
builder.Services.AddScoped<IBaseRepository<ConsumptionObject>, ConsumptionObjectRepository>();
builder.Services.AddScoped<IElectricityMeasuringPointRepository, ElectricityMeasuringPointRepository>();
builder.Services.AddScoped<IElectricitySupplyPointRepository, ElectricitySupplyPointRepository>();

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
