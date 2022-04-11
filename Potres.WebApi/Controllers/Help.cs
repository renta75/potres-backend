using MediatR;
using Microsoft.Extensions.Logging;
using Potres.Contracting.Commands;
using Potres.Contracting.DTOs;

namespace Potres.WebApi.Controllers
{

  public class HelpController : CRUDController<
    HelpDto, AddHelpCommand, HelpDto, UpdateHelpCommand, DeleteHelpCommand,
    HelpDto, HelpDto>
  {

    public HelpController(IMediator mediator, ILogger<HelpController> logger) : base(mediator, logger)
    {

    }    

    protected override AddHelpCommand ModelToCreateCommand(HelpDto model) => new AddHelpCommand
    { 
      Id=model.Id,
      
        
	        categoryId = model.categoryId,
	    
	    
        
	        title = model.title,
	    
	    
        
	        description = model.description,
	    
	    
        
	        contact = model.contact,
	    
	    
        
	        fieldsId = model.fieldsId,
	    
	    
        
	        locationLat = model.locationLat,
	    
	    
        
	        locationLng = model.locationLng,
	    
	    
        
	        statusId = model.statusId,
	    
	    
        
	        createdDateTime = model.createdDateTime,
	    
	    
        
	        editedDateTime = model.editedDateTime,
	    
	    
        
	        bulk = model.bulk,
	    
	    

        
      
    };

    protected override UpdateHelpCommand ModelToUpdateCommand(HelpDto model) => new UpdateHelpCommand
    {
      Id=model.Id,
      
        
	        categoryId = model.categoryId,
	    
	    
        
	        title = model.title,
	    
	    
        
	        description = model.description,
	    
	    
        
	        contact = model.contact,
	    
	    
        
	        fieldsId = model.fieldsId,
	    
	    
        
	        locationLat = model.locationLat,
	    
	    
        
	        locationLng = model.locationLng,
	    
	    
        
	        statusId = model.statusId,
	    
	    
        
	        createdDateTime = model.createdDateTime,
	    
	    
        
	        editedDateTime = model.editedDateTime,
	    
	    
        
	        bulk = model.bulk,
	    
	    

        
    };

  }
}