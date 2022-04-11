// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;

namespace Potres.Dal.Model
{
    public partial class PotresContext : DbContext
    {
        public PotresContext(DbContextOptions<PotresContext> options)
            : base(options)
        {
        }


        
        public virtual DbSet<HelpCategory> HelpCategory { get; set; }
        
        public virtual DbSet<Property> Property { get; set; }
        
        public virtual DbSet<Help> Help { get; set; }
        
        public virtual DbSet<Need> Need { get; set; }
        
        public virtual DbSet<NeedFields> NeedFields { get; set; }
        
        public virtual DbSet<HelpFields> HelpFields { get; set; }
        
        public virtual DbSet<PropertyType> PropertyType { get; set; }
        
        public virtual DbSet<Status> Status { get; set; }
        
        public virtual DbSet<User> User { get; set; }

        public virtual DbSet<User> Role { get; set; }

        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<RefreshToken> RefreshToken { get; set; }
    }
}