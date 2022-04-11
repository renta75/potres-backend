using System;

namespace Potres.Contracting.DTOs
{
  public class PropertyDto : IHasIntegerId
  {
    public int Id { get; set; }
	
    
	public string name { get; set; }
	
	
    
	public int propertyTypeId { get; set; }
		public string propertyTypeName { get; set; }




		public int HelpCategoryId { get; set; }
	
  }
}
