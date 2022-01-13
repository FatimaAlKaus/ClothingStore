namespace Application.Common
{
    using System;
    using System.Linq;
    using System.Linq.Dynamic.Core;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public class DefaulQueryApplyer
    {
        public static async Task<PagedResult<T>> GetPagedResult<T>(QueryParameters.QueryParameters parameters, IQueryable<T> collection)
        {
            var filter = parameters.Filter;
            var orderBy = parameters.OrderBy;
            var takenNumber = parameters.PageSize;
            var skippedNumber = (parameters.PageNumber - 1) * parameters.PageSize;
            var queryable = collection;

            queryable = ApplyFiltering(filter, queryable);

            var totalItems = await queryable.CountAsync();

            queryable = ApplySorting(orderBy, queryable);

            queryable = queryable.Skip(skippedNumber).Take(takenNumber);

            return new PagedResult<T>()
            {
                PageCount = (totalItems + takenNumber - 1) / takenNumber,
                CurrentPage = parameters.PageNumber,
                Queryable = queryable,
                PageSize = takenNumber,
                RowCount = totalItems,
            };
        }

        private static IQueryable<T> ApplyFiltering<T>(string filter, IQueryable<T> collection)
        {
            if (!(string.IsNullOrEmpty(filter) || string.IsNullOrWhiteSpace(filter)))
            {
                try
                {
                    return collection.Where(filter);
                }
                catch
                {
                    throw new ArgumentException("Invalid argument", nameof(filter));
                }
            }

            return collection;
        }

        private static IQueryable<T> ApplySorting<T>(string orderBy, IQueryable<T> collection)
        {
            if (!(string.IsNullOrEmpty(orderBy) || string.IsNullOrWhiteSpace(orderBy)))
            {
                try
                {
                    return collection.OrderBy(orderBy);
                }
                catch
                {
                    throw new ArgumentException("Invalid argument", nameof(orderBy));
                }
            }

            return collection;
        }
    }
}
