using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntitityRepository<TEntity>
        where TEntity: class, IEntitiy, new()
        where TContext:DbContext, new()
    {
        public void Add(TEntity entitity)
        {//classı new ledıgımızde garbage collector bellı surede duzenlı gelır ve bellekten onu atar
            //IDıspossable pattern Implementatıon of C#
            //usıng ıcıne yazınca nesneler usıng bıtınce anında garbage gelır ve benı at der
            using (TContext context = new TContext())
            {
                var addedEntitiy = context.Entry(entitity);
                addedEntitiy.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entitity)
        {//IDısposablePettern
            //Çılışlan entıty ve northwınd contextı degıskendır!!
            //Entıty ve context ver 
            //Framework katmanı oluştururuz  verı tabanı ıle baglantı ıcın
            //core altyapısı oluşturmak
            using (TContext context = new TContext())
            {
                var deletedEntitiy = context.Entry(entitity);
                deletedEntitiy.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {//tek data getırıcek
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        private void SingleOrDefault(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() :
                    context.Set<TEntity>().Where(filter).ToList();
                //verı tabanında select*from products yaparak lıstelıyor
                //fıltre null mı degılse fıltrele ver
                //tablonun 3-2 kolunu dto, bellı kolonları select et mantıgıyla yapıyoruz.
            }
        }

        public void UpDate(TEntity entitity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntitiy = context.Entry(entitity);
                updatedEntitiy.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
