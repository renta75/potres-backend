using MediatR;
using Microsoft.Extensions.Logging;
using Potres.Contracting.Commands;
using Potres.Contracting.Security;

namespace Potres.WebApi.Controllers
{

  public class RoleController : CRUDController<
    RoleDto, AddRoleCommand, RoleDto, UpdateRoleCommand, DeleteRoleCommand,
    RoleDto, RoleDto>
  {

    public RoleController(IMediator mediator, ILogger<RoleController> logger) : base(mediator, logger)
    {

    }    

    protected override AddRoleCommand ModelToCreateCommand(RoleDto model) => new AddRoleCommand
    { 
            Id=model.Id,
      
        
	        name = model.Name,
	    
	    

        
      
    };

    protected override UpdateRoleCommand ModelToUpdateCommand(RoleDto model) => new UpdateRoleCommand
    {
            Id=model.Id,
      
        
	        Name = model.Name,
	    
	    

        
    };

  }
}