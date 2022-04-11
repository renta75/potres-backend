using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Potres.Contracting.Commands;
using Potres.Dal.Model;
using System.Threading.Tasks;

namespace Potres.Dal.CommandHandlers
{
  public class HelpFieldsCommandHandler : GenericCommandHandler<Model.HelpFields, AddHelpFieldsCommand, UpdateHelpFieldsCommand, DeleteHelpFieldsCommand>,
    IRequestHandler<DeleteHelpFieldsCommand>, IRequestHandler<AddHelpFieldsCommand, int>, IRequestHandler<UpdateHelpFieldsCommand>
  {
    
    public HelpFieldsCommandHandler(PotresContext ctx, ILogger<HelpFieldsCommandHandler> logger) : base(ctx, logger)
    {
      
    }

    protected override Task<Model.HelpFields> LoadForUpdate(int id)
    {
      return ctx.HelpFields.FirstOrDefaultAsync(a => a.Id == id);
    }

    protected override void CopyValues(UpdateHelpFieldsCommand request, Model.HelpFields item)
    {

       
        
	        item.propertyId = request.propertyId;
	    
	    
        
	        item.value = request.value;
	    
	    

        
        item.HelpId = request.HelpId;
	    
      
    }

    protected override Model.HelpFields CreateItem(AddHelpFieldsCommand request) => new Model.HelpFields
    {
      Id=request.Id,
      
        
	        propertyId = request.propertyId,
	    
	    
        
	        value = request.value,
	    
	    

        
        HelpId = request.HelpId,
	    
    };  
  }
}
