using Microsoft.Extensions.Logging;
using Potres.Contracting.Security;
using Potres.Dal.Model;
using Potres.Dal.QueryHandlers.Extensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Potres.Dal.QueryHandlers
{
    public class UserQueryHandler : GenericQueryHandler<Model.User, UserDto, UserDto>
    {

        public UserQueryHandler(PotresContext ctx, ILogger<UserQueryHandler> logger) : base(ctx, logger)
        {
        }

        protected override Expression<Func<Model.User, UserDto>> SelectorInList => SelectorSingle;
        protected override Expression<Func<Model.User, UserDto>> SelectorSingle =>
          a => new UserDto
          {
                Id = a.Id,              
                
                    Username=a.Name,
	                FirstName = a.FirstName,
                    LastName=a.LastName,
                    Password=a.Password
	            
	            
                
          };

        protected override Dictionary<string, Expression<Func<Model.User, object>>> OrderSelectors => orderSelectors;
        private static Dictionary<string, Expression<Func<Model.User, object>>> orderSelectors = new Dictionary<string, Expression<Func<Model.User, object>>>
        {
            [nameof(UserDto.Id).ToLower()] = a => a.Id,

            [nameof(UserDto.Username).ToLower()] = a => a.Name,

            [nameof(UserDto.FirstName).ToLower()] = a => a.FirstName,

            [nameof(UserDto.LastName).ToLower()] = a => a.LastName,

            [nameof(UserDto.Password).ToLower()] = a => a.Password,



        };

        protected override Expression<Func<Model.User, bool>> CreatePKPredicate(int value)
        {
            return a => a.Id == value;
        }
    }
}
