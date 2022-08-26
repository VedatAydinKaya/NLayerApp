using Core.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  
    public class BaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(CustomResponseDto<T>  response) 
        {
            if (response.StatusCode==204)  // noContent
            {
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode,
                };
            }

            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode,
            };
        }
    }
}
