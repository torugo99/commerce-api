using commerce.Context;
using Commerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commerce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        private readonly CommerceContext _context;

         public ProductController( CommerceContext context)
        {
            _context = context;
        }

        [HttpPost("post")]
        public IActionResult Create(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = product.ProductId }, product);
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var product = _context.Products;
            return Ok(product);
        }

        [HttpGet("get-by/{id}")]
        public IActionResult GetById(int id)
        {
            var product = _context.Products.Find(id);
            {
                if (product == null)
                {
                    return NotFound();
                }
            }
            return Ok(product);
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, Product product)
        {
            var dbtask = _context.Products.Find(id);

            if (dbtask == null)
                return NotFound();

            dbtask.Name = product.Name;
            dbtask.Description = product.Description;
            dbtask.Value = product.Value;
            _context.Products.Update(dbtask);
            _context.SaveChanges();

            return Ok(dbtask);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var dbtask = _context.Products.Find(id);

            if (dbtask == null)
                return NotFound();
                
            _context.Products.Remove(dbtask);
            _context.SaveChanges();
            
            return NoContent();
        }

    }
}