using Potres.Contracting;
using System;
using System.Collections.Generic;

namespace Potres.Dal.Model
{
    public partial class Help: IHasIntegerId
    {
        public Help()
        {
        }

        public int Id { get; set; }
	    
        
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

		public virtual Status Status { get; set; }

		public virtual HelpCategory Category { get; set; }




	}
}