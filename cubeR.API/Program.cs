using cubeR.BusinessLogic.Validations.Cube;
using cubeR.BusinessLogic.Validations.Solve;
using cubeR.DataAccess.DataContext;
using cubeR.DataAccess.DTOs.Cube;
using cubeR.DataAccess.DTOs.Solve;
using cubeR.DataAccess.Repositories;
using cubeR.DataAccess.Repositories.Contracts;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Logger settings
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("Logs/CuberAPILog.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

// Database connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Repositories
builder.Services.AddScoped<ISolveRepository, SolveRepository>();
builder.Services.AddScoped<ICubeRepository, CubeRepository>();

// Validators
builder.Services.AddScoped<IValidator<CubeCreateRequestDTO>, CubeCreateRequestValidator>();
builder.Services.AddScoped<IValidator<CubeUpdateRequestDTO>, CubeUpdateRequestValidator>();
builder.Services.AddScoped<IValidator<SolveCreateRequestDTO>, SolveCreateRequestValidator>();

// Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Swagger options
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Additional 
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddProblemDetails();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();