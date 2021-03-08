using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {

        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {//busıness codes
            if (product.ProductName.Length < 2)
            {//magıc strıng
                return new ErrorResult(Messages.ProductNameInvalid);
                //Exeptıon yada bu sekılde yazma seklı vardır
                //Macıg strıng denılen untı pattern(kotu kullanım var)
                //else gerek yok ıf çalışırsa bıtıcek calışmassa sureç doğru dalla ekle ve kullanıcıyı bılgılendır

            }
            //web API layer, DAT.NET (C#) codes is usıng by ios,angler,react,view app
            //Web API is working with Restful system which is Json
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
            //void means that is not precious method
            //Different client:C,A,Android,IOS, and their request-respond process
            //Request - Respose Structure(just one time)
            //Core sırkette tum projelerde kullanıma acık olan katmandır!!

        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour ==14 )
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintanceTime);
            }
            //Is kodu (ıf)
            //yetkısı varmı?
            //ıs sınıfı başka sınıfları newlemez
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByProduct(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.CategoryID==id));
        }//Success data result ıcınde product var onun constracter ının _productdal gönderıyor

        public IDataResult<Product> GetById(int productId)
        {//predicet yapı p=>...
            return new SuccessDataResult<Product>( _productDal.Get(p=>p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>> (_productDal.GetAll(p=>p.UnitPrice<= min && p.UnitPrice<=max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>( _productDal.GetProductDetails());
        }

    }
}
