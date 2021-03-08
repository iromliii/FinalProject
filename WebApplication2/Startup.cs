using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Ent�t�yFramework;
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
        //Cl�ent server �n hang� sev�yede yan�t verd�g�n� s�yler
        //servere �stekte bulundugumuzda http statu codunu yorumlay�p code �y�le�t�r�l�r

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {//Autofac,N�nject,CastleW�ndsor,StructureMap,L�ghtInject,DryInJect-->Ioc Comta�ner
            services.AddControllers(); //b�r bag�ml�l�k g�r�rsen kar��l��� budur
            services.AddSingleton<IProductService,ProductManager>(); //arka planda referans olu�tur,t�m bellekte 1 tane referans 
            services.AddSingleton<IProductDal,EfProductDal>();
            //Aop,M�t�n methodlar� loglamak �sted�g�m�zde logger serv�se yer�ne [LogAspect], bus�ness �c�nde bus�ness yazma �slem�d�r!
            //�rneg�n vel�date et (urunler� do�rula) yada RemoveCache(�r�n �klend�g�nde
            //yada Transact�onal (hata olursa ger� al (eft/havale))
            //Performance (zaman a��m� hatas�nda uyarma)
            //BUTUN BU DURUMLAR AOP DIR (AUTOFAC AOP IMKANINI GUZEL BIR SEKILDE SUNAR)

            //�c�nde data tutmayan yap�larda kullan�yoruz
            //Mesela Sepet tutuyosak sepet�de managerda tutuyosak hersey kar�s�r (e-t�caret)
        } //newleme yap�s� constracter �c�n



        //AddTrans�ent
        //AddScorpe
        //Bu durum sadece API de deg�l heryerde kullan�lab�l�cek olan b�r yap� destup,webAp�,mob�l uygulamada da kullan�l�r
        //ap� bu�ld �n ortam sunar kend�nde olan b�r yap�

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
