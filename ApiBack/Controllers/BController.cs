using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Models.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBack.Controllers
{
    
    [ApiController]
    [EnableCors("_default")]
    [Produces("application/json", Type = typeof(string))]
    [ProducesResponseType(typeof(ErrorMessage), 400)]
    [ProducesResponseType(typeof(ErrorMessage), 500)]
    public class BController : ControllerBase
    {
        public virtual IActionResult CreateResponse<T>(Result<T> result)
        {
            IActionResult response;
            switch (result.CodeStatus)
            {
                case 200:
                    response = Ok(result.Data);
                    break;
                case 201:
                    response = StatusCode(201);
                    break;
                case 204:
                    response = NoContent();
                    break;
                case 400:
                    response = BadRequest(result.MessageError);
                    break;
                case 401:
                    response = StatusCode(result.CodeStatus, result.MessageError);
                    break;
                case 404:
                    response = NotFound(result.MessageError);
                    break;
                case 500:
                    response = StatusCode(result.CodeStatus, result.MessageError);
                    break;
                default:
                    response = StatusCode(result.CodeStatus, ((result.Data != null) ? result.Data : (result.MessageError != null) ? result.MessageError : null));
                    break;
            }
            return response;
        }
    }
}
