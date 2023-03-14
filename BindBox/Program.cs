using Autofac;
using Autofac.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services.AddEndpointsApiExplorer();
//sagger
//builder.Services.AddSwaggerGen();

//web apiøÁ”Ú
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//“¿¿µ≈‰÷√
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterType<CommdityDetailManager>().As<ICommdityDetailService>().InstancePerDependency();
    builder.RegisterType<DescribeTypeManager>().As<IDescribeTypeService>().InstancePerDependency();
    builder.RegisterType<CommAndDescInfoManager>().As<ICommAndDescInfoService>().InstancePerDependency();
    builder.RegisterType<GradeManager>().As<IGradeService>().InstancePerDependency();
    builder.RegisterType<StaffServiceManager>().As<IStaffService>().InstancePerDependency();
    
});
// ˝æ›ø‚≈‰÷√
builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["Data:BindBox:ConnectionString"],b=>b.MigrationsAssembly("BindBox"));
});
//json∞¸≈‰÷√
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//sagger
//app.UseSwagger();
//app.UseSwaggerUI();

//øÁ”Ú
app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller}/{action}/{id?}/{gid?}");

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller}/{action}/{gid?}");

app.Run();
