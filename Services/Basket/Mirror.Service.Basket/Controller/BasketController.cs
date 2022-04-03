using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Mirror.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Mirror.Service.Basket.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mirror.Service.Basket.Controller
{
    [Route("api/[controller]")]
    public class BasketController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }


        // GET api/values/5
        [HttpGet("{userId}")]
        public async Task<MirrorResponse<Entity.Basket>> Get(string userId)
        {
            return await _basketService.GetByUserId(userId);
        }

        // POST api/values
        [HttpPost]
        public async Task<MirrorResponse<bool>> Post([FromBody] Entity.Basket basket)
        {
            return await _basketService.AddOrUpdate(basket);
        }

        // DELETE api/values/5
        [HttpDelete("{userId}")]
        public async Task<MirrorResponse<bool>> Delete(string userId)
        {
            return await _basketService.DeleteByUserId(userId);
        }
    }
}

