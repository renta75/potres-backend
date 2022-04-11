using System;

namespace Potres.Contracting.DTOs
{
  public class HelpFieldsDto : IHasIntegerId
  {
    public int Id { get; set; }
	
    
	public int propertyId { get; set; }
		public string propertyName { get; set; }



		public string value { get; set; }
	
	

	
	public int HelpId { get; set; }
	
  }
}
