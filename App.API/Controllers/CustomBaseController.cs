using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Net;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(ServiceResult<T> result)
        {
            return result.status switch
            {
                HttpStatusCode.NoContent => NoContent(),
                HttpStatusCode.Created => Created(result.url, result.Data),
                _ => new ObjectResult(result) { StatusCode = result.status.GetHashCode() }
            };
        }

        [NonAction]

        public IActionResult CreateActionResult(ServiceResult result)
        {
            return result.status switch
            {
                HttpStatusCode.NoContent => new ObjectResult(null) { StatusCode = result.status.GetHashCode() },
                _ => new ObjectResult(result) { StatusCode = result.status.GetHashCode() }
            };
        }
    }
}
