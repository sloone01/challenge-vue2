using Challenge.Core.Dtos;
using Challenge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Core.Services
{
    public interface IDbService<T>  where T : Entity
    {
        Task<long> GetLastId();
        Task<T> GetFirst(Expression<Func<T, bool>> predicate);
        Task<T> Find(Expression<Func<T, bool>> predicate);
        Task<T> Find(int id);
        Task<Response<T>> Delete(T entity);
        Task<List<T>> GetItems(Expression<Func<T, bool>> predicate, Int16 size = 0);
        Task<long> GetCount(Expression<Func<T, bool>> predicate);
        Task<Response<T>> AddItem(T entity);
        Task<bool> addRange(List<T> items);
        Task<Response<T>> UpdateEntity(T entity);
        Task<bool> UpdateRange(List<T> entityList);

    }
}
