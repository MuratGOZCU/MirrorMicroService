using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Mirror.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Mirror.Service.Catalog.Entity;
using Mirror.Service.Catalog.Model;
using Mirror.Service.Catalog.Services.ProductService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mirror.Service.Catalog.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: api/values
        [HttpGet("api/Product/GetByCategoryId/{categoryId}")]
        public async Task<MirrorResponse<List<Product>>> GetByCategoryId(string categoryId)
        {
            if (categoryId== "0")
            {
                categoryId = null;
            }
            return await _productService.GetAllAsync(categoryId);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<MirrorResponse<ProductModel>> Get(string id)
        {
            return await _productService.GetById(id);
        }

        // POST api/values
        [HttpPost]
        public async Task<MirrorResponse<ProductModel>> Post([FromBody]ProductModel productModel)
        {
           return await _productService.CreateOrUpdae(productModel);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<MirrorResponse<ProductModel>> Put([FromBody] ProductModel productModel)
        {
            return await _productService.CreateOrUpdae(productModel);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}

