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
            if (result.status == HttpStatusCode.NoContent)
            {
                return new ObjectResult(null) { StatusCode = result.status.GetHashCode() };
            }
            return new ObjectResult(result) { StatusCode=result.status.GetHashCode() };
        }

        [NonAction]

        public IActionResult CreateActionResult(ServiceResult result)
        {
            if (result.status == HttpStatusCode.NoContent)
            {
                return new ObjectResult(null) { StatusCode = result.status.GetHashCode() };
            }
            return new ObjectResult(result) { StatusCode = result.status.GetHashCode() };
        }
    }
}
