using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICategoryDal : IEntitityRepository<Category>
    {//generıcler deposıtory desıgn pattern (T)
        //ınterfaceın ıcı defoult publıc
        //cırcular dependency sonsuz bagımlılık
        //dependency baglılık  
    }
}
