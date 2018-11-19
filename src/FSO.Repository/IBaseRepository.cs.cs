using FSO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FSO.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        void Add(T entry);

        void AddRange(IEnumerable<T> entrys);

        void Update(T entry);

        void UpdateRange(IEnumerable<T> entrys);

        void Remove(T entry);

        void RemoveRange(IEnumerable<T> entrys);

        T FirstOrDefault(Expression<Func<T, bool>> predicate = null);

        T SingleOrDefault(Expression<Func<T, bool>> predicate = null);

        int GetCount(Expression<Func<T, bool>> predicate = null);

        IList<TResult> GetList<TResult>(
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
          Expression<Func<T, TResult>> selector = null,
          Expression<Func<T, bool>> predicate = null);

        IList<TResult> GetPage<TResult>(int pageIndex, int pageSize,
          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
          Expression<Func<T, TResult>> selector = null,
          Expression<Func<T, bool>> predicate = null);
    }
}
