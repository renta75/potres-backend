using Potres.Contracting;
using System;
using System.Collections.Generic;

namespace Potres.Dal.Model
{
    public partial class HelpFields: IHasIntegerId
    {
        public HelpFields()
        {
        }

        public int Id { get; set; }
	    
        
	    public int propertyId { get; set; }
        public virtual Property Property { get; set; }



        public string value { get; set; }
	    
	    

        
	    public int HelpId { get; set; }
	    
    }
}