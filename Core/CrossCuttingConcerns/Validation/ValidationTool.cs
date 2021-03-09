using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    public class ValidationTool
    {//Ivalıdator verıyoduk (Ilgılı methodun parametrelerını valıdate etmek ıstedıgımız kuralların oldugu class
     // bır Ivalıdator:productValıdator:Dogrula kuralları classı ve dogrulama:valıdator productıcın varlık
     //valıdatıon dogrulama oldugu ıcın method basında yapılır
        
        
        public static void Validate(IValidator validator,object entitiy)
        {//Refector -Evrensel kullanılıcak hale getırılıcek
            var context = new ValidationContext<object>(entitiy);
            
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
