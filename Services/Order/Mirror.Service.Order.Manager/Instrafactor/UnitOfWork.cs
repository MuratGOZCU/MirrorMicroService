using System;
using Mirror.Service.Order.Data.Context;
using Mirror.Service.Order.Manager.Service;

namespace Mirror.Service.Order.Manager.Instrafactor
{
	public class UnitOfWork : IUnitOfWork, IDisposable
	{
		private readonly MirrorDbContext _context;
        public IOrderService OrderService { get; private set; }

		public UnitOfWork(MirrorDbContext dbContext)
		{
            _context = dbContext;
            OrderService = new OrderService(_context);
		}


        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

