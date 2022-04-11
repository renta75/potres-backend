using Microsoft.Extensions.Logging;
using Potres.Contracting.Security;
using Potres.Dal.Model;
using Potres.Dal.QueryHandlers.Extensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Potres.Dal.QueryHandlers
{
    public class RoleQueryHandler : GenericQueryHandler<Model.Role, RoleDto, RoleDto>
    {

        public RoleQueryHandler(PotresContext ctx, ILogger<RoleQueryHandler> logger) : base(ctx, logger)
        {
        }

        protected override Expression<Func<Model.Role, RoleDto>> SelectorInList => SelectorSingle;
        protected override Expression<Func<Model.Role, RoleDto>> SelectorSingle =>
          a => new RoleDto
          {
                Id = a.Id,              
                
                
	                Name = a.Name,
	            
	            
                
          };

        protected override Dictionary<string, Expression<Func<Model.Role, object>>> OrderSelectors => orderSelectors;
        private static Dictionary<string, Expression<Func<Model.Role, object>>> orderSelectors = new Dictionary<string, Expression<Func<Model.Role, object>>>
        {
            [nameof(RoleDto.Id).ToLower()] = a => a.Id,
            
            
	        [nameof(RoleDto.Name).ToLower()] = a => a.Name,
	        
	        
            
        };

        protected override Expression<Func<Model.Role, bool>> CreatePKPredicate(int value)
        {
            return a => a.Id == value;
        }
    }
}
