using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{//ınterface 
    public interface IDataResult<T>:IResult //hangı tıpı döndürücegını söyle
    {//Generıcle ne olucagını belırtıyoruz
        T Data { get;  }
    }
}
