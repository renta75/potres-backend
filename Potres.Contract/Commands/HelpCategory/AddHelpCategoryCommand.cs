using System;
using Potres.Contracting.DTOs;

namespace Potres.Contracting.Commands
{
  public class AddHelpCategoryCommand: AddCommand
  {
    public int Id { get; set; }
		
        
	    public string name { get; set; }
	    
	    
        
	    public int propertiesId { get; set; }
	    
	    

		
  }
}
