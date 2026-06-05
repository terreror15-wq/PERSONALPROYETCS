using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VirtualStore.Data;
using VirtualStore.DTO_s;
using VirtualStore.Models;

namespace VirtualStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductDbcontext db;

        public ProductController(ProductDbcontext _db)
        {
            db = _db;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<ProductDTO>>> Getproduct()
        {
            var products = await db.products.AsNoTracking().Select(p => new ProductDTO
            {
                Name = p.Name,
                Brand = p.Brand,
                Price = p.Price,
                Stock = p.Stock
                
            }).ToListAsync();

            if (products is null)
            {
                Console.WriteLine("your list is empty");


            }
            return Ok(products);
        }
        [HttpGet("{id}")]

        public async Task<ActionResult<ProductDTO>> GetOneProduct(int id)
        {
            var product = await db.products.FindAsync(id);
            if (product is null)
            {
                throw new Exception("Product empty");
            }
            return Ok(new ProductDTO
            {
                Name = product.Name,
                Brand = product.Brand,
                Price = product.Price,
                Stock = product.Stock
            });
        }

        [HttpPost]

        public async Task<ActionResult> AddProduct(Product product)
        {
            if (product is null)
            {
                throw new Exception("Product is empty");



            }
            await db.products.AddAsync(product);

            await db.SaveChangesAsync();



            return NoContent();
        }


        [HttpDelete("{id:int}")]

        public async Task<ActionResult> RemuveProduct(int id)
        {
            var product = await db.products.FindAsync(id);

            if(product is null)
            {
                throw new Exception("Product is empty");

            }

            db.products.Remove(product);
            await db.SaveChangesAsync();

            return Ok();

        }

        [HttpPut("{id}")]
        public async Task<ActionResult>UpdateProdct(int id, Product productNew)
        {
            var product = await db.products.FindAsync(id);
            if(productNew is null)
            {
                throw new Exception("New product is null");
            }
            product.Name = productNew.Name == null? product.Name : productNew.Name;
            product.Price = productNew.Price == 0? product.Price : productNew.Price;
            product.Brand = productNew.Brand == null? product.Brand : productNew.Brand;
            product.Stock = productNew.Stock == 0? product.Stock : productNew.Stock;

            db.products.Update(product);

            await db.SaveChangesAsync();

            return Ok(product);
             

        }

        

    }

}
