using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SingingCredentialsHelper
    {
        public static SigningCredentials CreateSingingCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha512Signature);
           //sha 512 256 güçlendırılmış versıyonlar
           //hashıngHelper-hash oluşturma ve doğrulama
           //hesp oluşturururken hangı algorıtmayı kullandıgımız
           //doğrularken salt kullanarak karşılaştırılar
           //securıty key helper byte halıne getırıyor
           //bytenı alıp sımetrık anahtar halıne getırıyor
           //usercrıdentıal-kullanıcı bılgılerı

        }


    }
}
