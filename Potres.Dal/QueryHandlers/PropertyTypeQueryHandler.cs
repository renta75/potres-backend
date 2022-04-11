using Microsoft.Extensions.Logging;
using Potres.Contracting.DTOs;
using Potres.Dal.Model;
using Potres.Dal.QueryHandlers.Extensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Potres.Dal.QueryHandlers
{
    public class PropertyTypeQueryHandler : GenericQueryHandler<Model.PropertyType, PropertyTypeDto, PropertyTypeDto>
    {

        public PropertyTypeQueryHandler(PotresContext ctx, ILogger<PropertyTypeQueryHandler> logger) : base(ctx, logger)
        {
        }

        protected override Expression<Func<Model.PropertyType, PropertyTypeDto>> SelectorInList => SelectorSingle;
        protected override Expression<Func<Model.PropertyType, PropertyTypeDto>> SelectorSingle =>
          a => new PropertyTypeDto
          {
                Id = a.Id,              
                
                
	                name = a.name,
	            
	            
                
	                regExp = a.regExp,
	            
	            
                
          };

        protected override Dictionary<string, Expression<Func<Model.PropertyType, object>>> OrderSelectors => orderSelectors;
        private static Dictionary<string, Expression<Func<Model.PropertyType, object>>> orderSelectors = new Dictionary<string, Expression<Func<Model.PropertyType, object>>>
        {
            [nameof(PropertyTypeDto.Id).ToLower()] = a => a.Id,
            
            
	        [nameof(PropertyTypeDto.name).ToLower()] = a => a.name,
	        
	        
            
	        [nameof(PropertyTypeDto.regExp).ToLower()] = a => a.regExp,
	        
	        
            
        };

        protected override Expression<Func<Model.PropertyType, bool>> CreatePKPredicate(int value)
        {
            return a => a.Id == value;
        }
    }
}
