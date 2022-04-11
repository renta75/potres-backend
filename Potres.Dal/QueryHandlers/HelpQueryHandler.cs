using Microsoft.Extensions.Logging;
using Potres.Contracting.DTOs;
using Potres.Dal.Model;
using Potres.Dal.QueryHandlers.Extensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Potres.Dal.QueryHandlers
{
    public class HelpQueryHandler : GenericQueryHandler<Model.Help, HelpDto, HelpDto>
    {

        public HelpQueryHandler(PotresContext ctx, ILogger<HelpQueryHandler> logger) : base(ctx, logger)
        {
        }

        protected override Expression<Func<Model.Help, HelpDto>> SelectorInList => SelectorSingle;
        protected override Expression<Func<Model.Help, HelpDto>> SelectorSingle =>
          a => new HelpDto
          {
                Id = a.Id,              
                
                
	                categoryId = a.categoryId,
					categoryName=a.Category.name,
	            
	            
                
	                title = a.title,
	            
	            
                
	                description = a.description,
	            
	            
                
	                contact = a.contact,
	            
	            
                
	                fieldsId = a.fieldsId,
	            
	            
                
	                locationLat = a.locationLat,
	            
	            
                
	                locationLng = a.locationLng,
	            
	            
                
	                statusId = a.statusId,
					statusName=a.Status.name,
	            
	            
                
	                createdDateTime = a.createdDateTime,
	            
	            
                
	                editedDateTime = a.editedDateTime,
	            
	            
                
	                bulk = a.bulk,
	            
	            
                
          };

        protected override Dictionary<string, Expression<Func<Model.Help, object>>> OrderSelectors => orderSelectors;
        private static Dictionary<string, Expression<Func<Model.Help, object>>> orderSelectors = new Dictionary<string, Expression<Func<Model.Help, object>>>
        {
            [nameof(HelpDto.Id).ToLower()] = a => a.Id,
            
            
            [nameof(HelpDto.categoryId).ToLower()] = a => a.categoryId,
	        
	        
            
	        [nameof(HelpDto.title).ToLower()] = a => a.title,
	        
	        
            
	        [nameof(HelpDto.description).ToLower()] = a => a.description,
	        
	        
            
	        [nameof(HelpDto.contact).ToLower()] = a => a.contact,
	        
	        
            
            [nameof(HelpDto.fieldsId).ToLower()] = a => a.fieldsId,
	        
	        
            
	        [nameof(HelpDto.locationLat).ToLower()] = a => a.locationLat,
	        
	        
            
	        [nameof(HelpDto.locationLng).ToLower()] = a => a.locationLng,
	        
	        
            
            [nameof(HelpDto.statusId).ToLower()] = a => a.statusId,
	        
	        
            
	        [nameof(HelpDto.createdDateTime).ToLower()] = a => a.createdDateTime,
	        
	        
            
	        [nameof(HelpDto.editedDateTime).ToLower()] = a => a.editedDateTime,
	        
	        
            
	        [nameof(HelpDto.bulk).ToLower()] = a => a.bulk,
	        
	        
            
        };

        protected override Expression<Func<Model.Help, bool>> CreatePKPredicate(int value)
        {
            return a => a.Id == value;
        }
    }
}
