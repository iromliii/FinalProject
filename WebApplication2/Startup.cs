using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntýtýyFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
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
            //services.AddSingleton<IProductService,ProductManager>(); //arka planda referans oluþtur,tüm bellekte 1 tane referans 
            //services.AddSingleton<IProductDal,EfProductDal>();
            //Aop,Mütün methodlarý loglamak ýstedýgýmýzde logger servýse yerýne [LogAspect], busýness ýcýnde busýness yazma ýslemýdýr!
            //örnegýn velýdate et (urunlerý doðrula) yada RemoveCache(Ürün üklendýgýnde
            //yada Transactýonal (hata olursa gerý al (eft/havale))
            //Performance (zaman aþýmý hatasýnda uyarma)
            //BUTUN BU DURUMLAR AOP DIR (AUTOFAC AOP IMKANINI GUZEL BIR SEKILDE SUNAR)
            //ýnterfaceler referans tutucu,newlenemez
            //ýcýnde data tutmayan yapýlarda kullanýyoruz
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });





            //Mesela Sepet tutuyosak sepetýde managerda tutuyosak hersey karýsýr (e-týcaret)
        } //newleme yapýsý constracter ýcýn

        //AOF yapabýlmek ýcýn Autofac kullanarak ýnterface yapýyoruz busonessda eþleþtýrdýgýmýz kodlarý

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
