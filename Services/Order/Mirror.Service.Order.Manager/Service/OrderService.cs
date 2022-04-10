using System;
using System.Linq.Expressions;
using Mirror.Service.Order.Core.Abstract;
using Mirror.Service.Order.Data.Abstract;
using Mirror.Service.Order.Data.Context;

namespace Mirror.Service.Order.Manager.Service
{
	public class OrderService : Repository<Mirror.Service.Order.Core.Entity.Order>, IOrderService 
	{
		public OrderService(MirrorDbContext mirrorDbContext): base(mirrorDbContext)
		{
		}

        
    }
}

