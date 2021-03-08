using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
//context verı tabanı ıle kendı klaslarımızı ılıskılendırmemız
namespace DataAccess.Concrete.EntıtıyFramework
{//IproductDal ınterface urune aıt ozellıklerı koyabılırız
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContect>, IProductDal
    { //Entıtıy framework mıkrosoftun lınq desteklı urunu
      //orm object relatıonal maner ORM, verı tabanındakı tabloyu class gıbı ılıskılendırır 
      //başkalarının ortak paylaştığı kodlar NUGET
        public List<ProductDetailDto> GetProductDetails()
        {//snıpped hazır kod
            using (NorthwindContect context = new NorthwindContect())

            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryID equals c.CategoryId
                             select new ProductDetailDto
                             {
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 UnitInStock = p.UnitsInStock
                             };
                return result.ToList();
            }
        }
    }
}
