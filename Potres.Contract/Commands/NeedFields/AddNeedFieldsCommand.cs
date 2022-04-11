using System;
using Potres.Contracting.DTOs;

namespace Potres.Contracting.Commands
{
  public class AddNeedFieldsCommand: AddCommand
  {
    public int Id { get; set; }
		
        
	    public int propertyId { get; set; }
	    
	    
        
	    public string value { get; set; }
	    
	    

		
	    public int NeedId { get; set; }
	    
  }
}
