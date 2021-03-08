﻿using Business.Concrete;
using DataAccess.Concrete.EntıtıyFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            productTest();
            //IOS Contaıner
            //Dto e tıcaret sıstemınde urunun lıstesınde ılıskısel tablolardakı ısmını görüyoruz
            //CategoryTest();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
     
           

            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void productTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            var result = productManager.GetProductDetails();
            if (result.Success == true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + "/" +product.CategoryName);
                }         
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            foreach (var product in productManager.GetProductDetails().Data)
                //API lerde kontrol altına alınabılıyor
            {
                Console.WriteLine(product.ProductName + "/" + product.CategoryName);
            }
        }
        //verı erısım olarak entıtıyFramework kullanıyoruz
    }
}