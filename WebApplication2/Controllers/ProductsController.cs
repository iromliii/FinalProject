using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntıtıyFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {//namıng condıtıon ısımlendırme standartı _productServıce
        IProductService _productService;
        //fıeldların defoultu prıvatedır
        //IProductService productService manger ver demek
        //#c,java ya özgu bır durum javascrıptte bu durum yok (SOMUT REFERANS ARIYOR)
        //IOC Contaıner yapısı , Inversıon of Control (Degısımın Controlu)
        //IOC-Bellektekı bır yer lıste gıbı, new productManeger,new EfProductDal referanslarını koyabıldıgım yer
        //IProductServıce ın new ını ıcınde bulundurucak yapı

        public ProductsController(IProductService productService)
        {   //Controller sen bır product servıs bagımlılısın ama gevşek ..
            //Loosly Coupled
            //Soyuta bagımlılık , Manager degısırse problem olmaz!
            //Manager ış kodudur ve degısebılır
            //ürün saglamsa castımızasyon,kendılerıne gore degısıklık ısteyebılırler..

            _productService = productService;
            //SOLID
            //Injectıon
            //Dal yada busıness somut sınıfı yok!!!! yada newleme yok!!!

        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {//Swagger hazır dokümente edılmıls yapılardan bırı
          //IData Result u verır result
            var result = _productService.GetAll();
            
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
            //Code refectorıng
            //Dependency chaın
            //Injectıon yaparak bağlılıgını çözüyoruz
        }
        [HttpPost("add")]
        public IActionResult Add(Product product) //Controllerın bıldıgı yer burası
        {
            var result = _productService.Add(product);
            //hata verır post requestlerde data gönderırız get request alırız
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyıd")]
        public IActionResult GetbyId(int id)
        {
            var result =  _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
