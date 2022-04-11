using System;

namespace Potres.Contracting.DTOs
{
  public class NeedDto : IHasIntegerId
  {
    public int Id { get; set; }
	
    
	public int categoryId { get; set; }
		public string categoryName { get; set; }



		public string title { get; set; }
	
	
    
	public string description { get; set; }
	
	
    
	public string contact { get; set; }
	
	
    
	public int fieldsId { get; set; }
	
	
    
	public decimal locationLat { get; set; }
	
	
    
	public decimal locationLng { get; set; }
	
	
    
	public int statusId { get; set; }
		public string statusName { get; set; }



		public DateTimeOffset createdDateTime { get; set; }
	
	
    
	public DateTimeOffset editedDateTime { get; set; }
	
	
    
	public string bulk { get; set; }
	
	

	
  }
}
