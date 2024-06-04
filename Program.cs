using backendP.Automappers;
using backendP.DTOs;
using backendP.Models;
using backendP.Repository;
using backendP.Services;
using backendP.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Cors;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder => {
        builder.WithOrigins("*");
        builder.WithMethods("GET", "POST","PUT","DELETE");
        builder.AllowAnyHeader();
    });
});


//inyeccion de servicio base de datos
builder.Services.AddDbContext<StoreContext>(options =>
{
options.UseSqlServer(builder.Configuration.GetConnectionString("StoreConnectionT"));
});
//inyeccion de servicio item
builder.Services.AddKeyedScoped<ICommonService<ItemDto, ItemInsertDto, ItemUpdateDto>, ItemService>("itemService");
//inyeccion de servicio Department
builder.Services.AddScoped<IDataService<DepartmentDto>, DepartmentService>();
//inyeccion de repositorios
builder.Services.AddScoped<IRepository<Item>,ItemRepository>();
builder.Services.AddScoped<IDepartmentRepository<Department>,DepartmentRepository>();
//inyeccion del automapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

//validators requiere inyeccion scoped que recibe un generic Ivalidator que a su vez recibe otro
//el cual es el dto que queremos validar y posteriormente la validacion
builder.Services.AddScoped<IValidator<ItemInsertDto>, ItemInsertValidator>();
builder.Services.AddScoped<IValidator<ItemUpdateDto>, ItemUpdateValidator>();

var app = builder.Build();

app.UseCors("origenes");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}




app.UseHttpsRedirection();
app.UseStaticFiles(); //
app.UseRouting(); // 
app.MapControllers();
app.UseCors();
app.UseAuthorization();
app.Run();

