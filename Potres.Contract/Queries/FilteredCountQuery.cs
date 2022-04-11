using System.Collections.Generic;

namespace Potres.Contracting.Queries
{
  public class FilteredCountQuery : CountQuery, IHasFilterData
  {
    public List<Filter> Filters { get; set; }
  }
}
