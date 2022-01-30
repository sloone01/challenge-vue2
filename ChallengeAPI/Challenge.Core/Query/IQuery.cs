using System.Linq;
using Challenge.Core.Context;
using Challenge.Core.Models;
using Microsoft.EntityFrameworkCore;


namespace Challenge.Core.Query
{
    public interface IQuery<T> where T : Entity
    {
        IOrderedQueryable<T> GetQuery();
        AppDbContext GetContext();
    }

    public abstract class QueryImpl<T> : IQuery<T> where T : Entity
    {
        protected readonly AppDbContext context;

        protected QueryImpl(AppDbContext ctx)
        {
            context = ctx;
        }

        public AppDbContext GetContext()
            => context;

        public abstract IOrderedQueryable<T> GetQuery();
    }

    public class StudentQuery : QueryImpl<student_record>
    {
        public StudentQuery(AppDbContext ctx) : base(ctx) {}
        public override IOrderedQueryable<student_record> GetQuery()
        =>  context.student_records
            .Include(x => x.class_record)
            .Include(x => x.country_record)
            .OrderBy(x => x.Id);
        
    }

    public class ClassQuery : QueryImpl<class_record>
    {
        public ClassQuery(AppDbContext ctx) : base(ctx) { }
        public override IOrderedQueryable<class_record> GetQuery()
        => context.class_records.OrderBy(x => x.Id);

    }

    public class CountryQuery : QueryImpl<country_record>
    {
        public CountryQuery(AppDbContext ctx) : base(ctx) { }
        public override IOrderedQueryable<country_record> GetQuery()
        => context.country_records.OrderBy(x => x.Id);

    }
}
