
namespace Potres.Contracting.Security
{
  
    public class UserDto : IHasIntegerId
    {        
        public int Id { get; set; }

        public string Name { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }       
        public string LastName { get; set; }
        public string Password { get; set; }     
    }
}
