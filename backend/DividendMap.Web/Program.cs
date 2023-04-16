using DividendMap.Web.Data;
using DividendMap.Web.Data.Adapters;
using DividendMap.Web.Domain.Ports;
using DividendMap.Web.Services.Adapters;
using DividendMap.Web.Services.Adapters.WebCrawler;
using DividendMap.Web.Services.Adapters.WebCrawler.StatusInvest;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("DividendsDb");
builder.Services.AddDbContext<DividendsContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IDividendLoader, DividendLoader>();
builder.Services.AddScoped<WebClient>();
builder.Services.AddScoped<ICrawler<DividendModel>, StatusInvestCrawler>();
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
