using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntıtıyFramework
{//Generıc yapılar temelı oluşturur
    public class EfCategoryDal : EfEntityRepositoryBase<Category, NorthwindContect>, ICategoryDal
    {
       


    }
}
