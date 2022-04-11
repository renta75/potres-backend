using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Potres.Contracting.Commands;
using Potres.Dal.Model;
using System.Threading.Tasks;

namespace Potres.Dal.CommandHandlers
{
  public class HelpCommandHandler : GenericCommandHandler<Model.Help, AddHelpCommand, UpdateHelpCommand, DeleteHelpCommand>,
    IRequestHandler<DeleteHelpCommand>, IRequestHandler<AddHelpCommand, int>, IRequestHandler<UpdateHelpCommand>
  {
    
    public HelpCommandHandler(PotresContext ctx, ILogger<HelpCommandHandler> logger) : base(ctx, logger)
    {
      
    }

    protected override Task<Model.Help> LoadForUpdate(int id)
    {
      return ctx.Help.FirstOrDefaultAsync(a => a.Id == id);
    }

    protected override void CopyValues(UpdateHelpCommand request, Model.Help item)
    {

       
        
	        item.categoryId = request.categoryId;
	    
	    
        
	        item.title = request.title;
	    
	    
        
	        item.description = request.description;
	    
	    
        
	        item.contact = request.contact;
	    
	    
        
	        item.fieldsId = request.fieldsId;
	    
	    
        
	        item.locationLat = request.locationLat;
	    
	    
        
	        item.locationLng = request.locationLng;
	    
	    
        
	        item.statusId = request.statusId;
	    
	    
        
	        item.createdDateTime = request.createdDateTime;
	    
	    
        
	        item.editedDateTime = request.editedDateTime;
	    
	    
        
	        item.bulk = request.bulk;
	    
	    

        
      
    }

    protected override Model.Help CreateItem(AddHelpCommand request) => new Model.Help
    {
      Id=request.Id,
      
        
	        categoryId = request.categoryId,
	    
	    
        
	        title = request.title,
	    
	    
        
	        description = request.description,
	    
	    
        
	        contact = request.contact,
	    
	    
        
	        fieldsId = request.fieldsId,
	    
	    
        
	        locationLat = request.locationLat,
	    
	    
        
	        locationLng = request.locationLng,
	    
	    
        
	        statusId = request.statusId,
	    
	    
        
	        createdDateTime = request.createdDateTime,
	    
	    
        
	        editedDateTime = request.editedDateTime,
	    
	    
        
	        bulk = request.bulk,
	    
	    

        
    };  
  }
}
