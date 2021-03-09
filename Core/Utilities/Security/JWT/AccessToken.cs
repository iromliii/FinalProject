using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken //anlamsız karakterden oluşan karakter degerı,strıng olarak tutulur ve bıtış suresı vardır
        //token:jeton verırken ona tarıh verıyoruz (exprıatıon:Bıtış zamanı)
        

    {

        public string Token { get; set; }
        public DateTime Expiration { get; set; }


    }
}
