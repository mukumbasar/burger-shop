using ANK14.BurgerShop.BLL.Extensions;
using ANK14.BurgerShop.DAL.Extensions;
using ANK14.BurgerShop.Entities.Concretes;
using Microsoft.AspNetCore.Identity;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDALDependencies(builder.Configuration.GetConnectionString("CansinConString"));

builder.Services.AddBLLDependencies(Assembly.GetExecutingAssembly());

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{

    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
    var RoleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();


    await RoleManager.CreateAsync(new() { Name = "AppAdmin" });
    await RoleManager.CreateAsync(new() { Name = "AppClient" });

    await userManager.CreateAsync(new AppUser()
    {
        UserName = "AdminAdmin",
        Email = "admin@gmail.com",
        Name ="admin",
        Surname ="admin",
        Address ="admin"

    }, "adminadmin");

    await userManager.CreateAsync(new AppUser()
    {
        UserName = "cansin",
        Email = "cansin@gmail.com",
        Name = "cansin",
        Surname = "albayrak",
        Address = "cansin"

    }, "cansincansin");
    var adminUser = await userManager.FindByEmailAsync("admin@gmail.com");
    var user = await userManager.FindByEmailAsync("cansin@gmail.com");
    await userManager.AddToRoleAsync(adminUser, "AppAdmin");
    await userManager.AddToRoleAsync(user, "AppClient");
}

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
