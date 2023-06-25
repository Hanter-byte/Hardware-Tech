using FastReport.Data;
using HardWareTech.DATA.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ControleManutencaoContext>(options =>
    options.UseSqlServer("Data Source=CIAN019401165\\SQLEXPRESS;Initial Catalog=ControleManutencao;Integrated Security=True; Trust Server Certificate=true"));

FastReport.Utils.RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));//Report

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

app.UseFastReport();// Report

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();