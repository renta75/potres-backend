using System.Collections.Generic;

namespace Potres.Contracting.Queries
{
  public interface IHasFilterData
  {
    List<Filter> Filters { get; set; }
  }
}