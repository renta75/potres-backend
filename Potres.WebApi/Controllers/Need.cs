using MediatR;
using Microsoft.Extensions.Logging;
using Potres.Contracting.Commands;
using Potres.Contracting.DTOs;

namespace Potres.WebApi.Controllers
{

  public class NeedController : CRUDController<
    NeedDto, AddNeedCommand, NeedDto, UpdateNeedCommand, DeleteNeedCommand,
    NeedDto, NeedDto>
  {

    public NeedController(IMediator mediator, ILogger<NeedController> logger) : base(mediator, logger)
    {

    }    

    protected override AddNeedCommand ModelToCreateCommand(NeedDto model) => new AddNeedCommand
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

    protected override UpdateNeedCommand ModelToUpdateCommand(NeedDto model) => new UpdateNeedCommand
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