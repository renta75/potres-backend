using MediatR;
using Microsoft.Extensions.Logging;
using Potres.Contracting.Commands;
using Potres.Contracting.DTOs;

namespace Potres.WebApi.Controllers
{

  public class NeedFieldsController : CRUDController<
    NeedFieldsDto, AddNeedFieldsCommand, NeedFieldsDto, UpdateNeedFieldsCommand, DeleteNeedFieldsCommand,
    NeedFieldsDto, NeedFieldsDto>
  {

    public NeedFieldsController(IMediator mediator, ILogger<NeedFieldsController> logger) : base(mediator, logger)
    {

    }    

    protected override AddNeedFieldsCommand ModelToCreateCommand(NeedFieldsDto model) => new AddNeedFieldsCommand
    { 
      Id=model.Id,
      
        
	        propertyId = model.propertyId,
	    
	    
        
	        value = model.value,
	    
	    

        
        NeedId = model.NeedId,
	    
      
    };

    protected override UpdateNeedFieldsCommand ModelToUpdateCommand(NeedFieldsDto model) => new UpdateNeedFieldsCommand
    {
      Id=model.Id,
      
        
	        propertyId = model.propertyId,
	    
	    
        
	        value = model.value,
	    
	    

        
        NeedId = model.NeedId,
	    
    };

  }
}