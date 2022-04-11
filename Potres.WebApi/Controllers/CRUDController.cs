using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Potres.Contracting;
using Potres.Contracting.Commands;
using Potres.Contracting.Queries;
using Potres.WebApi.Models;
using Potres.WebApi.Util;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Potres.WebApi.Controllers
{
  public abstract class CRUDController<
    TCreateModel, TCreateCommand, TUpdateModel, TUpdateCommand, TDeleteCommand,
    TSingleDto, TDtoInList
    > : BaseApiController
    where TDeleteCommand : DeleteCommand, new()
    where TCreateCommand : AddCommand
    where TUpdateCommand : UpdateCommand
    where TCreateModel : IHasIntegerId
    where TUpdateModel : IHasIntegerId
  {
    protected readonly IMediator mediator;
    protected readonly ILogger logger;

    protected abstract TCreateCommand ModelToCreateCommand(TCreateModel model);
    protected abstract TUpdateCommand ModelToUpdateCommand(TUpdateModel model);
    protected virtual GetSingleItemQuery<TSingleDto> GetSingleItemQuery(int id) => new GetSingleItemQuery<TSingleDto>(id);
    protected virtual GetAllQuery<TDtoInList> GetItemsQuery => new GetAllQuery<TDtoInList>();
    protected virtual GetCountQuery<TDtoInList> GetItemsCountQuery => new GetCountQuery<TDtoInList>();

    public CRUDController(IMediator mediator, ILogger logger)
    {
      this.mediator = mediator;
      this.logger = logger;
    }
    
    /// <summary>
    /// Get all items based on (lazy) load parameters (paging and/or filtering)
    /// </summary>
    /// <param name="loadParams"></param>
    /// <returns></returns>
    [HttpGet]  
    public virtual async Task<List<TDtoInList>> GetAll([FromQuery] LoadParams loadParams)
    {
      var query = GetItemsQuery;
      if (query is IHasPagingData)
      {
        ((IHasPagingData)query).PagingData = CreatePagingData(loadParams);
      }
      if (query is IHasFilterData)
      {
        string filterString = loadParams?.Filter;        
        ((IHasFilterData)query).Filters = FilterStringParser.Parse(filterString);
      }
      var list = await mediator.Send(query);
      return list;
    }

    /// <summary>
    /// Returns number of items that satisfies filter parameters
    /// Note: Filter must be supported by the corresponding query handler
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpGet("count")]
    public virtual async Task<int> Count([FromQuery] string filter)
    {
      var query = GetItemsCountQuery;
      if (query is IHasFilterData)
      {        
        ((IHasFilterData)query).Filters = FilterStringParser.Parse(filter);
      }
      int count = await mediator.Send(query);
      return count;
    }    

    /// <summary>
    /// Returns single item based on primary key value
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public virtual async Task<ActionResult<TSingleDto>> Get(int id)
    {
      var query = GetSingleItemQuery(id);
      var item = await mediator.Send(query);      
      if (item == null)
      {
        return Problem(statusCode: StatusCodes.Status404NotFound, detail: $"No data for id = {id}");        
      }
      else
      {
        return item;
      }
    }

    /// <summary>
    /// Creates a new item.    
    /// </summary>
    /// <param name="model">id does not have to be sent (if sent it would be ignored)</param>
    /// <returns>A newly created item</returns>
    /// <response code="201">Returns route to newly created item and sent data updated with id</response>
    /// <response code="400">If the model is null or not valid</response>            
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public virtual async Task<IActionResult> Create(TCreateModel model)
    {      
      var command = ModelToCreateCommand(model);
      model.Id = await mediator.Send(command);

      var query = GetSingleItemQuery(model.Id);
      var item = await mediator.Send(query);

      return CreatedAtAction(nameof(Get), new { id = model.Id }, item);
    }

    /// <summary>
    /// Update the item
    /// </summary>
    /// <param name="id"></param>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public virtual async Task<IActionResult> Update(int id, TUpdateModel model)
    {
      if (model.Id != id) //ModelState.IsValid i model != null provjera se automatski zbog [ApiController]
      {
        return Problem(statusCode: StatusCodes.Status400BadRequest, detail: $"Different ids {id} vs {model.Id}");
      }
      else
      {
        //Ako se ne bude provjeravalo, onda je moguća iznimka kod handlera (ArgumentException, pa će se s filterom pretvoriti u BadRequest)
        //ovo je jedan korak (upit) više, ali je čišće
        var query = GetSingleItemQuery(id);
        var item = await mediator.Send(query);
        if (item == null)
        {
          return Problem(statusCode: StatusCodes.Status404NotFound, detail: $"Invalid id = {id}");
        }

        var command = ModelToUpdateCommand(model);
        await mediator.Send(command);
        return NoContent();
      }
    }

    /// <summary>
    /// Delete the item base on primary key value (id)
    /// </summary>
    /// <param name="id">Primary key value</param>
    /// <returns></returns>
    /// <response code="204">If the item is deleted</response>
    /// <response code="404">If the item with id does not exist</response>      
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public virtual async Task<IActionResult> Delete(int id)
    {
      //Ako se ne bude provjeravalo, onda je moguća iznimka kod handlera (ArgumentException, pa će se s filterom pretvoriti u BadRequest)
      //ovo je jedan korak (upit) više, ali je čišće
      var query = GetSingleItemQuery(id);
      var item = await mediator.Send(query);
      if (item == null)
      {
        return Problem(statusCode: StatusCodes.Status404NotFound, detail: $"Invalid id = {id}");
      }

      var command = new TDeleteCommand
      {
        Id = id
      };
      await mediator.Send(command);
      return NoContent();
    }

    private PagingData CreatePagingData(LoadParams loadParams)
    {
      if (loadParams == null) return null;

      var data = new PagingData();
      data.From = loadParams.First;
      data.Count = loadParams.Rows;
      data.Sort = loadParams.Sort;
      data.Ascending = loadParams.Ascending;

      return data;
    }    
  }
}

