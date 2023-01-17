using Microsoft.EntityFrameworkCore;
using BeanSceneSystem.Data;
using BeanSceneSystem.Services;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BeanSceneSystemDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BeanSceneSystem") ?? throw new InvalidOperationException("Connection string 'RetailWebSystemContext' not found.")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
       .AddEntityFrameworkStores<BeanSceneSystemDbContext>()
       .AddDefaultTokenProviders();

builder.Services.AddScoped<IMemberGuestServices, MemberGuestServices>();
builder.Services.AddScoped<IReservationServices, ReservationServices>();
builder.Services.AddScoped<IEventServices, EventServices>();
builder.Services.AddScoped<IUserService, UserService>();


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
