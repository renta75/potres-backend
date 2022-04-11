using Microsoft.AspNetCore.Mvc;
using Potres.Util.ServiceFilters;

namespace Potres.WebApi.Controllers
{
  //  [ServiceFilter(typeof(BadRequestOnSqlException))]
  
  //#warning Isključiti BadRequestOnException iz produkcije
  //  [ServiceFilter(typeof(BadRequestOnException))]

  [ServiceFilter(typeof(BadRequestOnRuleValidationException))]
  //[ServiceFilter(typeof(BadRequestOnArgumentException))]
  [ServiceFilter(typeof(ProblemDetailsForSqlException))]  
  [ApiController]
  [Route("[controller]")]
  public abstract class BaseApiController : ControllerBase
  {
    [HttpOptions]
    [HttpOptions("{id}")]
    public virtual void Options()
    {
    }
  }
}
