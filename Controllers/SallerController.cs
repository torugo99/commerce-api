using commerce.Context;
using Commerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commerce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class SallerController : ControllerBase
    {
        private readonly CommerceContext _context;

        public SallerController( CommerceContext context)
        {
            _context = context;
        }

        [HttpPost("post")]
        public IActionResult Create(Saller saller)
        {
            _context.Add(saller);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = saller.SallerId }, saller);
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var saller = _context.Sallers;
            return Ok(saller);
        }

        [HttpGet("get-by/{id}")]
        public IActionResult GetById(int id)
        {
            var saller = _context.Sallers.Find(id);
            {
                if (saller == null)
                {
                    return NotFound();
                }
            }
            return Ok(saller);
        }

        [HttpPut("update{id}")]
        public IActionResult Update(int id, Saller saller)
        {
            var dbtask = _context.Sallers.Find(id);

            if (dbtask == null)
                return NotFound();

            dbtask.NameSaller = saller.NameSaller;
            dbtask.Cpf = saller.Cpf;
            dbtask.Email = saller.Email;
            dbtask.Active = saller.Active;
            _context.Sallers.Update(dbtask);
            _context.SaveChanges();

            return Ok(dbtask);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var dbtask = _context.Sallers.Find(id);

            if (dbtask == null)
                return NotFound();
                
            _context.Sallers.Remove(dbtask);
            _context.SaveChanges();
            
            return NoContent();
        }
    }
}