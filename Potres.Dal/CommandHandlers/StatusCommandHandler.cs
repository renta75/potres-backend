using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Potres.Contracting.Commands;
using Potres.Dal.Model;
using System.Threading.Tasks;

namespace Potres.Dal.CommandHandlers
{
  public class StatusCommandHandler : GenericCommandHandler<Model.Status, AddStatusCommand, UpdateStatusCommand, DeleteStatusCommand>,
    IRequestHandler<DeleteStatusCommand>, IRequestHandler<AddStatusCommand, int>, IRequestHandler<UpdateStatusCommand>
  {
    
    public StatusCommandHandler(PotresContext ctx, ILogger<StatusCommandHandler> logger) : base(ctx, logger)
    {
      
    }

    protected override Task<Model.Status> LoadForUpdate(int id)
    {
      return ctx.Status.FirstOrDefaultAsync(a => a.Id == id);
    }

    protected override void CopyValues(UpdateStatusCommand request, Model.Status item)
    {

       
        
	        item.name = request.name;
	    
	    

        
      
    }

    protected override Model.Status CreateItem(AddStatusCommand request) => new Model.Status
    {
      Id=request.Id,
      
        
	        name = request.name,
	    
	    

        
    };  
  }
}
