using Microsoft.Extensions.Logging;
using Potres.Contracting.DTOs;
using Potres.Dal.Model;
using Potres.Dal.QueryHandlers.Extensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Potres.Dal.QueryHandlers
{
    public class HelpCategoryQueryHandler : GenericQueryHandler<Model.HelpCategory, HelpCategoryDto, HelpCategoryDto>
    {

        public HelpCategoryQueryHandler(PotresContext ctx, ILogger<HelpCategoryQueryHandler> logger) : base(ctx, logger)
        {
        }

        protected override Expression<Func<Model.HelpCategory, HelpCategoryDto>> SelectorInList => SelectorSingle;
        protected override Expression<Func<Model.HelpCategory, HelpCategoryDto>> SelectorSingle =>
          a => new HelpCategoryDto
          {
                Id = a.Id,              
                
                
	                name = a.name,
	            
	            
                
	            
	            
                
          };

        protected override Dictionary<string, Expression<Func<Model.HelpCategory, object>>> OrderSelectors => orderSelectors;
        private static Dictionary<string, Expression<Func<Model.HelpCategory, object>>> orderSelectors = new Dictionary<string, Expression<Func<Model.HelpCategory, object>>>
        {
            [nameof(HelpCategoryDto.Id).ToLower()] = a => a.Id,
            
            
	        [nameof(HelpCategoryDto.name).ToLower()] = a => a.name,
	        
	        
	        
	        
            
        };

        protected override Expression<Func<Model.HelpCategory, bool>> CreatePKPredicate(int value)
        {
            return a => a.Id == value;
        }
    }
}
