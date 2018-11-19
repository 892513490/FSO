using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FSO.Models;
using Microsoft.EntityFrameworkCore;

namespace FSO.Repository.Implements
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T:class
    {
        protected DbContext _context { get; }

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public virtual void Remove(T entry)
        {
            _context.Set<T>().Remove(entry);
            _context.SaveChanges();
        }

        public virtual void RemoveRange(IEnumerable<T> entrys)
        {
            _context.Set<T>().RemoveRange(entrys);
        }

        public virtual void Add(T entry)
        {
            _context.Set<T>().Add(entry);
            _context.SaveChanges();
        }

        public virtual void AddRange(IEnumerable<T> entrys)
        {
            _context.Set<T>().AddRange(entrys);
            _context.SaveChanges();
        }

        public virtual void Update(T entry)
        {
            _context.Set<T>().Update(entry);
            _context.SaveChanges();
        }

        public virtual void UpdateRange(IEnumerable<T> entrys)
        {
            _context.Set<T>().UpdateRange(entrys);
            _context.SaveChanges();
        }

        public virtual T FirstOrDefault(Expression<Func<T, bool>> predicate = null)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public virtual T SingleOrDefault(Expression<Func<T, bool>> predicate = null)
        {
            return _context.Set<T>().SingleOrDefault(predicate);
        }

        public int GetCount(Expression<Func<T, bool>> predicate = null)
        {
            return _context.Set<T>().Count(predicate);
        }

        public IList<TResult> GetList<TResult>(
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Expression<Func<T, TResult>> selector = null, 
            Expression<Func<T, bool>> predicate = null)
        {
            if (orderBy != null)
            {
                if (predicate != null)
                {
                    if (selector != null)
                    {
                        return orderBy(_context.Set<T>().AsNoTracking().Where(predicate))
                        .Select(selector).ToList();
                    }
                    else
                    {
                        return (IList<TResult>)orderBy(_context.Set<T>().AsNoTracking().Where(predicate)).ToList();
                    }
                }
                else
                {
                    if (selector != null)
                    {
                        return orderBy(_context.Set<T>().AsNoTracking())
                        .Select(selector).ToList();
                    }
                    else
                    {
                        return (IList<TResult>)orderBy(_context.Set<T>().AsNoTracking()).ToList();
                    }
                }
            }
            else
            {
                if (predicate != null)
                {
                    if (selector != null)
                    {
                        return _context.Set<T>().AsNoTracking().Where(predicate)
                        .Select(selector).ToList();
                    }
                    else
                    {
                        return (IList<TResult>)_context.Set<T>().AsNoTracking().Where(predicate).ToList();
                    }
                }
                else
                {
                    if (selector != null)
                    {
                        return _context.Set<T>().AsNoTracking()
                        .Select(selector).ToList();
                    }
                    else
                    {
                        return (IList<TResult>)_context.Set<T>().AsNoTracking().ToList();
                    }
                }
            }
        }

        public virtual IList<TResult> GetPage<TResult>(int pageIndex, int pageSize,
          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, 
          Expression<Func<T, TResult>> selector = null,
          Expression<Func<T, bool>> predicate = null)
        {
            int row = (--pageIndex) * pageSize;

            if (predicate != null)
            {
                if (selector != null)
                {
                    return orderBy(_context.Set<T>().AsNoTracking().Where(predicate))
                    .Skip(row)
                    .Take(pageSize)
                    .Select(selector).ToList();
                }
                else
                {
                    return (IList<TResult>)orderBy(_context.Set<T>().AsNoTracking().Where(predicate))
                    .Skip(row)
                    .Take(pageSize)
                    .ToList();
                }
            }
            else
            {
                if (selector != null)
                {
                    return orderBy(_context.Set<T>().AsNoTracking())
                    .Skip(row)
                    .Take(pageSize)
                    .Select(selector).ToList();
                }
                else
                {
                    return (IList<TResult>)orderBy(_context.Set<T>().AsNoTracking())
                    .Skip(row)
                    .Take(pageSize)
                    .ToList();
                }
                
            }
        }
    }
}
