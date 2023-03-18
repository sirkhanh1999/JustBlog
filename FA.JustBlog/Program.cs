using Entity.Context;
using Entity.Entity;
using FA.JustBlog.Services.CategoryService;
using FA.JustBlog.Services.CommentService;
using FA.JustBlog.Services.PostService;
using FA.JustBlog.Services.TagService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using Repository;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");
try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    // Config DbContext
    var connectionString = builder.Configuration.GetConnectionString("JustBlogConnection");
    builder.Services.AddDbContext<JustBlogContext>(x => x.UseSqlServer(connectionString));

    //Config Identity
    builder.Services.AddIdentity<User, Role>()
        .AddEntityFrameworkStores<JustBlogContext>()
        .AddDefaultTokenProviders(); ;

    //Declare DI
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    builder.Services.AddScoped<IPostService, PostService>();
    builder.Services.AddTransient<ITagService, TagService>();
    builder.Services.AddTransient<ICategoryService, CategoryService>();
    builder.Services.AddTransient<ICommentService, CommentService>();

    builder.Services.AddControllersWithViews();

    builder.Services.AddRazorPages();

    builder.Services.AddMvc(options =>
    {
        options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
    });

    // Truy cập IdentityOptions - Cấu hình Identity
    builder.Services.ConfigureApplicationCookie(options =>
    {
        options.LoginPath = "/admin/login";
        options.AccessDeniedPath = new PathString("/unauthorized");
    });
    builder.Services.Configure<IdentityOptions>(options =>
    {
        // Thiết lập về Password
        options.Password.RequireDigit = false; // Không bắt phải có số
        options.Password.RequireLowercase = false; // Không bắt phải có chữ thường
        options.Password.RequireNonAlphanumeric = false; // Không bắt ký tự đặc biệt
        options.Password.RequireUppercase = false; // Không bắt buộc chữ in
        options.Password.RequiredLength = 6; // Số ký tự tối thiểu của password
        options.Password.RequiredUniqueChars = 1; // Số ký tự riêng biệt

        // Cấu hình Lockout - khóa user
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Khóa 5 phút
        options.Lockout.MaxFailedAccessAttempts = 5; // Thất bại 5 lầ thì khóa
        options.Lockout.AllowedForNewUsers = true;

        // Cấu hình về User.
        options.User.AllowedUserNameCharacters = // các ký tự đặt tên user
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
        options.User.RequireUniqueEmail = true;  // Email là duy nhất

        // Cấu hình đăng nhập.
        options.SignIn.RequireConfirmedEmail = false;           // Cấu hình xác thực địa chỉ email (email phải tồn tại)
        options.SignIn.RequireConfirmedPhoneNumber = false;     // Xác thực số điện thoại
    });

    var app = builder.Build();
    #region
    // Configure the HTTP request pipeline.

    //app.UseExceptionHandler(c => c.Run(async context =>
    //{
    //    var exception = context.Features
    //        .Get<IExceptionHandlerPathFeature>()
    //        .Error;
    //    var response = new { error = exception.Message };
    //    await context.Response.WriteAsJsonAsync(response);
    //}));
    //app.UseExceptionHandler("/NotFound");
    //app.Use(async (context, next) =>
    //{
    //    await next();
    //    if (context.Response.StatusCode == 404)
    //    {
    //        context.Request.Path = "/NotFound";
    //        await next();
    //    }
    //});
    #endregion

    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/NotFound");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapAreaControllerRoute(
            name: "Admin",
            areaName: "Admin",
            pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

        endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
    });

    app.Run();
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}