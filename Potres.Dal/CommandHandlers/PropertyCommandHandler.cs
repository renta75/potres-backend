using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Potres.Contracting.Commands;
using Potres.Dal.Model;
using System.Threading.Tasks;

namespace Potres.Dal.CommandHandlers
{
  public class PropertyCommandHandler : GenericCommandHandler<Model.Property, AddPropertyCommand, UpdatePropertyCommand, DeletePropertyCommand>,
    IRequestHandler<DeletePropertyCommand>, IRequestHandler<AddPropertyCommand, int>, IRequestHandler<UpdatePropertyCommand>
  {
    
    public PropertyCommandHandler(PotresContext ctx, ILogger<PropertyCommandHandler> logger) : base(ctx, logger)
    {
      
    }

    protected override Task<Model.Property> LoadForUpdate(int id)
    {
      return ctx.Property.FirstOrDefaultAsync(a => a.Id == id);
    }

    protected override void CopyValues(UpdatePropertyCommand request, Model.Property item)
    {

       
        
	        item.name = request.name;
	    
	    
        
	        item.propertyTypeId = request.propertyTypeId;
	    
	    

        
        item.HelpCategoryId = request.HelpCategoryId;
	    
      
    }

    protected override Model.Property CreateItem(AddPropertyCommand request) => new Model.Property
    {
      Id=request.Id,
      
        
	        name = request.name,
	    
	    
        
	        propertyTypeId = request.propertyTypeId,
	    
	    

        
        HelpCategoryId = request.HelpCategoryId,
	    
    };  
  }
}
