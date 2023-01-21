using Commerce.Models;
using Microsoft.AspNetCore.Mvc;
using commerce.Context;

namespace Commerce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class SaleController : ControllerBase
    {
        private readonly CommerceContext _context;
        public SaleController(CommerceContext context)
        {
            _context = context;
        }

        [HttpPost("post")]
        public IActionResult Create(Sale sale)
        {
            _context.Add(sale);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = sale.SaleId }, sale);
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var sale = _context.Sales;
            return Ok(sale);
        }

        [HttpGet("get-by/{id}")]
        public IActionResult GetById(int id)
        {
            var sale = _context.Sales.Find(id);
            {
                if (sale == null)
                {
                    return NotFound();
                }
            }
            return Ok(sale);
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, Sale sale)
        {
            var dbtask = _context.Sales.Find(id);

            if (dbtask == null)
                return NotFound();

            dbtask.Status = sale.Status;
            _context.Sales.Update(dbtask);
            _context.SaveChanges();

            return Ok(dbtask);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Deletar(int id)
        {
            var dbtask = _context.Sales.Find(id);

            if (dbtask == null)
                return NotFound();
                
            _context.Sales.Remove(dbtask);
            _context.SaveChanges();
            
            return NoContent();
        }
    }
}