using MediatR;
using Microsoft.Extensions.Logging;
using Potres.Contracting.Commands;
using Potres.Contracting.DTOs;

namespace Potres.WebApi.Controllers
{

  public class HelpCategoryController : CRUDController<
    HelpCategoryDto, AddHelpCategoryCommand, HelpCategoryDto, UpdateHelpCategoryCommand, DeleteHelpCategoryCommand,
    HelpCategoryDto, HelpCategoryDto>
  {

    public HelpCategoryController(IMediator mediator, ILogger<HelpCategoryController> logger) : base(mediator, logger)
    {

    }    

    protected override AddHelpCategoryCommand ModelToCreateCommand(HelpCategoryDto model) => new AddHelpCategoryCommand
    { 
      Id=model.Id,
      
        
	        name = model.name,
	    
	    
        
	        propertiesId = model.propertiesId,
	    
	    

        
      
    };

    protected override UpdateHelpCategoryCommand ModelToUpdateCommand(HelpCategoryDto model) => new UpdateHelpCategoryCommand
    {
      Id=model.Id,
      
        
	        name = model.name,
	    
	    
        
	        propertiesId = model.propertiesId,
	    
	    

        
    };

  }
}