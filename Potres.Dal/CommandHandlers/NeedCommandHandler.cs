using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Potres.Contracting.Commands;
using Potres.Dal.Model;
using System.Threading.Tasks;

namespace Potres.Dal.CommandHandlers
{
  public class NeedCommandHandler : GenericCommandHandler<Model.Need, AddNeedCommand, UpdateNeedCommand, DeleteNeedCommand>,
    IRequestHandler<DeleteNeedCommand>, IRequestHandler<AddNeedCommand, int>, IRequestHandler<UpdateNeedCommand>
  {
    
    public NeedCommandHandler(PotresContext ctx, ILogger<NeedCommandHandler> logger) : base(ctx, logger)
    {
      
    }

    protected override Task<Model.Need> LoadForUpdate(int id)
    {
      return ctx.Need.FirstOrDefaultAsync(a => a.Id == id);
    }

    protected override void CopyValues(UpdateNeedCommand request, Model.Need item)
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

    protected override Model.Need CreateItem(AddNeedCommand request) => new Model.Need
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
