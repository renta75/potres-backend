using MediatR;
using Microsoft.Extensions.Logging;
using Potres.Contracting.Commands;
using Potres.Contracting.DTOs;

namespace Potres.WebApi.Controllers
{

  public class PropertyController : CRUDController<
    PropertyDto, AddPropertyCommand, PropertyDto, UpdatePropertyCommand, DeletePropertyCommand,
    PropertyDto, PropertyDto>
  {

    public PropertyController(IMediator mediator, ILogger<PropertyController> logger) : base(mediator, logger)
    {

    }    

    protected override AddPropertyCommand ModelToCreateCommand(PropertyDto model) => new AddPropertyCommand
    { 
      Id=model.Id,
      
        
	        name = model.name,
	    
	    
        
	        propertyTypeId = model.propertyTypeId,
	    
	    

        
        HelpCategoryId = model.HelpCategoryId,
	    
      
    };

    protected override UpdatePropertyCommand ModelToUpdateCommand(PropertyDto model) => new UpdatePropertyCommand
    {
      Id=model.Id,
      
        
	        name = model.name,
	    
	    
        
	        propertyTypeId = model.propertyTypeId,
	    
	    

        
        HelpCategoryId = model.HelpCategoryId,
	    
    };

  }
}