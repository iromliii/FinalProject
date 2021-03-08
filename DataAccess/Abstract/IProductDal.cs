using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{ //ınterfacede de public olucak!! Interfaceın operasyonları publıc kendısı degıl!!
    public interface IProductDal : IEntitityRepository<Product>
    { //ınterface-
      //entitity(tablo)-
        List<ProductDetailDto>GetProductDetails();
        //Dal(Katman)(data access layer)/Dao(java)(data access object) hangı katmanın kodu    
    }

}
