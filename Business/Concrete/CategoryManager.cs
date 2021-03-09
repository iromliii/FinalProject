using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    { //Is kodları
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        { //ınterface olarak bagımlıyım 
            _categoryDal = categoryDal;
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>( _categoryDal.GetAll());
        }
        //select*from CategorICategoryDal _categoryDal where categoryId =3
        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c=>c.CategoryId == categoryId));
        }


        IDataResult<List<Category>> ICategoryService.GetAll()
        {
            throw new NotImplementedException();
        }

        IDataResult<Category> ICategoryService.GetById(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
