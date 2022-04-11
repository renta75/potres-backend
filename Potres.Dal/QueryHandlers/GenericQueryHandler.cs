using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Potres.Contracting;
using Potres.Contracting.Commands;
using Potres.Contracting.Queries;
using Potres.Dal.Model;
using Potres.Dal.QueryHandlers.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Potres.Dal.QueryHandlers
{
  public abstract class GenericQueryHandler<TModel, TDtoSingle, TDtoInList>:
                                    IRequestHandler<GetAllQuery<TDtoInList>, List<TDtoInList>>,
                                    IRequestHandler<GetCountQuery<TDtoInList>, int>,
                                    IRequestHandler<GetSingleItemQuery<TDtoSingle>, TDtoSingle>
    where TModel : class    
  {
    protected readonly PotresContext ctx;
    protected readonly ILogger logger;

    protected abstract Expression<Func<TModel, TDtoSingle>> SelectorSingle { get;  }
    protected abstract Expression<Func<TModel, TDtoInList>> SelectorInList { get; }
    protected abstract Dictionary<string, Expression<Func<TModel, object>>> OrderSelectors { get; }
    protected virtual Dictionary<string, Expression<Func<TModel, object>>> WherePredicates => OrderSelectors;
    protected abstract Expression<Func<TModel, bool>> CreatePKPredicate(int value);

    protected virtual Expression<Func<TModel, bool>> CreateGlobalSearchPredicate(string text) { return null; }

    protected GenericQueryHandler(PotresContext ctx, ILogger logger)
    {
      this.ctx = ctx;
      this.logger = logger;
    }

    //get single item
    public async Task<TDtoSingle> Handle(GetSingleItemQuery<TDtoSingle> request, CancellationToken cancellationToken)
    {
      var item = await ctx.Set<TModel>()
                          .Where(CreatePKPredicate(request.Id))
                          .Select(SelectorSingle)
                          .FirstOrDefaultAsync();
      return item;
    }

    //Get all items
    public async Task<List<TDtoInList>> Handle(GetAllQuery<TDtoInList> request, CancellationToken cancellationToken)
    {
      var query = ctx.Set<TModel>().AsQueryable();
      if (request is IHasFilterData)
      {
        query = query.ApplyFilterData(((IHasFilterData)request).Filters, CreateWherePredicate);
      }
      if (request is IHasPagingData)
      {
        query = query.ApplyPagingData(((IHasPagingData)request).PagingData, OrderSelectors);
      }      
      var list = await query.Select(SelectorInList).ToListAsync();
      return list;
    }

    //Get item counts
    public async Task<int> Handle(GetCountQuery<TDtoInList> request, CancellationToken cancellationToken)
    {
      var query = ctx.Set<TModel>().AsQueryable();
      if (request is IHasFilterData)
      {
        query = query.ApplyFilterData(((IHasFilterData)request).Filters, CreateWherePredicate);
      }      
      int count = await query.CountAsync();
      return count;
    }

    protected virtual Expression<Func<TModel, bool>> CreateWherePredicate(string field, string @operator, string value)
    {
      if (field != "global")
      {
        var expression = WherePredicates[field.ToLower()];
        if (expression == null)
        {
          logger.LogWarning($"Unknown filter field: {field} with value {value} in {this.GetType().Name}");
          return null;
        }
        else
        {
          var predicate = expression.BuildWherePredicate(value, @operator, logger);
          return predicate;
        }
      }
      else
      {
        return CreateGlobalSearchPredicate(value);        
      }
    }
  }
}
