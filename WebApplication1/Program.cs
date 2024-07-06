using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ExpenseTracker_NguyenKimTien_21K4080052.Areas.Identity.Data;
using ExpenseTracker_NguyenKimTien_21K4080052.Data;
using ExpenseTracker_NguyenKimTien_21K4080052.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("WebApplication1DbContextConnection") ?? throw new InvalidOperationException("Connection string 'WebApplication1DbContextConnection' not found.");

builder.Services.AddDbContext<WebApplication1DbContext>(options =>
    options.UseSqlServer(connectionString));
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBMAY9C3t2U1hhQlJBfVhdX2RWfFN0QXNedV93flROcC0sT3RfQFljT3xUdkJhUXxacHxQRw==");

builder.Services.AddDefaultIdentity<WebApplication1User>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<WebApplication1DbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

// DI
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireUppercase = false;
});

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

// Ensure the routing is correctly set up to default to the login page
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");  

app.MapRazorPages();

app.Run();
