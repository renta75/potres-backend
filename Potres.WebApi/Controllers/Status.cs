using MediatR;
using Microsoft.Extensions.Logging;
using Potres.Contracting.Commands;
using Potres.Contracting.DTOs;

namespace Potres.WebApi.Controllers
{

  public class StatusController : CRUDController<
    StatusDto, AddStatusCommand, StatusDto, UpdateStatusCommand, DeleteStatusCommand,
    StatusDto, StatusDto>
  {

    public StatusController(IMediator mediator, ILogger<StatusController> logger) : base(mediator, logger)
    {

    }    

    protected override AddStatusCommand ModelToCreateCommand(StatusDto model) => new AddStatusCommand
    { 
      Id=model.Id,
      
        
	        name = model.name,
	    
	    

        
      
    };

    protected override UpdateStatusCommand ModelToUpdateCommand(StatusDto model) => new UpdateStatusCommand
    {
      Id=model.Id,
      
        
	        name = model.name,
	    
	    

        
    };

  }
}