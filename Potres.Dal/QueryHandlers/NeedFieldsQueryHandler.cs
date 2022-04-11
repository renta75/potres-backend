using Microsoft.Extensions.Logging;
using Potres.Contracting.DTOs;
using Potres.Dal.Model;
using Potres.Dal.QueryHandlers.Extensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Potres.Dal.QueryHandlers
{
    public class NeedFieldsQueryHandler : GenericQueryHandler<Model.NeedFields, NeedFieldsDto, NeedFieldsDto>
    {

        public NeedFieldsQueryHandler(PotresContext ctx, ILogger<NeedFieldsQueryHandler> logger) : base(ctx, logger)
        {
        }

        protected override Expression<Func<Model.NeedFields, NeedFieldsDto>> SelectorInList => SelectorSingle;
        protected override Expression<Func<Model.NeedFields, NeedFieldsDto>> SelectorSingle =>
          a => new NeedFieldsDto
          {
                Id = a.Id,              
                
                
	                propertyId = a.propertyId,
                    propertyName=a.Property.name,
	            
	            
                
	                value = a.value,
	            
	            
                
                    NeedId = a.NeedId,
	            
          };

        protected override Dictionary<string, Expression<Func<Model.NeedFields, object>>> OrderSelectors => orderSelectors;
        private static Dictionary<string, Expression<Func<Model.NeedFields, object>>> orderSelectors = new Dictionary<string, Expression<Func<Model.NeedFields, object>>>
        {
            [nameof(NeedFieldsDto.Id).ToLower()] = a => a.Id,
            
            
            [nameof(NeedFieldsDto.propertyId).ToLower()] = a => a.propertyId,
	        
	        
            
	        [nameof(NeedFieldsDto.value).ToLower()] = a => a.value,
	        
	        
            
            [nameof(NeedFieldsDto.NeedId).ToLower()] = a => a.NeedId,
	        
        };

        protected override Expression<Func<Model.NeedFields, bool>> CreatePKPredicate(int value)
        {
            return a => a.Id == value;
        }
    }
}
