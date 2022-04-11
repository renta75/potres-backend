using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Potres.Contracting.Commands;
using Potres.Dal.Model;
using System.Threading.Tasks;

namespace Potres.Dal.CommandHandlers
{
  public class PropertyTypeCommandHandler : GenericCommandHandler<Model.PropertyType, AddPropertyTypeCommand, UpdatePropertyTypeCommand, DeletePropertyTypeCommand>,
    IRequestHandler<DeletePropertyTypeCommand>, IRequestHandler<AddPropertyTypeCommand, int>, IRequestHandler<UpdatePropertyTypeCommand>
  {
    
    public PropertyTypeCommandHandler(PotresContext ctx, ILogger<PropertyTypeCommandHandler> logger) : base(ctx, logger)
    {
      
    }

    protected override Task<Model.PropertyType> LoadForUpdate(int id)
    {
      return ctx.PropertyType.FirstOrDefaultAsync(a => a.Id == id);
    }

    protected override void CopyValues(UpdatePropertyTypeCommand request, Model.PropertyType item)
    {

       
        
	        item.name = request.name;
	    
	    
        
	        item.regExp = request.regExp;
	    
	    

        
      
    }

    protected override Model.PropertyType CreateItem(AddPropertyTypeCommand request) => new Model.PropertyType
    {
      Id=request.Id,
      
        
	        name = request.name,
	    
	    
        
	        regExp = request.regExp,
	    
	    

        
    };  
  }
}
