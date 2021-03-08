using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntýtýyFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        //Clýent server ýn hangý sevýyede yanýt verdýgýný söyler
        //servere ýstekte bulundugumuzda http statu codunu yorumlayýp code ýyýleþtýrýlýr

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {//Autofac,Nýnject,CastleWýndsor,StructureMap,LýghtInject,DryInJect-->Ioc Comtaýner
            services.AddControllers(); //býr bagýmlýlýk görürsen karþýlýðý budur
            services.AddSingleton<IProductService,ProductManager>(); //arka planda referans oluþtur,tüm bellekte 1 tane referans 
            services.AddSingleton<IProductDal,EfProductDal>();
            //Aop,Mütün methodlarý loglamak ýstedýgýmýzde logger servýse yerýne [LogAspect], busýness ýcýnde busýness yazma ýslemýdýr!
            //örnegýn velýdate et (urunlerý doðrula) yada RemoveCache(Ürün üklendýgýnde
            //yada Transactýonal (hata olursa gerý al (eft/havale))
            //Performance (zaman aþýmý hatasýnda uyarma)
            //BUTUN BU DURUMLAR AOP DIR (AUTOFAC AOP IMKANINI GUZEL BIR SEKILDE SUNAR)

            //ýcýnde data tutmayan yapýlarda kullanýyoruz
            //Mesela Sepet tutuyosak sepetýde managerda tutuyosak hersey karýsýr (e-týcaret)
        } //newleme yapýsý constracter ýcýn



        //AddTransýent
        //AddScorpe
        //Bu durum sadece API de degýl heryerde kullanýlabýlýcek olan býr yapý destup,webApý,mobýl uygulamada da kullanýlýr
        //apý buýld ýn ortam sunar kendýnde olan býr yapý

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
