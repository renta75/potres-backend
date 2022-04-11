using System;

using Potres.Contracting.DTOs;

namespace Potres.Contracting.Commands
{
  public class UpdatePropertyCommand: UpdateCommand
  {
		
        
	    public string name { get; set; }
	    
	    
        
	    public int propertyTypeId { get; set; }
	    
	    

		
	    public int HelpCategoryId { get; set; }
	    
  }
}

