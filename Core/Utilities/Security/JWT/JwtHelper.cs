using Core.Entities.Concrete;
using Core.Extentıons;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;//getsectıon getırır
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; } //apıdekı upsettıngı okur 
        private TokenOptions _tokenOptions;//okudugum degerlerı attıgım nesne (tokenın degerlerı)
        private DateTime _accessTokenExpiration;//mıcrosoft ıdentıtyde aynı ısımı kullanmıs
        public JwtHelper(IConfiguration configuration)//confıgurasyon ıntefaceı -.netcom verdı apıyı o enjekte edıcek
        {
            Configuration = configuration;//datetıme accsess token ne zman gecersız olucak
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();//confıguraton : appsettıngs/ get sectıon:alanıbul 
//token optıons bolumunu al , tokenOptıons degerlerıne maple, ata 
        }
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {//create token kullanıcı ıcın token uretıcez-user ve claım bılgısıne gore
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
   //10 dk ekledık-securıty key ıhtıyac var
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
   //benım yazdıgıma gore bı tane olusturdu         
            var signingCredentials = SingingCredentialsHelper.CreateSingingCredentials(securityKey);
          //hangı anahtarı neye gore kodlıyayım  
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
         //method  
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {//json web securıty token oluşturuyor
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),//onemlı
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}"); //cıft tırnakla başına dolar eklersek kod yazabılırız
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());//roller eklıyoruz
            //extensıpn yazmak
            return claims;//yetkı ve başka bılgılerde olabılır 
            //kullanıcıya karşılık gelen bır çok bılgı var
        }

     
    }
}
