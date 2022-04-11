using Microsoft.Extensions.Logging;
using Potres.Contracting.DTOs;
using Potres.Dal.Model;
using Potres.Dal.QueryHandlers.Extensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Potres.Dal.QueryHandlers
{
    public class HelpFieldsQueryHandler : GenericQueryHandler<Model.HelpFields, HelpFieldsDto, HelpFieldsDto>
    {

        public HelpFieldsQueryHandler(PotresContext ctx, ILogger<HelpFieldsQueryHandler> logger) : base(ctx, logger)
        {
        }

        protected override Expression<Func<Model.HelpFields, HelpFieldsDto>> SelectorInList => SelectorSingle;
        protected override Expression<Func<Model.HelpFields, HelpFieldsDto>> SelectorSingle =>
          a => new HelpFieldsDto
          {
                Id = a.Id,              
                
                
	                propertyId = a.propertyId,
              propertyName = a.Property.name,



              value = a.value,
	            
	            
                
                    HelpId = a.HelpId,
	            
          };

        protected override Dictionary<string, Expression<Func<Model.HelpFields, object>>> OrderSelectors => orderSelectors;
        private static Dictionary<string, Expression<Func<Model.HelpFields, object>>> orderSelectors = new Dictionary<string, Expression<Func<Model.HelpFields, object>>>
        {
            [nameof(HelpFieldsDto.Id).ToLower()] = a => a.Id,
            
            
            [nameof(HelpFieldsDto.propertyId).ToLower()] = a => a.propertyId,
	        
	        
            
	        [nameof(HelpFieldsDto.value).ToLower()] = a => a.value,
	        
	        
            
            [nameof(HelpFieldsDto.HelpId).ToLower()] = a => a.HelpId,
	        
        };

        protected override Expression<Func<Model.HelpFields, bool>> CreatePKPredicate(int value)
        {
            return a => a.Id == value;
        }
    }
}
