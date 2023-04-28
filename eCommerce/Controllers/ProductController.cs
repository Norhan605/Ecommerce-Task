using Domain;
using InfaStructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly Context context;

        public ProductController(Context _context)
        {
            this.context = _context;
        }
        //[HttpGet]
        //public IActionResult GetAllProduct()
        //{

        //    var products = context.Products;
        //    return Ok(products);

        //}
        [HttpGet("{id}")]
        public IActionResult GetProductByID(Guid id) {

            var products = context.Products.Where(p => p.ID == id);
            return Ok(products);
        }
        [HttpGet("{categoryID}")]
        public IActionResult GetProductByCategoryID(int categoryID)
        {
            var products=context.Categories.Where(c=>c.ID==categoryID).Select(c=>c.Products);
            return Ok(products);
        }


        /// ///////////////////////////////////////////////

        //[HttpGet]

        //public IActionResult GetAllProduct([FromRoute]ProductDto productDto , Guid Id)
        //{
        //    Product product = new Product("product1", 255, 5, "goodProduct");
        //    product.ID = productDto.ID;
        //    product.Name = productDto.Name;
        //    product.DiscountPercentage = productDto.DiscountPercentage;
        //    context.SaveChanges();

        //    return Ok();

        //}



        [HttpPost]
        public IActionResult AddProduct([FromBody] AddProductDto addProductDto)
        {
            
            Product product = new Product(addProductDto.Name, addProductDto.Price, addProductDto.Availabe, addProductDto.Description);
            
            context.Products.Add(product);
            context.SaveChanges();
            return Ok(product);

        }

        [HttpPut]
        

        public IActionResult UpdateProduct([FromBody] UpdateProductDto updateProductDto)
        {
           ;
            var product = context.Products.FirstOrDefault(p => p.ID==updateProductDto.ID);
            if(product!=null)
                product.Name=updateProductDto.Name;
            product.Price=updateProductDto.Price;
            context.SaveChanges();
            return Ok(product);
        }


        [HttpDelete]
        public IActionResult DeleteProduct(DeleteProductDto deleteProductDto)
        {
            var product = context.Products.FirstOrDefault(p => p.ID == deleteProductDto.ID);
            if (product != null)
                context.Products.Remove(product);
            context.SaveChanges();
            return Ok();
        }



    }
    /// <summary>
    /// ///////////////////// DTOS
    /// </summary>
    public class ProductDto
    {
        public Guid ID { get; set; }
        [MinLength(3), MaxLength(50)]
        public string Name { get;  set; }
        [Range(0, 100)]
        public byte? DiscountPercentage { get;  set; }
        
    }

    public class AddProductDto
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public float Price { get; set; }
        public int Availabe { get; private set; }
    }

    public class UpdateProductDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }

        public string? Description { get; set; }

        public float Price { get; set; }
        public int Availabe { get; private set; }

    }

    public class DeleteProductDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }

        public string? Description { get; set; }

        public float Price { get; set; }
        public int Availabe { get; private set; }

    }


}
