using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        //Statık yapı
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductNameInvalid= "Ürün Ismi geçersiz";
        internal static string MaintanceTime= "Sıstem Bakımda";
        internal static string ProductsListed="Ürünler Lıstelendı";
        public static string ProductCountOfCategoryError= "Bır kategoride en fazla 10 urun olabılır";
        public static string ProductNameAlreadyExists = "Bu isimde zaten başka bir ürün var";
        internal static string CategoryLimitExceeded = "Kategori limiti aşıldığı için eklenemiyor";
        internal static string AuthorizationDenied= "Yetkınız yok";


        //Publıcler pascal case P... ıle başlar


    }
}
