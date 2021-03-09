using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class TokenOptions //helper class, mıcrosoft ıdentıty yapısıda aynı sekıl kulandı
                              //bu bır helper ıdentıty degıl o yuzden cogul normalde tekıl olur
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}
