using MediatR;
using Microsoft.Extensions.Logging;
using Potres.Contracting.Commands;
using Potres.Contracting.Security;

namespace Potres.WebApi.Controllers
{

  public class UserController : CRUDController<
    UserDto, AddUserCommand, UserDto, UpdateUserCommand, DeleteUserCommand,
    UserDto, UserDto>
  {

    public UserController(IMediator mediator, ILogger<UserController> logger) : base(mediator, logger)
    {

    }    

    protected override AddUserCommand ModelToCreateCommand(UserDto model) => new AddUserCommand
    {
        Id = model.Id,
        Name=model.Name,
      FirstName = model.FirstName,
      LastName=model.LastName,
      Password=model.Password

	    
	    

        
      
    };

    protected override UpdateUserCommand ModelToUpdateCommand(UserDto model) => new UpdateUserCommand
    {
      Id=model.Id,
      Name=model.Name,
      FirstName = model.FirstName,
      LastName=model.LastName,
      Password=model.Password
	    
	    

        
    };

  }
}