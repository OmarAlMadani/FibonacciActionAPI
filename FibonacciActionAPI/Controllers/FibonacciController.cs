using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using FibonacciActionAPI;

namespace FibonacciAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FibonacciController : ControllerBase
    {
        [HttpGet("{n}")]
        public ActionResult<int> Get(int n)
        {
            if (n < 1 || n > 100)
            {
                n = -1;
                return BadRequest("n doit être compris entre 1 et 100 inclus");

            }
            int a = 0;
            int b = 1;
            for (int i = 0; i < n; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }
    }

}

    
