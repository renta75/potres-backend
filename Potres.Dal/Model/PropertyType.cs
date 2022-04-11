using Potres.Contracting;
using System;
using System.Collections.Generic;

namespace Potres.Dal.Model
{
    public partial class PropertyType: IHasIntegerId
    {
        public PropertyType()
        {
        }

        public int Id { get; set; }
	    
        
	    public string name { get; set; }
	    
	    
        
	    public string regExp { get; set; }
	    
	    

        
    }
}