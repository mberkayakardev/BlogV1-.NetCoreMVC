using BlogApp.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BlogDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Local"));
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x=>
{
    x.Cookie.HttpOnly = true;
    x.Cookie.SameSite= SameSiteMode.Strict;

});


builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();



app.UseAuthentication();
app.UseAuthorization();


#region Eski yöntem

//app.UseEndpoints(endpoints =>
//{
//    //endpoints.MapAreaControllerRoute(name: "areaRoute", areaName: "Admin", pattern: "{Area}/{Controller=Category}/{Action=Index}/{id?}");
//    endpoints.MapControllerRoute(name: "area", pattern: "{Area}/{Controller=Category}/{Action=Index}/{id?}");
//    endpoints.MapDefaultControllerRoute();
//});
#endregion

#region Yeni Yöntem
app.MapAreaControllerRoute(name: "areaRoute", areaName: "Admin", pattern: "{Area}/{Controller=Category}/{Action=Index}/{id?}");
app.MapDefaultControllerRoute();
#endregion

app.Run();
