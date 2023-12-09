using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Utilities.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> OrderByField<T>(this IQueryable<T> query, string fieldName, bool ascending)
        {
            var type = typeof(T);
            var parameter = Expression.Parameter(type, "p");
            var property = Expression.Property(parameter, fieldName);
            var lambda = Expression.Lambda(property, parameter);

            string methodName = ascending ? "OrderBy" : "OrderByDescending";
            var methodCallExpression = Expression.Call(
                typeof(Queryable),
                methodName,
                new Type[] { type, property.Type },
                query.Expression,
                Expression.Quote(lambda)
            );

            return query.Provider.CreateQuery<T>(methodCallExpression);
        }

    }
}
