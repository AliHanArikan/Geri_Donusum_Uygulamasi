using Autofac;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DependencyResolver.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfRecycableMaterialDal>().As<IRecycAbleMaterialDal>().SingleInstance();
            builder.RegisterType<RecycAbleMaterialManager>().As<IRecycAbleMaterialService>().SingleInstance();

            builder.RegisterType<EfSocialMediaDal>().As<ISocialMediaDal>();
            builder.RegisterType<SocialMediaManager>().As<ISocialMediaService>();

            builder.RegisterType<EfOfferDal>().As<IOfferDal>();
            builder.RegisterType<OfferManager>().As<IOfferService>();




            builder.RegisterType<LoggerManager>().As<ILoggerService>().SingleInstance();



        }
    }
}
//builder.Services.AddScoped<IOfferDal, EfOfferDal>();
//builder.Services.AddScoped<IOfferService, OfferManager>();
//builder.Services.AddScoped<ILoggerService, LoggerManager>();
//builder.Services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();
//builder.Services.AddScoped<ISocialMediaService, SocialMediaManager>();

