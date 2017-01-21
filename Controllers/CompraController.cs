using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TestApiCore.Controllers
{
    [Route("api/[controller]")]
    public class CompraController : Controller
    {

        private ListaCompraConext context;

        public CompraController(ListaCompraConext _context)
        {
            context = _context;
        }

        public IEnumerable<Compra> Get()
        {
            return context.Compra.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = context.Compra.Find(id);

            if (data != null)
                return Ok(data);

            return NotFound();


        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Compra value)
        {
            context.Add(value);
            try
            {
                context.SaveChanges();
                return Created("", value);
            }
            catch (Exception e)
            {
                return BadRequest();
            }

        }

        [HttpPut]
        public IActionResult Put([FromBody]Compra value)
        {
            if (!context.Compra.Any(o => o.Id == value.Id))
                return NotFound();

            context.Entry(value).State = EntityState.Modified;
            try
            {
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = context.Compra.Find(id);
            if (data == null)
                return NotFound();
            context.Compra.Remove(data);


            try
            {
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
