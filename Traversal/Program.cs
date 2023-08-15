using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Traversal.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityValidator>();

builder.Services.AddMvcCore(config =>
{
    var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddScoped<IDestinationDal,EfDestinationDal>();
builder.Services.AddScoped<IDestinationService,DestinationManager>();

builder.Services.AddScoped<IFeatureDal, EfFeatureDal>();
builder.Services.AddScoped<IFeatureService, FeatureManager>();

builder.Services.AddScoped<IFeature2Dal, EfFeature2Dal>();
builder.Services.AddScoped<IFeature2Service, Feature2Manager>();

builder.Services.AddScoped<IInfoDal, EfInfoDal>();
builder.Services.AddScoped<IInfoService, InfoManager>();

builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>();
builder.Services.AddScoped<ITestimonialService, TestimonialManager>();

builder.Services.AddScoped<ICommentDal, EfCommentDal>();
builder.Services.AddScoped<ICommentService, CommentManager>();

builder.Services.AddScoped<IReservationDal, EfReservationDal>();
builder.Services.AddScoped<IReservationService, ReservationManager>();

builder.Services.AddScoped<IGuideDal, EfGuideDal>();
builder.Services.AddScoped<IGuideService, GuideManager>();


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
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});


app.Run();
