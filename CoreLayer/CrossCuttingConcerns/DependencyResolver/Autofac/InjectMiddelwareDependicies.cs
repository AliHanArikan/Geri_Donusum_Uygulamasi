using Autofac.Extensions.DependencyInjection;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace CoreLayer.CrossCuttingConcerns.DependencyResolver.Autofac
{

    public static class InjectMiddelwareDependicies
    {
       
        public static void ConfigureInjectDependiciesHandler(this IServiceCollection services)
        {
            
            


            string pathToAssembliesDaConcrete = @"C:\Users\li070\source\repos\LearnProject\DataAccessLayer\Concrete\";
            var allFilesDaC = Directory.GetFiles(pathToAssembliesDaConcrete, "*.dll");

            string pathToAssembliesDaAbstract = @"C:\Users\li070\source\repos\LearnProject\DataAccessLayer\Abstract\";
            var allFilesDaA = Directory.GetFiles(pathToAssembliesDaAbstract, "*.dll");

            string pathToAssembliesBlconcrete = @"C:\Users\li070\source\repos\LearnProject\BusinessLayer\Concrete\";
            var allFilesBlC = Directory.GetFiles(pathToAssembliesBlconcrete, "*.dll");

            string pathToAssembliesBlAbstract = @"C:\Users\li070\source\repos\LearnProject\BusinessLayer\Abstract\";
            var allFilesBlA = Directory.GetFiles(pathToAssembliesDaAbstract, "*.dll");

            var assembliesDaConcrete = allFilesDaC.Select(dosya => Assembly.LoadFrom(dosya)).ToArray();
            var assembliesDaAbstract = allFilesDaA.Select(dosya => Assembly.LoadFrom(dosya)).ToArray();
            var assembliesBlconcrete = allFilesBlC.Select(dosya => Assembly.LoadFrom(dosya)).ToArray();
            var assembliesBlAbstract = allFilesBlA.Select(dosya => Assembly.LoadFrom(dosya)).ToArray();
            
            var builder = new ContainerBuilder();
            var container = builder.Build();

            foreach (var assembly in assembliesDaConcrete)
            {
                builder.RegisterAssemblyModules(assembly);
            }


            foreach (var assembly in assembliesDaAbstract)
            {
                builder.RegisterAssemblyModules(assembly);
            }

            foreach (var assembly in assembliesBlconcrete)
            {
                builder.RegisterAssemblyModules(assembly);
            }

            foreach (var assembly in assembliesBlAbstract)
            {
                builder.RegisterAssemblyModules(assembly);
            }

           
        }

    }
}

       
 
