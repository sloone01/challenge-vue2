
using Challenge.Core.Context;
using Challenge.Core.Dtos;
using Challenge.Core.Models;
using Challenge.Core.Query;
using Challenge.Core.Services;
using Challenge.Repos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Repos
{
    public class DbServiceImpl<T> : IDbService<T> where T : Entity
    {


        protected readonly AppDbContext context;
        protected readonly IOrderedQueryable<T> Query;

        public DbServiceImpl(IQuery<T> query)
        {
            Query = query.GetQuery();
            context = query.GetContext();
        }


        public async Task<Response<T>> AddItem(T entity)
        {
            context.Add(entity);
            try
            {
                var saveChangesAsync = await context.SaveChangesAsync();
                return saveChangesAsync > 0 ?
                    Response<T>.Success(await GetLastAdded()) :
                    Response<T>.Failure("Error while inserting");

            }
            catch (Exception e) {
                return Response<T>.Failure(e.InnerException != null ? e.InnerException.Message : e.Message);
            }
        }


        public async Task<Response<T>> UpdateEntity(T entity)
        {
            try
            {
                context.Entry(entity).CurrentValues.SetValues(entity);
                var count = await context.SaveChangesAsync();
                return count > 0
                    ? Response<T>.Success(await Find(entity.Id)) :
                   Response<T>.Failure("Error while Updating");
                   

            }
            catch (Exception e)
            {
                return Response<T>.Failure(e.Message + e.InnerException?.Message);
            }


        }

        public async Task<Response<T>> UpdateEntity(Expression<Func<T, bool>> predicate, T entity)
        {
            T t = await Find(predicate);
            context.Entry(t).CurrentValues.SetValues(entity);
            var count = await context.SaveChangesAsync();
            return count > 0 ? Response<T>.Success() : Response<T>.Failure("Error While Updating");
       }
      

        public async Task<T> GetLastAdded()
        {
            var lastId = await GetLastId();
            return await Find(x => x.Id == lastId);
        }


    public async Task<T> Find(int id) => await Query.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<Response<T>> Delete(T entity)
        {
            context.Remove(entity);
            int count = await context.SaveChangesAsync();
            return count > 0 ? Response<T>.Success() : Response<T>.Failure("Error While Deleting");
        }

        public async Task<T> Find(Expression<Func<T, bool>> predicate)
        => await Query.FirstOrDefaultAsync(predicate);
        public async Task<T> GetFirst(Expression<Func<T, bool>> predicate)
        => await Query.FirstOrDefaultAsync(predicate);
        public async Task<List<T>> GetItems(Expression<Func<T, bool>> predicate, Int16 size = 0)
        => size > 0 ? Query.Where(predicate).Take(size).ToList() :
        Query.Where(predicate).ToList();
        public async Task<long> GetLastId()
        => await Query.MaxAsync(x => x.Id);

        public async Task<long> GetCount(Expression<Func<T, bool>> predicate)
        => await Query.LongCountAsync(predicate);

        public async Task<bool> addRange(List<T> items)
        {
            //TODO we need to Add Transactional connection
            context.AddRange(items);
            var saveChangesAsync = await context.SaveChangesAsync();
            return saveChangesAsync == items.Count;
        }

        public async Task<bool> UpdateRange(List<T> entityList)
        {
            //TODO we need to Add Transactional connection
            context.UpdateRange(entityList);
            var saveChangesAsync = await context.SaveChangesAsync();
            return saveChangesAsync > 0;
        }

    

}
}
