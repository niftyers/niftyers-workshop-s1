using Microsoft.AspNetCore.Mvc;

namespace Niftyers {

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase {
        
        [HttpPost("login")]
        public IActionResult Login([FromBody] PayloadUser payload) {
            return Ok(payload);
        }
    }
    
}