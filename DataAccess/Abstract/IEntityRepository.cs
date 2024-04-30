using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    // Generic Repository Design Pattern kullanımı. Tüm entityleri (product,category..) ayrı ayrı yazmamak için Generic Repo oluşturuldu.
    // generic constraint - generic kısıt -> where T:class 
    // class: Referans tip
    // IEntity: T referans tip olacak ya IEntity olacak veya onu implemente classlardan biri olacak
    // new () : new'lenebilir olmalı. Burda amaç sadece IEntity implemente eden classların kullanılmasına izin verme

    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        //Category , Ürün'e göre ayrı ayrı getir dememek için bu format oluşturuldu. 
        List<T> GetAll(Expression<Func<T, bool>> filter = null);

        //Tek bir detay getirmek için T tipinde bir Get operasyonu 
        T Get(Expression<Func<T, bool>> filter);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

    }
}
 