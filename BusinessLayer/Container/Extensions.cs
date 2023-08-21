using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;
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

            Services.AddScoped<IExcelService, ExcelManager>();

            Services.AddScoped<IPdfService, PdfManager>();

            Services.AddScoped<IContactUsDal, EfContactUsDal>();
            Services.AddScoped<IContactUsService, ContactUsManager>();

            Services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();
            Services.AddScoped<IAnnouncementService, AnnouncementManager>();

        }

        public static void CustomValidator(this IServiceCollection Services)
        {
            Services.AddTransient<IValidator<AddAnnouncementDto>, AnnouncementValidator>();
            Services.AddTransient<IValidator<UpdateAnnouncementDto>, UpdateAnnouncementValidator>();
        }
    }
}
