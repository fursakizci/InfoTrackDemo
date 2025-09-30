using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using PropertyNormalizer.API.DataLayer.DataAccess;
using PropertyNormalizer.API.DataLayer.Repository;
using PropertyNormalizer.API.Services;
using PropertyNormalizer.API.Validation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("PropertyList"));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();
builder.Services.AddScoped<IPropertyService, PropertyService>();

builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<TitleDtoValidator>());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();