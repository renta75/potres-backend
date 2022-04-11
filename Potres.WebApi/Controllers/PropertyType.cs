using MediatR;
using Microsoft.Extensions.Logging;
using Potres.Contracting.Commands;
using Potres.Contracting.DTOs;

namespace Potres.WebApi.Controllers
{

  public class PropertyTypeController : CRUDController<
    PropertyTypeDto, AddPropertyTypeCommand, PropertyTypeDto, UpdatePropertyTypeCommand, DeletePropertyTypeCommand,
    PropertyTypeDto, PropertyTypeDto>
  {

    public PropertyTypeController(IMediator mediator, ILogger<PropertyTypeController> logger) : base(mediator, logger)
    {

    }    

    protected override AddPropertyTypeCommand ModelToCreateCommand(PropertyTypeDto model) => new AddPropertyTypeCommand
    { 
      Id=model.Id,
      
        
	        name = model.name,
	    
	    
        
	        regExp = model.regExp,
	    
	    

        
      
    };

    protected override UpdatePropertyTypeCommand ModelToUpdateCommand(PropertyTypeDto model) => new UpdatePropertyTypeCommand
    {
      Id=model.Id,
      
        
	        name = model.name,
	    
	    
        
	        regExp = model.regExp,
	    
	    

        
    };

  }
}