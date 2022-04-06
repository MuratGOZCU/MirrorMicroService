using System;
using Mirror.Service.Order.Core.Abstract;

namespace Mirror.Service.Order.Core.Entity
{
	public class OrderItem : BaseEntity
	{

        public long OrderId { get; set; }
        public string ProductId { get; private set; }
        public string ProductName { get; private set; }
        public string PictureUrl { get; private set; }
        public Decimal Price { get; private set; }

       
    }
}

