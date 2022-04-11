using Potres.Contracting;
using System;
using System.Collections.Generic;

namespace Potres.Dal.Model
{
    public partial class Status: IHasIntegerId
    {
        public Status()
        {
        }

        public int Id { get; set; }
	    
        
	    public string name { get; set; }
	    
	    

        
    }
}