using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAPItest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //mora se proveravati modelstate
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        //[HttpGet( "{id}")]
        //public ActionResult<string> Get([FromQueryAttribute] int id)
        //{
        //    return "value" + id;
        //}

        //[HttpGet("{id}")]
        //public ActionResult<string> Get( int id)
        //{
        //    return "value" + id;
        //}

        [HttpGet("{id}")]
        [Produces("application/json")]
        public IActionResult Get(int id)
        {
            return Ok(new Value { id = id, text = "REZ" + id });
        }


        // POST api/values
        //[HttpPost]
        //public void Post([FromBody]Value value)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        throw new InvalidOperationException("NOT OK");
        //    }

        //}

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Value value)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception();
            }

            return CreatedAtAction("GET", new { id=value.id   }, value);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class Value
    {
        public int id { get; set; }
        [MinLength(3)]
        public string text { get; set; }

    }
}

