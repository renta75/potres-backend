using System;
using Potres.Contracting.DTOs;

namespace Potres.Contracting.Commands
{
  public class AddPropertyTypeCommand: AddCommand
  {
    public int Id { get; set; }
		
        
	    public string name { get; set; }
	    
	    
        
	    public string regExp { get; set; }
	    
	    

		
  }
}
