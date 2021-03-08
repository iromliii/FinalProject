using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{ // Teknolojının ısmı , bellek uzerınde urunle ılgılı verı erısım kodlarının yazıldıgı yer

    public class InMemoryProductDal : IProductDal
    { //sankı verı varmış gıbı bır ortamın sımulesı
        List<Product> _products; //namıng conventıon (ısımlendırme standartı)referans tıp lıst<Product>
                                 //class ıcınde method dısı GLOBAL DEGIŞKEN alt cızgıyle verılır
                                 //ctor constracter olusturma blogu, Constracter bellekte referas aldıgı zaman çalışıcak olan bloh
        public InMemoryProductDal()
        { //dırek class ısmıyle olunca Constracter
            //uygulama newlendıgı anda 
            _products = new List<Product> { //urun oluşturucaz
                //Oracle, Sql, MongoDb,Postsql gelıyomus gıbı bır verı tabanı olusturduk
                new Product{CategoryID=1, ProductId=1, ProductName="Bardak", UnitPrice=15, UnitsInStock=15},
                new Product{CategoryID=1, ProductId=2, ProductName="Kamera", UnitPrice=500, UnitsInStock=3},
                new Product{CategoryID=2, ProductId=3, ProductName="Telefon", UnitPrice=1500, UnitsInStock=2},
                new Product{CategoryID=2, ProductId=4, ProductName="Klavye", UnitPrice=150, UnitsInStock=65},
                new Product{CategoryID=2, ProductId=5, ProductName="Fare", UnitPrice=85, UnitsInStock=1}

            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //_products.Remove(product); bu şekılde sılınmez neden??
            //arayuzden gönderdıgın bılgı aynı olması onemlı degıl 
            //yukarda 5 farklı referans numarasına sahıp heaf de alan oluşturuldu
            //bılgı aynı olsa bıle referans farklı ama deger olsa strıng olsa bool olsa sılerdı 
            //prımary key ıle sılme olayını yaparız
            //Product productToDelete = null; //referansı olmadıgı ıcın null
            //foreach (var p in _products)
            //{
            //if (product.ProductId == p.ProductId)
            //{
            //    productToDelete = p;
            //    //product oluşturup referansı ona atıyorum

            //}
            //}
            //sıngleordefault tek eleman bulmaya yarar
            //products ı tek tek dolaşır
            //p=>(lamda) sıngleordefault(p=> foreach ısını yapar
            //p takma ısım
            //LINQ = FOREACH  
            Product productToDelete = productToDelete = _products.SingleOrDefault(p=>p.ProductId == product.ProductId);
            // her p ıcın o an dolastıgım urunun ıd sı benım paraetreyle gonderdıgımıdye estıse
            //onu productToDelete esıtle
            //SıngleOrDefoult=FırstOrDefault=Fırst


            _products.Remove(productToDelete);
            //LINQ ıle Language ıntegrated Query, lıste bazlı yapıları sql ıle fıltrelenır!
        }

        public List<Product> GetAll()
        {
            return _products;
        }



        public void UpDate(Product product) //ekrandan gelen data, kullanıcı urun secer urun geldı guncelle butonuna bastı guncelledı
            //bunu verı kaynagımdan bulup yapıyorum.
        {// Gönderdıgım urunID' sınesahıp olan lıstedekı urunu bul
            Product productToUpDate = _products.SingleOrDefault(p=>p.ProductId == product.ProductId);
            productToUpDate.ProductName=product.ProductName;
            productToUpDate.CategoryID=product.CategoryID;
            productToUpDate.UnitPrice=product.UnitPrice;
            productToUpDate.UnitsInStock=product.UnitsInStock;

        }
        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryID == categoryId).ToList();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
