using DataLayer.Models;
using DataLayer.Repository;
using Microsoft.EntityFrameworkCore;
using PatientManager.AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<PatientManagerContext>(options => {
    options.UseNpgsql("name=ConnectionStrings:connection");
});

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IRepository<Patient>, PatientRepository>();
builder.Services.AddScoped<IRepository<Diagnosis>, DiagnosisRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
