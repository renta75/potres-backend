using System;
using Potres.Contracting.DTOs;

namespace Potres.Contracting.Commands
{
  public class AddUserCommand: AddCommand
  {
		public int Id { get; set; }
		
	    public string Name { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Password { get; set; }




	}
}
