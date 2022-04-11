using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Potres.Contracting.Commands;
using Potres.Dal.Model;
using System.Threading.Tasks;

namespace Potres.Dal.CommandHandlers
{
  public class HelpCategoryCommandHandler : GenericCommandHandler<Model.HelpCategory, AddHelpCategoryCommand, UpdateHelpCategoryCommand, DeleteHelpCategoryCommand>,
    IRequestHandler<DeleteHelpCategoryCommand>, IRequestHandler<AddHelpCategoryCommand, int>, IRequestHandler<UpdateHelpCategoryCommand>
  {
    
    public HelpCategoryCommandHandler(PotresContext ctx, ILogger<HelpCategoryCommandHandler> logger) : base(ctx, logger)
    {
      
    }

    protected override Task<Model.HelpCategory> LoadForUpdate(int id)
    {
      return ctx.HelpCategory.FirstOrDefaultAsync(a => a.Id == id);
    }

    protected override void CopyValues(UpdateHelpCategoryCommand request, Model.HelpCategory item)
    {

       
        
	        item.name = request.name;
	    
	    
        
    
	    

        
      
    }

    protected override Model.HelpCategory CreateItem(AddHelpCategoryCommand request) => new Model.HelpCategory
    {
      Id=request.Id,
      
        
	        name = request.name,
	    
	    
        
	    
	    

        
    };  
  }
}
