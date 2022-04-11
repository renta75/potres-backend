using MediatR;
using Microsoft.Extensions.Logging;
using Potres.Contracting.Commands;
using Potres.Contracting.DTOs;

namespace Potres.WebApi.Controllers
{

  public class HelpFieldsController : CRUDController<
    HelpFieldsDto, AddHelpFieldsCommand, HelpFieldsDto, UpdateHelpFieldsCommand, DeleteHelpFieldsCommand,
    HelpFieldsDto, HelpFieldsDto>
  {

    public HelpFieldsController(IMediator mediator, ILogger<HelpFieldsController> logger) : base(mediator, logger)
    {

    }    

    protected override AddHelpFieldsCommand ModelToCreateCommand(HelpFieldsDto model) => new AddHelpFieldsCommand
    { 
      Id=model.Id,
      
        
	        propertyId = model.propertyId,
	    
	    
        
	        value = model.value,
	    
	    

        
        HelpId = model.HelpId,
	    
      
    };

    protected override UpdateHelpFieldsCommand ModelToUpdateCommand(HelpFieldsDto model) => new UpdateHelpFieldsCommand
    {
      Id=model.Id,
      
        
	        propertyId = model.propertyId,
	    
	    
        
	        value = model.value,
	    
	    

        
        HelpId = model.HelpId,
	    
    };

  }
}