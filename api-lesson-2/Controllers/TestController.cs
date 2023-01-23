using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.BuildersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("AskForInfo")]
        public IActionResult AskForInfo(string name, string age)
        {
            if (name == null)
            {
                return BadRequest("Name is required");
            }

            if (age == null)
            {
                return BadRequest("Age is required");
            }

            return Ok(string.Format("Hi {0}, your age is {1}", name, age));
        }

        [HttpGet("AskForInfo3")]
        public IActionResult AskForInfo1(Bio payload)
        {
            if (payload.name == null)
            {
                return BadRequest("Name is required");
            }

            return Ok(string.Format("Hi {0}, your age is {1}", payload.name, payload.age));
        }
    }
}