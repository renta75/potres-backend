using System;

using Potres.Contracting.DTOs;

namespace Potres.Contracting.Commands
{
  public class UpdateNeedFieldsCommand: UpdateCommand
  {
		
        
	    public int propertyId { get; set; }
	    
	    
        
	    public string value { get; set; }
	    
	    

		
	    public int NeedId { get; set; }
	    
  }
}

