using Microsoft.EntityFrameworkCore;
using WorkplaceReservation.Repository.Context;
using WorkplaceReservation.Repository.Repositories.EmployeeRepository;
using WorkplaceReservation.Repository.Repositories.EquipmentForWorkplaceRepository;
using WorkplaceReservation.Repository.Repositories.EquipmentRepository;
using WorkplaceReservation.Repository.Repositories.ReservationRepository;
using WorkplaceReservation.Repository.Repositories.WorkplaceRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<WorkplaceDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("WorkplaceConnectionString")));

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IWorkplaceRepository, WorkplaceRepository>();
builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();
builder.Services.AddScoped<IEquipmentForWorkplaceRepository, EquipmentForWorkplaceRepository>();


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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
