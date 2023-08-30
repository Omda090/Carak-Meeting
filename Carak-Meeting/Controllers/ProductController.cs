using AutoMapper;
using Carak_Meeting.DTOs;
using Carak_Meeting.Interfaces;
using Carak_Meeting.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Carak_Meeting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _product;
        private readonly IMapper _mapper;

        public ProductController(IProduct product, IMapper mapper)
        {
            _product = product;
            _mapper = mapper;
        }

        // GET: api/<CarakController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _product.GetAllProduct();
            return Ok(result);
        }



        // GET api/<CarakController>/5
        [HttpGet("GetProductById")]
        public async Task<IActionResult> GetById(int id)
        {

            return Ok(await _product.GetProductById(id));
        }



        // POST api/<CarakController>
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(ProductDto product)
        {
            var map = _mapper.Map<Product>(product);
            _product.Add(map);
            await _product.SaveAll();
            return Ok(map);

        }



        // PUT api/<CarakController>/5
        [HttpPut("updateProduct")]
        public async Task<IActionResult> updateProduct(int id, ProductDto product)
        {
            var Carak = await _product.GetProductById(id);

            Carak.ProductName = product.ProductName;
            Carak.Supplier = product.Supplier;
            //  Carak.Price = userCarak.Price;
            Carak.Phone = product.Phone;

            await _product.SaveChanges();
            return Ok("Product Updated Successfully");
        }

        // DELETE api/<CarakController>/5
        [HttpDelete("deleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var cark = await _product.GetProductById(id);

            //check if Exist : 
            if (cark != null)
            {
                _product.Remove(cark);
                await _product.SaveChanges();

                return Ok("Item Deleted Successfuly...");
            }
            else
            {
                return NotFound();
            }
        }

    }
}
