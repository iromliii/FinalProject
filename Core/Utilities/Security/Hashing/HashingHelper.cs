using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{//tool , çıplak kalabılır, methodlar statık olucak
    public class HashingHelper
    {
        public static void CreatePasswordHash
            (string password, out byte[] passwordHash, out byte[] passwordSalt)
        {//.net crıptografy sınıflarından yararlanıcaz,algorıtma secıh hash degerını oluşturucaz
            //dısposal pattern ıle gelıstırıcezz
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                //verdıgınız password degırını salt ve hash degerını oluşturuyor
            }


        }
        public static bool VerifyPasswordHash //verı tabını hashı karşılaştırılması
            (string password, byte[] passwordHash, byte[] passwordSalt) //doğrula passwordhash ı
        {//sonrasında gırılen paralo 
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                //oluşan değer byte array, referansları aynı degıl ama degerlerı aynımı control edılmelı
                for (int i=0; 1 <computedHash.Length; i++)
                {
                    if (computedHash[1] != passwordHash[1])
                    {
                        return false;
                    }

                }
            }
            return true;

        }
         
    }
 
}
