using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mirror.Service.Order.Core.Model;
using Mirror.Service.Order.Manager.Instrafactor;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mirror.Service.Order.Api.Controllers
{
    

    [Route("api/[controller]")]
    public class OrderController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OrderController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<Core.Entity.Order>> Get()
        {
            return await _unitOfWork.OrderService.Query().Where(x=>x.Id != 0).ToListAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<OrderModel> Post([FromBody] OrderModel order)
        {
            _unitOfWork.OrderService.Create(_mapper.Map<Core.Entity.Order>(order));
            
            await _unitOfWork.CompleteAsync();

            return order;
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

