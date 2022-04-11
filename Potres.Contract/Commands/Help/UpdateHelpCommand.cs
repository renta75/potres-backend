using System;

using Potres.Contracting.DTOs;

namespace Potres.Contracting.Commands
{
  public class UpdateHelpCommand: UpdateCommand
  {
		
        
	    public int categoryId { get; set; }
	    
	    
        
	    public string title { get; set; }
	    
	    
        
	    public string description { get; set; }
	    
	    
        
	    public string contact { get; set; }
	    
	    
        
	    public int fieldsId { get; set; }
	    
	    
        
	    public decimal locationLat { get; set; }
	    
	    
        
	    public decimal locationLng { get; set; }
	    
	    
        
	    public int statusId { get; set; }
	    
	    
        
	    public DateTimeOffset createdDateTime { get; set; }
	    
	    
        
	    public DateTimeOffset editedDateTime { get; set; }
	    
	    
        
	    public string bulk { get; set; }
	    
	    

		
  }
}

