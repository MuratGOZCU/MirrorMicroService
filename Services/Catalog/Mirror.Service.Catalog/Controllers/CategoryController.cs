using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mirror.Service.Catalog.Model;
using Mirror.Service.Catalog.Services.CategoryService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mirror.Service.Catalog.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<List<CategoryModel>> Get()
        {
            var categories = await _categoryService.GetAllAsync();

            return categories.Data;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<CategoryModel> Get(string id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            return category.Data;
        }

        // POST api/values
        [HttpPost]
        public async Task<CategoryModel> Post([FromBody]CategoryModel categoryModel)
        {
            var insert = await _categoryService.CreateAsync(categoryModel);
            return insert.Data;
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<CategoryModel> Put([FromBody] CategoryModel categoryModel)
        {
            var update = await _categoryService.CreateAsync(categoryModel);
            return update.Data;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(string id)
        {
            var delete = await _categoryService.DeleteAsync(id);
            return delete.Data;
        }
    }
}

