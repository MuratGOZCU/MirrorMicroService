using System;
using Mirror.Service.Order.Core.Abstract;

namespace Mirror.Service.Order.Core.Entity
{
	public class Order : BaseEntity
	{
        //public DateTime CreatedDate { get; private set; }

        //public Address Address { get; private set; }

        public string BuyerId { get; set; }

        //public List<OrderItem> OrderItems { get; private set; }


    }
}

