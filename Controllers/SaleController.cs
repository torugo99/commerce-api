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
        public IActionResult Update(int id, StatusEnum status)
        {
           var sale = _context.Sales.Find(id);

            if (sale == null){
                return NotFound();
            }

            if (sale.Status == StatusEnum.AWAITING_PAYMENT
                && status == StatusEnum.APPROVED_PAYMENT
                || sale.Status == StatusEnum.AWAITING_PAYMENT
                && status == StatusEnum.CANCELED)
            {
                sale.Status = status;
            }
            else if (sale.Status == StatusEnum.APPROVED_PAYMENT 
                    && status == StatusEnum.SHIPPED_TO_CARRIER
                    || sale.Status == StatusEnum.APPROVED_PAYMENT 
                    && status == StatusEnum.CANCELED)
            {
                sale.Status = status;
            }
            else if (sale.Status == StatusEnum.SHIPPED_TO_CARRIER 
                    && status == StatusEnum.DELIVERED)
            {
                sale.Status = status;
            }
            else
            {
                return BadRequest($"{sale.Status} cannot go to {status}");
            }

            _context.Sales.Update(sale);
            _context.SaveChanges();

            return Ok("The sale has been updated");
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