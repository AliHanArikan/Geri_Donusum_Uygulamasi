using Autofac;
using Autofac.Extras.DynamicProxy;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.Identity.Client;
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

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors().SingleInstance();




            //var builder1 = new ContainerBuilder();

            //// Reflection kullanarak IBaseService arayüzüne sahip tüm manager sınıflarını bulma ve kayıt yapma
            //var assemblyy = System.Reflection.Assembly.GetExecutingAssembly();

            //var managerTypes = assembly.GetTypes()
            //    .Where(t => typeof(IBaseService).IsAssignableFrom(t) && t.Namespace == "BusinessLayer.Abstract");

            //var managerTypess = assembly.GetTypes()
            //    .Where(t => typeof(BaseManager).IsAssignableFrom(t) && t.Namespace == "BusinessLayer.Concrete");

            //foreach (var managerType in managerTypes)
            //{
            //    builder1.RegisterType(managerType).As<IBaseService>();
            //}

            //foreach (var managerType in managerTypess)
            //{
            //    builder1.RegisterType(managerType).As<BaseManager>(); // veya As<BaseManager> olarak kaydedin
            //}



            //var container = builder1.Build();

            //// Servisleri çözme
            //var services = container.Resolve<IEnumerable<IBaseService>>();
            //var baseManagers = container.Resolve<IEnumerable<BaseManager>>();


        }

    }

}
//builder.Services.AddScoped<IOfferDal, EfOfferDal>();
//builder.Services.AddScoped<IOfferService, OfferManager>();
//builder.Services.AddScoped<ILoggerService, LoggerManager>();
//builder.Services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();
//builder.Services.AddScoped<ISocialMediaService, SocialMediaManager>();

