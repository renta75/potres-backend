using System;
using Potres.Contracting.DTOs;

namespace Potres.Contracting.Commands
{
  public class AddPropertyCommand: AddCommand
  {
    public int Id { get; set; }
		
        
	    public string name { get; set; }
	    
	    
        
	    public int propertyTypeId { get; set; }
	    
	    

		
	    public int HelpCategoryId { get; set; }
	    
  }
}
