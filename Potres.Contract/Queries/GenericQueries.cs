using MediatR;
using System.Collections.Generic;

namespace Potres.Contracting.Queries
{
  public class GetAllQuery<TDto> : FilterAndPagingQuery, IRequest<List<TDto>>
  {
  }

  //parametrizacija je ovdje bitna zbog DI-a i određivanja pravog queryhandlera
  public class GetCountQuery<TDto> : FilteredCountQuery { }

  public class GetSingleItemQuery<TDto> : IRequest<TDto>, IHasIntegerId
  {
    public int Id { get; set; }
    public GetSingleItemQuery(int id)
    {
      Id = id;
    }
  }
}
