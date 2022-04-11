using Potres.Contracting;
using System;
using System.Collections.Generic;

namespace Potres.Dal.Model
{
    public partial class NeedFields: IHasIntegerId
    {
        public NeedFields()
        {
        }

        public int Id { get; set; }
	    
        
	    public int propertyId { get; set; }

        public virtual Property Property { get; set; }



        public string value { get; set; }
	    
	    

        
	    public int NeedId { get; set; }
	    
    }
}