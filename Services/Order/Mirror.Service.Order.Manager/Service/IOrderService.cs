using System;
using Mirror.Service.Order.Core.Abstract;

namespace Mirror.Service.Order.Manager.Service
{
	public interface IOrderService : IRepository<Mirror.Service.Order.Core.Entity.Order> 
	{
	}
}

