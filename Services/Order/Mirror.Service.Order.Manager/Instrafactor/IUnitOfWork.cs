using System;
using Mirror.Service.Order.Manager.Service;

namespace Mirror.Service.Order.Manager.Instrafactor
{
	public interface IUnitOfWork
	{
		IOrderService OrderService { get; }

		Task CompleteAsync();
	}
}

