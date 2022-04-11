using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Potres.Contracting.Commands;
using Potres.Dal.Model;
using System.Threading.Tasks;

namespace Potres.Dal.CommandHandlers
{
  public class NeedFieldsCommandHandler : GenericCommandHandler<Model.NeedFields, AddNeedFieldsCommand, UpdateNeedFieldsCommand, DeleteNeedFieldsCommand>,
    IRequestHandler<DeleteNeedFieldsCommand>, IRequestHandler<AddNeedFieldsCommand, int>, IRequestHandler<UpdateNeedFieldsCommand>
  {
    
    public NeedFieldsCommandHandler(PotresContext ctx, ILogger<NeedFieldsCommandHandler> logger) : base(ctx, logger)
    {
      
    }

    protected override Task<Model.NeedFields> LoadForUpdate(int id)
    {
      return ctx.NeedFields.FirstOrDefaultAsync(a => a.Id == id);
    }

    protected override void CopyValues(UpdateNeedFieldsCommand request, Model.NeedFields item)
    {

       
        
	        item.propertyId = request.propertyId;
	    
	    
        
	        item.value = request.value;
	    
	    

        
        item.NeedId = request.NeedId;
	    
      
    }

    protected override Model.NeedFields CreateItem(AddNeedFieldsCommand request) => new Model.NeedFields
    {
      Id=request.Id,
      
        
	        propertyId = request.propertyId,
	    
	    
        
	        value = request.value,
	    
	    

        
        NeedId = request.NeedId,
	    
    };  
  }
}
