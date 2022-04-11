using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Potres.Contracting.Commands;
using Potres.Dal.Model;
using System.Threading.Tasks;

namespace Potres.Dal.CommandHandlers
{
  public class UserCommandHandler : GenericCommandHandler<Model.User, AddUserCommand, UpdateUserCommand, DeleteUserCommand>,
    IRequestHandler<DeleteUserCommand>, IRequestHandler<AddUserCommand, int>, IRequestHandler<UpdateUserCommand>
  {
    
    public UserCommandHandler(PotresContext ctx, ILogger<UserCommandHandler> logger) : base(ctx, logger)
    {
      
    }

    protected override Task<Model.User> LoadForUpdate(int id)
    {
      return ctx.User.FirstOrDefaultAsync(a => a.Id == id);
    }

    protected override void CopyValues(UpdateUserCommand request, Model.User item)
    {

       
        
	        item.Id = request.Id;
            item.Name = request.Name;
	        item.FirstName = request.FirstName;
	    
	    
        
	        item.LastName = request.LastName;
	    
	    
        
	        item.Password = request.Password;

    }

    protected override Model.User CreateItem(AddUserCommand request) => new Model.User
    {
			Id=request.Id,

            Name=request.Name,
      
        
	        FirstName = request.FirstName,
	    
	    
        
	        LastName = request.LastName,
	    
	    
        
	        Password = request.Password,

    };  
  }
}
