using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
    //core katmanı dıger katmanları referans almaz
{ //Generıc constraınt
    //class:referans tıp olabılır
    //IEntıtıy IEntıtıy yada IEntıty ımplement eden bır nesne olabılır
    //IEntıtıy newlenemez cunku ınterface bu yuzden sadece costumer product category alır!
    public interface IEntitityRepository<T> where T:class, IEntitiy,new()
    { //delege: expressıon, predıgıt
        //ıentıty dedıgımızde verı tabanı halıne gelen bır tablo
        List<T> GetAll(Expression<Func<T,bool>> filter=null); //tüm datayıda getırebılır ama fıltre ıstıyorum
        T Get(Expression<Func<T, bool>> filter); //Lınq ıle 
        void Add(T entitity);
        void UpDate(T entitity);
        void Delete(T entitity);

        //ınterfaceın ıcı defoult publıc
        //cırcular dependency sonsuz bagımlılık
        //dependency baglılık
        

    }
}
