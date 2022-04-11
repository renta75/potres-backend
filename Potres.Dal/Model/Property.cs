using Potres.Contracting;
using System;
using System.Collections.Generic;

namespace Potres.Dal.Model
{
    public partial class Property: IHasIntegerId
    {
        public Property()
        {
        }

        public int Id { get; set; }
	    
        
	    public string name { get; set; }
	    
	    
        
	    public int propertyTypeId { get; set; }
        public virtual PropertyType PropertyType { get; set; }




        public int HelpCategoryId { get; set; }
	    
    }
}