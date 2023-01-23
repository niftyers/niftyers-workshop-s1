using Microsoft.AspNetCore.Mvc;

namespace Nikko {
    
    [ApiController]
    [Route("[controller]")]
    public class FlyFFController : ControllerBase {
        
        //get baseUlr+flyff
        [HttpGet("short")]
        public int GetAgeasdjalkdjksajdasdjaskdjlaksjdkljaskldjaklsjdkjaslkdasjd() {
            return 25;
        }

        [HttpGet("create")]
        public IActionResult CreateUser(string name, string password) {
            Console.WriteLine("your name is {0}  email: {1}", name, password);

            if (name == "admin" && password == "sa") {
                return Ok(string.Format("Your name is {0}  password: {1} was successfully created.", name, password));
            }

            return BadRequest("Not Authorized");
            
        }
    }

    //POST

}