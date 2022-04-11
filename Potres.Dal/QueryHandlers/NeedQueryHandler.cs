using Microsoft.Extensions.Logging;
using Potres.Contracting.DTOs;
using Potres.Dal.Model;
using Potres.Dal.QueryHandlers.Extensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Potres.Dal.QueryHandlers
{
    public class NeedQueryHandler : GenericQueryHandler<Model.Need, NeedDto, NeedDto>
    {

        public NeedQueryHandler(PotresContext ctx, ILogger<NeedQueryHandler> logger) : base(ctx, logger)
        {
        }

        protected override Expression<Func<Model.Need, NeedDto>> SelectorInList => SelectorSingle;
        protected override Expression<Func<Model.Need, NeedDto>> SelectorSingle =>
          a => new NeedDto
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

        protected override Dictionary<string, Expression<Func<Model.Need, object>>> OrderSelectors => orderSelectors;
        private static Dictionary<string, Expression<Func<Model.Need, object>>> orderSelectors = new Dictionary<string, Expression<Func<Model.Need, object>>>
        {
            [nameof(NeedDto.Id).ToLower()] = a => a.Id,
            
            
            [nameof(NeedDto.categoryId).ToLower()] = a => a.categoryId,
	        
	        
            
	        [nameof(NeedDto.title).ToLower()] = a => a.title,
	        
	        
            
	        [nameof(NeedDto.description).ToLower()] = a => a.description,
	        
	        
            
	        [nameof(NeedDto.contact).ToLower()] = a => a.contact,
	        
	        
            
            [nameof(NeedDto.fieldsId).ToLower()] = a => a.fieldsId,
	        
	        
            
	        [nameof(NeedDto.locationLat).ToLower()] = a => a.locationLat,
	        
	        
            
	        [nameof(NeedDto.locationLng).ToLower()] = a => a.locationLng,
	        
	        
            
            [nameof(NeedDto.statusId).ToLower()] = a => a.statusId,
	        
	        
            
	        [nameof(NeedDto.createdDateTime).ToLower()] = a => a.createdDateTime,
	        
	        
            
	        [nameof(NeedDto.editedDateTime).ToLower()] = a => a.editedDateTime,
	        
	        
            
	        [nameof(NeedDto.bulk).ToLower()] = a => a.bulk,
	        
	        
            
        };

        protected override Expression<Func<Model.Need, bool>> CreatePKPredicate(int value)
        {
            return a => a.Id == value;
        }
    }
}
