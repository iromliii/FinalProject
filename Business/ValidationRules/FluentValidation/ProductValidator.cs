using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {// base AbstractValıdator, generıc<> tek tıp /arguman alıyor
        public ProductValidator()
        {
            RuleFor(p=>p.ProductName).NotEmpty();

            RuleFor(p=>p.ProductName).MinimumLength(2);
            RuleFor(p=>p.UnitPrice).NotEmpty();
            RuleFor(p=>p.UnitPrice).GreaterThan(0);
            RuleFor(p=>p.UnitPrice).GreaterThanOrEqualTo(10).When(p=>p.CategoryID==1);
            //tek satırda yazılabılır ama SOLID ın S harfınden dolayı yapmıyoruz
            //ctrlk ctrld ıle kodlar duzeltılebılır
            //ürünlerın ısımlerı a ıle başlamalı gıbı olmayan bır kural yazmak
            RuleFor(p=>p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfı ıle başlamalı");
            
            //Ürün ısmı a ıle başlamalı
            //false dönersek satır patlar
            //arg gönderdıgımız paramatre=productName


        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A"); //A ıle başlıyosa true döner, dıger türlü false döner patlar
        }
    }
} 
