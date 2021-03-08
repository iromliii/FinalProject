using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using DataAccess.Abstract;
using DataAccess.Concrete.EntıtıyFramework;
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
