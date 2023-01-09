using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using WorkplaceReservation.Models;
using WorkplaceReservation.Repository.Context;
using WorkplaceReservation.Repository.Repositories.EmployeeRepository;
using WorkplaceReservation.Repository.Repositories.EquipmentForWorkplaceRepository;
using WorkplaceReservation.Repository.Repositories.EquipmentRepository;
using WorkplaceReservation.Repository.Repositories.ReservationRepository;
using WorkplaceReservation.Repository.Repositories.WorkplaceRepository;
using WorkplaceReservation.Service.Services.EmployeeService;
using WorkplaceReservation.Service.Services.EquipmentService;
using WorkplaceReservation.Service.Services.ReservationService;
using WorkplaceReservation.Service.Services.WorkplaceService;
using WorkplaceReservation.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<WorkplaceDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("WorkplaceConnectionString")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IWorkplaceRepository, WorkplaceRepository>();
builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();
builder.Services.AddScoped<IEquipmentForWorkplaceRepository, EquipmentForWorkplaceRepository>();

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IWorkplaceService, WorkplaceService>();
builder.Services.AddScoped<IEquipmentService, EquipmentService>();

builder.Services.AddFluentValidationAutoValidation(conf =>
{   
    conf.DisableDataAnnotationsValidation = true;
});

builder.Services.AddScoped<IValidator<EmployeeViewModel>, EmployeeValidator>();
builder.Services.AddScoped<IValidator<ReservationViewModel>, ReservationValidator>();
builder.Services.AddScoped<IValidator<WorkplaceViewModel>, WorkplaceValidator>();
builder.Services.AddScoped<IValidator<EquipmentViewModel>, EquipmentValidator>();
builder.Services.AddScoped<IValidator<EquipmentForWorkplaceViewModel>, EquipmentForWorkplaceValidator>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employee}/{action=Index}/{id?}");

app.Run();
