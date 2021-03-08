using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolves.Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            //Bu conf�r�gasyon, .net alt yap�ndak� yap�y� kullanma autofac kullan
                .ConfigureContainer<ContainerBuilder>(builder=> { 

                builder.RegisterModule(new AutofacBusinessModule()); //.net core yer�ne ba�ka �oc modul kullanmak �sten�rse uygulan�cak modul
                    //yen� b�r dependency yap�c� �c�n,dpendency e yen� yap�y� kur usttek� autofact kodlar�n� deg�st�r!!
            
                })

                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
