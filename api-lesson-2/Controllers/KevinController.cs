using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Niftyers {
    
    [ApiController]
    [Route("[controller]")]
    public class KevinController : ControllerBase { 

    public static IDictionary<string, string> Users = new Dictionary<string, string>()
    {
        {"admin", "sa" },
        {"kevin", "1234" },
        {"bert", "password" },
        {"bangbang", "hello" }
    };

     #region " Create Password "

    [HttpGet("ChangePassword")]
     public IActionResult CreatePassword(string Username, string NewPassword, string ConfirmPassword) {
        
        if (NewPassword == ConfirmPassword) {
            return Ok("Successfuly changed");
        }
        
        
        return Ok("Mismacthed password try again"); 
     }


     #endregion
     #region  " Create User "

    [HttpPost("CreateUser")] 
     public IActionResult CreateUser(string Username, string Password) {

        Users.Add(Username, Password);

        return Ok(Users); 
     }

     #endregion
    

    [HttpGet("Delete")]
    public IActionResult DeleteUser (string Username) {
        
     Users.Remove(Username);
      

        return Ok(Users);


    }


    #region "Update"
    [HttpGet("Update")]
    public IActionResult UpdateUser (string Username, string Password) {

        Users[Username] = Password;

        return Ok(Users);
    }

    #endregion


    }
}