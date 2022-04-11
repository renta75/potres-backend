using FluentValidation.Validators;
using MediatR;
using Potres.Contracting;
using Potres.Contracting.Commands;
using Potres.Contracting.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Potres.CommandValidators.Common
{
  public class UniqueIndexValidator<TDto> where TDto : IHasIntegerId
  {
    private readonly IMediator mediator;
    private readonly string columnName;

    public UniqueIndexValidator(IMediator mediator, string columnName)
    {
      this.mediator = mediator;
      this.columnName = columnName;
    }    

    public async Task Validate(string value, CustomContext context, CancellationToken cancellationToken)
    {
      var query = new GetCountQuery<TDto>()
      {
        Filters = new List<Filter>
        {
          new Filter(columnName, "=", value.Trim())
        }        
      };      
      int count = await mediator.Send(query, cancellationToken);
      if (count > 0)
      {
        context.AddFailure($"{columnName} (value={value})  must be unique.");
      }
    }

    public async Task ValidateExisting<TUpdateCommand>(string value, CustomContext context, CancellationToken cancellationToken) where TUpdateCommand : UpdateCommand
    {
      TUpdateCommand validatingObject = (TUpdateCommand)context.InstanceToValidate;
      var query = new GetAllQuery<TDto>()
      {
        Filters = new List<Filter>
        {
          new Filter(columnName, "=", value.Trim())
        }
      };
      List<TDto> list = await mediator.Send(query, cancellationToken);
      if (list.Count > 0)
      {

        bool valueBelongsToValidatingItem = list.Any(item => item.Id == validatingObject.Id);
        if (!valueBelongsToValidatingItem)
        {
          context.AddFailure($"{columnName} (value={value}) must be unique.");
        }
      }
    }
  }
}
