using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //IDispossable pattern implementation of C# - İş bitince Garbage Collector tarafından bellekten otomatik atılır 
            using (NorthwindContext context = new NorthwindContext())
            {
                var addedEntity = context.Entry(entity);    // Referansı yakala
                addedEntity.State = EntityState.Added;      // O eklenecek bir nesne
                context.SaveChanges();                      // Ve ekle
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity);      // Referansı yakala
                deletedEntity.State = EntityState.Deleted;      // O silinecek bir nesne
                context.SaveChanges();                          // Ve sil
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                //Filtre boş ise tüm listeyi ,değilse filtrelenen listeyi döndür 
                return filter == null
                    ? context.Set<Product>().ToList()
                    : context.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);        // Referansı yakala
                updatedEntity.State = EntityState.Modified;       // O güncellenecek bir nesne
                context.SaveChanges();                            // Ve güncelle
            }
        }
    }
}
