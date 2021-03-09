using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{//byte formatında vermek gerekkıyo
    //mysecretKey ı JWT anlayacagı hale getırmemız gerek
    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            //anahtarlar sımetrık ve asımetrık olarak ayrılıyor 
        }
    }
}
