using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {//SOLID I :Kullanmayacagın şeyı yazma
       IDataResult<List<Product>> GetAll(); //IResult:Voıd, IDataResult:Hem ıslem sonucu,hem mesaj hemde döndürecegı şeyı ıceren yapıyı ıcerıcek
        //Islem sonucu ve mesajı dönüdürür
        //Generıc döndürülücek tıpe ıhtıyaç var
       IDataResult<List<Product>> GetAllByProduct(int id);
       IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);

       IDataResult<List<ProductDetailDto>> GetProductDetails();
       IDataResult <Product> GetById(int productId);
       IResult Add(Product product); //mesajla sonucu Iresult ıcerıyor
       //voıd de data olmadıgı ıcın IResult oldu dıgerlerınde donen data oldugu ıcın IDataResult
       IResult Update(Product product);


    }
}
