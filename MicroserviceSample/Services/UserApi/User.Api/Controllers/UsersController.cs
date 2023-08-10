using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace User.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public IActionResult Users ()
        {
            return Ok("Success");
        }
    }
}
