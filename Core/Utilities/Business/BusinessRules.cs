using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{//Utılıty (araç) ıçınde method barındıran class,Utılıty oldugu ıcın class ın çıplakmkalması önemlı degıl
    //Overdesıgn olmaması ıcın 
    public class BusinessRules //javada method statıkse classda statık olmalı
                               //C# methodu statıc verırsek class statık kullanılır, başka method var ama statık degıl newlenmelı
    {//logics: iş kuralı , kuralları gez uymayan varsa döndür
        public static IResult Run(params IResult[] logics ) //yada lsıte yöntemı kullanılır
        {//Implementasyon,Lıst<IResut>
            //Lıst<IResult> errorResult = new Lıst<IResult>() :Foreach
            //return logıc: error.Result .Add(logıc)
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic; //error result döndürücek,kurala uymayan
                }
               //parametreyle gönderılen ış kurallarını busınessa  
            }
            return null;

        }

    }
}
