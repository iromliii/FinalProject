using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntitityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
        //joın atmak ıcın bu operasyonu kullanıcaz
    }
}
