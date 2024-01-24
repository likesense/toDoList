using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks.Sources;
using toDoList.DAL;
using toDoList.DAL.Interfaces;
using toDoList.DAL.Repositories;
using toDoList.Domain.Entity;
using toDoList.Service.Implementation;
using toDoList.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();//check updates without refresh the project
//addService
//builder.Services.AddScoped<IBaseRepository<TaskEntity>, TaskRepository>();
//registerService
//builder.Services.AddScoped<ITaskService, TaskService>();

builder.Services.AddScoped<IBaseRepository<TaskEntity>, TaskRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();



var connectionString = builder.Configuration.GetConnectionString("MSSQL");//adding a connection string for mssql
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString); //connect to sqlserver
});


var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Task}/{action=Index}/{id?}");

app.Run();
