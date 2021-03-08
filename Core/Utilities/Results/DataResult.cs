using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {//ctor tap tap
        public DataResult(T data,bool success,string message) : base (success,message)  
            //success ve resulttakı mesajı yazmak zorunda degılız
            // parametre olarak data verdık
        {   //resulttan farkı data olması
            Data=data;
            //base kullanmamızın nedenı Resultta zaten thıs dedık base and thıs ıc ıce calısır
        }
        public DataResult(T data,bool success):base(success)
        {
            Data=data;
        }
        public T Data { get; }
    }
    //Result bır class ve onu ınherıt edıyor dataResult sen bır resultsun
    //Onun constracterları ımplemen edılıyor
}
