using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryApi.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GroceryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public ProductDetailsController(ApplicationDBContext applicationDBContext)
        {
            _dbContext = applicationDBContext;
        }
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_dbContext.productList.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _dbContext.productList.FirstOrDefault(list => list.ProductID == id);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] ProductDetails product)
        {
            var getProduct = _dbContext.productList.FirstOrDefault(list => list.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }
            getProduct.ProductName = product.ProductName;
            getProduct.ExpireDate = product.ExpireDate;
            getProduct.PerPrice = product.PerPrice;
            getProduct.PurchaseDate = product.PurchaseDate;
            getProduct.AvailableQty = product.AvailableQty;
            getProduct.ExpireDate = product.ExpireDate;
            _dbContext.SaveChanges();
            return Ok(product);
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] ProductDetails product)
        {
            _dbContext.productList.Add(product);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var product = _dbContext.productList.FirstOrDefault(list => list.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }
            _dbContext.productList.Remove(product);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}