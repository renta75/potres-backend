using Microsoft.Extensions.Logging;
using Potres.Contracting.DTOs;
using Potres.Dal.Model;
using Potres.Dal.QueryHandlers.Extensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Potres.Dal.QueryHandlers
{
    public class StatusQueryHandler : GenericQueryHandler<Model.Status, StatusDto, StatusDto>
    {

        public StatusQueryHandler(PotresContext ctx, ILogger<StatusQueryHandler> logger) : base(ctx, logger)
        {
        }

        protected override Expression<Func<Model.Status, StatusDto>> SelectorInList => SelectorSingle;
        protected override Expression<Func<Model.Status, StatusDto>> SelectorSingle =>
          a => new StatusDto
          {
                Id = a.Id,              
                
                
	                name = a.name,
	            
	            
                
          };

        protected override Dictionary<string, Expression<Func<Model.Status, object>>> OrderSelectors => orderSelectors;
        private static Dictionary<string, Expression<Func<Model.Status, object>>> orderSelectors = new Dictionary<string, Expression<Func<Model.Status, object>>>
        {
            [nameof(StatusDto.Id).ToLower()] = a => a.Id,
            
            
	        [nameof(StatusDto.name).ToLower()] = a => a.name,
	        
	        
            
        };

        protected override Expression<Func<Model.Status, bool>> CreatePKPredicate(int value)
        {
            return a => a.Id == value;
        }
    }
}
