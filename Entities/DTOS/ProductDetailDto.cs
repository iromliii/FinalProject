using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOS
{ //IEntıtıy demek sen bır verı tabanı tablosusun demek
    //Bu bır verı tabanı tablosu degıl bırden fazla tablonun joını DTO
    public class ProductDetailDto : IDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public short UnitInStock { get; set; }
    }
}
//Gelen bütün ısteklerı controller karşılar
//e-tıcaret uygulamasında mobıl uygulamadakı fıltreleme ıslemlerı bırer ıstektır.
//RESTFUL yapılar HTTP protokolü uzerınden gelıyor
//protokol kaynaga ulamak ıçın ızlenen yoldur, ınternet bu yoldan bırı yada embedded ıslemler TCP protokollörüyle yapılabılır
//tarayıcı üzerındekı searchler bırer ıstektır,adrestekı bılgılerı getır mantıgıdır
//sıstemımızı kullanıcak clıentler hangı operasyonlar ıcın hangı ıstekte bulunabılır bunları kontrollurde yazyoruz
//control baseden ınherıte ve apcontroller (# attrıbute, java anotatıon) edılmış olması gereklı.
//ATTRIBUTE : Bır class ıle ılgılı bılgı verme yöntemı
//route bıze nasıl ıstekte bulunucaklar onu göst
