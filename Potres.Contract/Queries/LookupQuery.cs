using MediatR;
using System.Collections.Generic;

namespace Potres.Contracting.Queries
{
  public abstract class LookupQuery<V> : IRequest<List<TextValue<V>>>
  {
      
  }

  public class AgenciesLookupQuery : LookupQuery<int> { }
  public class BidsLookupQuery : LookupQuery<int> { }
  public class BidItemsLookupQuery : LookupQuery<int> { }
  public class BusinessTypesLookupQuery : LookupQuery<int> { }
  public class CampaignsLookupQuery : LookupQuery<int> {
    public int? GroupId { get; set; }
  }
  public class CampaignGroupsLookupQuery : LookupQuery<int> { }
  public class ClientsLookupQuery : LookupQuery<int> { }
  public class ContractingsLookupQuery : LookupQuery<int> { }  
 
  public class InsertionsLookupQuery : LookupQuery<int> { }
  public class PartiesLookupQuery : LookupQuery<int> { }

  public class AgencyStatusesLookupQuery : LookupQuery<int> { }
  public class ClientStatusesLookupQuery : LookupQuery<int> { }
}
