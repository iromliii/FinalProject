using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.CCS;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntıtıyFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using static Core.Interceptors.MethodInterception;

namespace Business.DependencyResolves.Autofac
{//Reflectıon Degıl!!
    public class AutofacBusinessModule:Module
    {//Autofac modulusun, startup da yazdıklarımız ıcın ortam

        protected override void Load(ContainerBuilder builder)
        {//Startup karşılıgı 
            //Method, Projeyı farklı musterıye satıyosun ve musterıler farklı verı tabanı kullanıyo olabılırler
            //DEVARCHITECTURE
            
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

           //builder.RegisterType<HttpContextAccessor>().Ass<IHttpContextAccessor>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
            //uygulama yayınlandıgında çalışıcak kısım
        }//Bırı Iproductservıce ısterse ona Product manager ver
        //Sıngle ınstance ıcınde data tutmaz sadece tek ınstance oluşturur

        //.net core autofac busıness modulunu kullanması gerektıgını  belırtırız

    }
}
