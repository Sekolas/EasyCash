 using EasyCashProject.BusinessLayer;
using EasyCashProject.BusinessLayer.Abstract;
using EasyCashProject.BusinessLayer.Concrete;
using EasyCashProject.DataAccessLayer.Abstract;
using EasyCashProject.DataAccessLayer.Concrete;
using EasyCashProject.DataAccessLayer.EntityFramework;
using EasyCashProject.EntityLayer.Concrete;
using EasyCashProject.PresentationLayer.Models;
using Microsoft.AspNetCore.Hosting;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation(); ;
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<Context>()
    .AddErrorDescriber<CustomIdentityValidator>();

builder.Services.LoadBusinessLayerExtension();

builder.Services.AddScoped<ICustomerAccountProcessDal, EfCustomerAccountProcessDal>();
builder.Services.AddScoped<ICustomerAccountProcessService, CustomerAccountProcessManager>();

builder.Services.AddScoped<ICustomerAccountDal, EfCustomerAccountDal>();
builder.Services.AddScoped<ICustomerAccountService, CustomerAccountManager>();

builder.Services.AddScoped<ICreditCardDal, EfCreditCardDal>();
builder.Services.AddScoped<ICreditCardService, CreditCardManager>();

builder.Services.AddScoped<INotificationDal, EfNotificationDal>();
builder.Services.AddScoped<INotificationService, NotificationManager>();

builder.Services.AddScoped<IContactDal, EfContactDal>();
builder.Services.AddScoped<IContactService, ContactManager>();

builder.Services.AddScoped<IElectricBillDal, EfElectricBillDal>();
builder.Services.AddScoped<IElectricBillService, ElectricBillManager>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
