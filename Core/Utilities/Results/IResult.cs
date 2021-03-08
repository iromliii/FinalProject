using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{//Temel voidler için başlangıç
    public interface IResult //uygulamay kullanıcak kişileri doğru yönlendirme

    {
       bool Success { get; }

       string Message { get; }
        //başarılı mı başarısızmız (bool)
        //Message respods to client
        //bişey döndürmüyo
    }
}
