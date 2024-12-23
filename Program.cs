using Microsoft.EntityFrameworkCore;
using Do_An.Models;

var builder = WebApplication.CreateBuilder(args);

// cấu hình dbcontext
builder.Services.AddDbContext<MovieContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();


// xác thực admin
builder.Services.AddAuthentication("AdminAuth").AddCookie("AdminAuth", options =>
{
    options.ExpireTimeSpan = TimeSpan.FromMinutes(1);
    options.LoginPath = "/Admin/dang-nhap";
    options.AccessDeniedPath = "/AccessDenied";
    options.ReturnUrlParameter = "returnURL";
});


// cấu hình cookie để lưu trữ phiên đăng nhập
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(1); // Thời gian hết hạn cookie
    options.Cookie.HttpOnly = true; 
    options.Cookie.IsEssential = true; 
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
app.UseRouting();

app.UseSession();
app.UseAuthentication();
app.UseAuthorization();


app.MapStaticAssets();


// admin
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

// route cho login admin
app.MapControllerRoute(
    name: "AdminLogin",
    pattern: "Admin/dang-nhap",
    defaults: new { controller = "Login", action = "Index", area = "Admin" });


// người dùng
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();



app.Run();
