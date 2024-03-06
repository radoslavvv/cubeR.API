using cubeR.BusinessLogic.Validations.Cube;
using cubeR.BusinessLogic.Validations.Solve;
using cubeR.DataAccess.DataContext;
using cubeR.DataAccess.DTOs.Cube;
using cubeR.DataAccess.DTOs.Solve;
using cubeR.DataAccess.Repositories;
using cubeR.DataAccess.Repositories.Contracts;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Swagger options
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});

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