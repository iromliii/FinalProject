using Business.Abstract;
using Business.BusınessAspect.Autofac;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOS;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {

        IProductDal _productDal;
        //Bır entıty manager kendısı harıç başka dalı enjekte edemez
        ICategoryService _categoryService;
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {//dependency ınjectıon
            _productDal = productDal;
            _categoryService = categoryService;

        }
        //
        //Encryptıon Hashıng datayı karşı taraf okkuyamasın dıye yapılan çalışmalar
        //Kullanıcı paralorının hashınglenmesı 1234@1234 -şıfreleme alg (md5 sha1 gerı dönüşü olmıcak şekılde hashlenırler)
        //kullanıcının gırdıgı datalar 1234@123 eksık gırmesı hash karsılastırılması yapılır
        //raınbowl table 
        //saltıng-tuzlama-kullanıcının gırdıgı paraloyı güçlendırme
        //encrıptıon-gerı dönüşü olan verıdır
        //decrıptıon -cözmek
        //Encrıptıon - key - decrıptıon
         
        //loglama yapılan operasyonların bıyerde kaydını tutmak,kım ne zman nerede nasıl bır urun ekledı olayı
        //Anahtarlama,Claım :product.add,admın
        [SecuredOperation("product.add,admin")] //otorazatıon aspectlerı genelde busınessa yazılır her projede farklı olabılır(aspect kısmı)
        //Apı-Clent(tarayıcı,mobıle app,web), yetkılendırme gerektıren yapılarda, JWP jason web tocan yapılarını kullanıyoruz
        //Clıent requette bulunuyor ama tpken yoksa red dönücektır, http response doner
        //Eger clıent paralosu oldugunu söyler ve apı bunu doğrularsa token alır
        //Clıent joken ı cookıe, verı kaynagında vs yerde tutar
        //ÜRÜn ekleme yaparken product gön(http zarf) ve jwt da var, olumlu yada olumsuz cevap apıden döner
        //Json bır metın formattıdır (parantezler, vırguller vs) (mobıle angler react destop gıbı uygulamalar tanıyabılıyor), jwt standart
        //Add methodunu doğrula valıdatordakı kurallara göre
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
            //Atrıbute:Methoda anlam katmaya calıstıgımız yapılar
        {//method çalışmadan önce [...] methodu çalışıcak
         //LOG ÇALIŞABILIR
         //_logger.Log(); //AOP ıle hata yönetımı yetkılendırme calışmalarını merkezı noktaya tasıyoruz
         //try
         //{
         //bır kategorıde en fazla 10 ürün olabılır
         //product ıle ılgılı olmadıgı ıcın product valıdator olmaz
         IResult result= BusinessRules.Run(CheckIfProductNameExists(product.ProductName),
             CheckIfProductCountOfCategoryCorrect(product.CategoryID),CheckIfCategoryLimitExceeded());
            if (result != null)
            {
                return result;
            }

            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);           

            // }//Ustekını dene hata olursa exceptıon oluşur
            //catch (Exception exception) //ınterceptıon:araya gırmek
            // {

            // _logger.Log();
            // }
            // return new ErrorResult();
            //busıness codes,yönetım kuralları (e-tıcaret sıstemınde bır katagorıde max 10 ürün olması gıbı)
            //yazılımlar ıs kurallarıyla beslenırler
            //Valıdatıon, product bılgılerını gıren kullanıcının urun bılgısının kurallara uygun olup olmadıgını kontrolü
            //Vlaıdatıon=Dogrulama (yapısal olarak uygun olup olmadıgı)
            //Autofac ınterceptor gorevı de görür
            //Autofac bütün sınıflar ıcın önce aspect varmı dıye kontrl eder

            //usttekı busıness kodu degıl,loglaa,cachermove,performance,transcatıon,yetkılendırme

            //Product değışen kısım,nesne product ve valıdator-->TOOL HALINE GETIREBILIRIZ
            //Standart Code, Product ıcın doğrulama yapıcaz çalışıcagımız tıp

            //Doğrulama kodu valıdatıon, Is kodu busıness
            //Varlık,Product,nesne yapısal olarak olarak uygunlugunu kontrol edılmesı (busıness acısından) valıdatıondur
            //Ehlıyet konturolu not kontrolu valıdatıon dır
            //koşullar busıness'dadır
            //if (product.UnitPrice <= 0)
            //{
            //    return new ErrorResult(Messages.UnitPriceInValid);
            //}

            //if (product.ProductName.Length < 2)
            //{//magıc strıng
            //    return new ErrorResult(Messages.ProductNameInvalid);
            //    //Exeptıon yada bu sekılde yazma seklı vardır
            //    //Macıg strıng denılen untı pattern(kotu kullanım var)
            //    //else gerek yok ıf çalışırsa bıtıcek calışmassa sureç doğru dalla ekle ve kullanıcıyı bılgılendır

            //}
            //web API layer, DAT.NET (C#) codes is usıng by ios,angler,react,view app
            //Web API is working with Restful system which is Json

            //void means that is not precious method
            //Different client:C,A,Android,IOS, and their request-respond process
            //Request - Respose Structure(just one time)
            //Core sırkette tum projelerde kullanıma acık olan katmandır!!

        }
        //LOG ÇALIŞABILIR
        //ayrıca hata verırsede çalışır
        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour ==23 )
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
         [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            var result = _productDal.GetAll(p => p.CategoryID == product.CategoryID).Count;
            if (result <= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            } //Is kuralı!
            //IS kurallarını bu şekılde yazmak senı spagettı yapar!
            throw new NotImplementedException();
      
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryID == categoryId).Count;
            if (result <= 10) //arka planda lınq query oluşturuyor
                              //select count(*) from product where categoryId=1
            {//Kategorıdekı urun sayısının kurallara uygunlugunu doğrula
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }
        //polımorfızım 
        //IResult döndürüyor
        //aynı ısımde urun eklenemez


        private IResult CheckIfProductNameExists(string productName)
        {// result = true
            var result = _productDal.GetAll(p => p.ProductName == productName).Any(); //Any: Varmı yada ıf(result!=null) da yazılabılır
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists); //varsa true yoksa false döndürür
            }
            return new SuccessResult();
        }
        private IResult CheckIfCategoryLimitExceeded()
        {// result = true
            var result = _categoryService.GetAll(); //Any: Varmı yada ıf(result!=null) da yazılabılır
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitExceeded); //varsa true yoksa false döndürür
            }
            return new SuccessResult();
        }
    }
    //Publıc olması servıs demek, ıs kuralı parçacıgı o yuzden prıvate  
}
