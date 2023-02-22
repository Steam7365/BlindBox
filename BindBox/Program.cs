using Autofac;
using Autofac.Extensions.DependencyInjection;
using BindBox.DAO;
using BindBox.EF;
using BindBox.Models;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterType<CommdityDetailManager>().As<ICommdityDetailService>().InstancePerDependency();
    builder.RegisterType<GradeManager>().As<IGradeService>().InstancePerDependency();
    builder.RegisterType<StaffServiceManager>().As<IStaffService>().InstancePerDependency();
});
builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["Data:BindBox:ConnectionString"],b=>b.MigrationsAssembly("BindBox"));
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{id?}/{gid?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{gid?}");

app.Run();
