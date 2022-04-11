using Microsoft.Extensions.Logging;
using Potres.Contracting.DTOs;
using Potres.Dal.Model;
using Potres.Dal.QueryHandlers.Extensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Potres.Dal.QueryHandlers
{
    public class PropertyQueryHandler : GenericQueryHandler<Model.Property, PropertyDto, PropertyDto>
    {

        public PropertyQueryHandler(PotresContext ctx, ILogger<PropertyQueryHandler> logger) : base(ctx, logger)
        {
        }

        protected override Expression<Func<Model.Property, PropertyDto>> SelectorInList => SelectorSingle;
        protected override Expression<Func<Model.Property, PropertyDto>> SelectorSingle =>
          a => new PropertyDto
          {
                Id = a.Id,              
                
                
	                name = a.name,
	            
	            
                
	                propertyTypeId = a.propertyTypeId,
                    propertyTypeName=a.PropertyType.name,
	            
	            
                
                    HelpCategoryId = a.HelpCategoryId,
	            
          };

        protected override Dictionary<string, Expression<Func<Model.Property, object>>> OrderSelectors => orderSelectors;
        private static Dictionary<string, Expression<Func<Model.Property, object>>> orderSelectors = new Dictionary<string, Expression<Func<Model.Property, object>>>
        {
            [nameof(PropertyDto.Id).ToLower()] = a => a.Id,
            
            
	        [nameof(PropertyDto.name).ToLower()] = a => a.name,
	        
	        
            
            [nameof(PropertyDto.propertyTypeId).ToLower()] = a => a.propertyTypeId,
	        
	        
            
            [nameof(PropertyDto.HelpCategoryId).ToLower()] = a => a.HelpCategoryId,
	        
        };

        protected override Expression<Func<Model.Property, bool>> CreatePKPredicate(int value)
        {
            return a => a.Id == value;
        }
    }
}
