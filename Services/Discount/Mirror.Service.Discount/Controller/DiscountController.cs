using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Mirror.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Mirror.Service.Discount.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mirror.Service.Discount.Controller
{
    [Route("api/[controller]")]
    public class DiscountController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IDiscountService _discountService;
        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        // GET: api/values
        [HttpGet]
        public async Task<MirrorResponse<List<Entity.Discount>>> Get()
        {
            var getAll = await _discountService.GetAll();
            Entity.Discount discount = new Entity.Discount()
            {
                UserId = "Mirrpr",
                Code = "123",
                Rate = 1
            };
            var insert = await _discountService.Save(discount);

            return getAll;
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

