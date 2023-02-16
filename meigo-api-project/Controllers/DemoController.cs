using Microsoft.AspNetCore.Mvc;

namespace meigo_api_project.Controllers;

[ApiController]
[Route("[controller]")]
public class DemoController : ControllerBase
{
    
    [HttpGet("meigo")]
    public IActionResult Default() {
        return Ok("Hello World");
    }
    
}