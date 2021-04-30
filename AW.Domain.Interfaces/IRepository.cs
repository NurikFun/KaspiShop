using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AW.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetList();
        IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate);
        void Update(TEntity entity);
        void Create(TEntity entity);
        void Save();
    }
}
