// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Potres.Contracting;
using System;
using System.Collections.Generic;

namespace Potres.Dal.Model
{
    public partial class User : IHasIntegerId
    {
        public User()
        {
            //Bid = new HashSet<Bid>();
            RefreshToken = new HashSet<RefreshToken>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

        //public virtual ICollection<Bid> Bid { get; set; }
        public virtual ICollection<RefreshToken> RefreshToken { get; set; }
    }
}