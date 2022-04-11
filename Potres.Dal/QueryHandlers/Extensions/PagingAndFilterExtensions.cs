using Potres.Contracting;
using Potres.Contracting.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Potres.Dal.QueryHandlers.Extensions
{
  internal static class PagingAndFilterExtensions
  {
    public static IQueryable<T> ApplyPagingData<T>(this IQueryable<T> query, 
                                            PagingData pagingData, 
                                            Dictionary<string, Expression<Func<T, object>>> orderSelectors)
    {     
      string sort = pagingData?.Sort?.ToLower();
      if (!string.IsNullOrWhiteSpace(sort))
      {
        var order = orderSelectors[sort];
        if (order != null)
        {
          query = pagingData.Ascending ? query.OrderBy(order) : query.OrderByDescending(order);
        }
      }

      if (pagingData?.From != null)
      {
        query = query.Skip(pagingData.From.Value - 1);
      }

      if (pagingData?.Count != null)
      {
        query = query.Take(pagingData.Count.Value);
      }

      return query;      
    }

    public static IQueryable<T> ApplyFilterData<T>(this IQueryable<T> query,
                                            List<Filter> filters,
                                            Func<string, string, string, Expression<Func<T, bool>>> createWherePredicate)
    {
      if (filters != null)
      {
        foreach(var filter in filters)
        {
          var predicate = createWherePredicate(filter.Column, filter.Operator, filter.Value);
          if (predicate != null)
          {
            query = query.Where(predicate);
          }
        }
      }

      return query;
    }
  }
}
