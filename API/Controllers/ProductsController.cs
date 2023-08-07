using Infrastructure.Data;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProductsAsync()
        {
            return Ok(await _repository.GetProductsAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductByIdAsync(int id)
        {
            return await _repository.GetProductByIdAsync(id);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<Product>> GetProductsBrands()
        {
            return Ok(await _repository.GetProductsBrandsAsync());
        }
        [HttpGet("types")]
        public async Task<ActionResult<Product>> GetProductsTypes()
        {
            return Ok(await _repository.GetProductsTypeAsync());
        }
    }
}