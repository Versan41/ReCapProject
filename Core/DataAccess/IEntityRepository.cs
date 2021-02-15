using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    // --Generic Constraint(Genericleri Kısıtlama)--
    // class : referans tip olmalı demek
    // IEntity : T ya IEntity ya da IEntityden implemente olan bir nesne olmalı
    // new() : newlenebilir bir yapı olmalı
    public interface IEntityRepository<T> where T : class, IEntity, new() 
    {
        // Expression yapısı filtrelememize yardımcı oluyor.
        // filter = null filtre vermeyedebiliriz anlamında(filtre verilmezse tüm listeyi getirir)
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
