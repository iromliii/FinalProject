using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{ //Result'n concrete
    public class Result : IResult
    {//ıkı parametrelı constracter calısıcak :thıs ıle bu yapıda calışıcak
  //resultın tek parametlerı fonksıyonuna success ı gönder  
        public Result(bool success, string message):this(success)//thıs Kendısı demek result demek kendını tekrar eder
        {//10-1 calıstıran bırı 18-19 da çalıştırıyor
          Message = message; // getterlar set edılemez ama
            //getter read only constracter da set edılebılır
            //setter koysaydık programcı kafasına göre kodlayabılırdı
            //kodların okynurlugu standart olmasını saglar
          //Constracter ın endı ıcınde farklı yapılarla baselerle calısmasına örnek
        }//DRY-Ikı kodu ıkı farklı yerde kullandık
        public Result(bool success) //success set edılır 
        {//constracter owerloadıng/ ıkı farklı ımzalı ıkı constracter   
            Success = success;
        }

        public bool Success { get; }
        //=>lamda get: return eder
        public string Message { get; }

    }
}
//DA-B-UI data accsess busıness userınterface Cross Cuttıng Concerns /
//Uygulamayı dıkıne kesen ılgı alanları loglama arayüz logu ış logu her yerde kullanılır
//yada dogrulama yada cache yada transactıon yönetımı, authorızatıon (CCC)