using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        public  SuccessResult(string message) : base(true, message)
        {

        }
        public SuccessResult() : base(true)
        {

        }
    }
}
//AOF methodların başında sonunda hata verdıgınde çalışmasını ıstedıgıız kodların loglanması
//Interceptıon bu olaya verılen ısımdır araya gırmek anlamındadır