using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplicationMvc.Data;
using WebApplicationMvc.Providers;
using WebApplicationMvc.Services.Payment;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<SiteProvider>();

builder.Services.Configure<VnPayParameter>(builder.Configuration.GetSection("Payment:VnPay"));
builder.Services.AddScoped<VnPayService>();

builder.Services.AddDbContext<EcommerceDbContext>(op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("ECommerceDb"));
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>(op =>
{
    op.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<EcommerceDbContext>()
    .AddDefaultTokenProviders();


builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddGoogle(options =>
    {
        options.ClientId = builder.Configuration["OAuth:Google:client_id"];
        options.ClientSecret = builder.Configuration["OAuth:Google:client_secret"];
        options.CallbackPath = "/signin-google";
    });

builder.Services.AddSession();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseSession();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();
app.MapDefaultControllerRoute();
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);
app.Run();