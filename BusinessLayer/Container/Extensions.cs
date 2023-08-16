using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Container
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection Services)
        {
            Services.AddScoped<IDestinationDal, EfDestinationDal>();
            Services.AddScoped<IDestinationService, DestinationManager>();

            Services.AddScoped<IFeatureDal, EfFeatureDal>();
            Services.AddScoped<IFeatureService, FeatureManager>();

            Services.AddScoped<IFeature2Dal, EfFeature2Dal>();
            Services.AddScoped<IFeature2Service, Feature2Manager>();

            Services.AddScoped<IInfoDal, EfInfoDal>();
            Services.AddScoped<IInfoService, InfoManager>();

            Services.AddScoped<ITestimonialDal, EfTestimonialDal>();
            Services.AddScoped<ITestimonialService, TestimonialManager>();

            Services.AddScoped<ICommentDal, EfCommentDal>();
            Services.AddScoped<ICommentService, CommentManager>();

            Services.AddScoped<IReservationDal, EfReservationDal>();
            Services.AddScoped<IReservationService, ReservationManager>();

            Services.AddScoped<IGuideDal, EfGuideDal>();
            Services.AddScoped<IGuideService, GuideManager>();

            Services.AddScoped<IAppUserDal, EfAppUserDal>();
            Services.AddScoped<IAppUserService, AppUserManager>();
        }
    }
}
