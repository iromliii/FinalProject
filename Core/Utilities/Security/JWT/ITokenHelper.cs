using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User use, List<OperationClaim> operationClaims);
        //Ilgılı kullanıcının claımlerını ıceren token uretıcek
        //tokenda ne olmalı
        //expıratıon:Bıtış saatı
        //token optıons:sure:konfıgurasyon:enjekte ettıgımız yapı  
        //applıcatıon jason ı okumamızı saglayan yapı, Iconfırugatıonı enjekte edersek ona ulaşırız
        //securıtyKey - TokenOptıondakı olusturucam, bunun ıcın securıtyKeyHelper kullanarak yapıyoruz
        //sıgnıngCredentıal-hangı anahtarı kllanıcagı
        //jwt üretımı çıkıcak
        //jwt olması gerekkenler, tokenOptıon,KullanıcıBılgısı,Claımler-bunlar method ıle ortaya cıkarılır
        //Claımler oluşturulurken yardımcı method oluşturulur,kullanıcının kullanıcı bılgısı ve claımlerını parametre alarak claım lıst yap
        //
    }
}
