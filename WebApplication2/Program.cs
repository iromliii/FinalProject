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
            //Bu confýrýgasyon, .net alt yapýndaký yapýyý kullanma autofac kullan
                .ConfigureContainer<ContainerBuilder>(builder=> { 

                builder.RegisterModule(new AutofacBusinessModule()); //.net core yerýne baþka ýoc modul kullanmak ýstenýrse uygulanýcak modul
                    //yený býr dependency yapýcý ýcýn,dpendency e yený yapýyý kur ustteký autofact kodlarýný degýstýr!!
            
                })

                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
