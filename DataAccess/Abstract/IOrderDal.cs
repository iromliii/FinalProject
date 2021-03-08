using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
 {//Orders tablo order her bır satır tekıl 
    public interface IOrderDal: IEntitityRepository<Order>
    {
    }
}
