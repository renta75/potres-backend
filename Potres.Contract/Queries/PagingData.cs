namespace Potres.Contracting.Queries
{
  public class PagingData
  {
    public int? From { get; set; }
    public int? Count { get; set; }
    public string Sort { get; set; }
    public bool Ascending { get; set; }
  }
}
