using Microsoft.AspNetCore.Mvc;

namespace Niftyers {
    
    [ApiController]
    [Route("[controller]")]
    public class FlyFFController : ControllerBase {
        
        //get baseUlr + flyff + method
        [HttpGet("short")]
        public int GetAgeasdjalkdjksajdasdjaskdjlaksjdkljaskldjaklsjdkjaslkdasjd() {
            return 25;
        }

        [HttpGet("create")]
        public IActionResult CreateUser(string name, string password) {
            Console.WriteLine("your name is {0}  password: {1}", name, password);
    
            if (name == "admin" && password == "sa") {
                return Ok(string.Format("Your name is {0}  password: {1} was successfully created.", name, password));
            }

            return BadRequest("Not Authorized");
            
        }
    }

}