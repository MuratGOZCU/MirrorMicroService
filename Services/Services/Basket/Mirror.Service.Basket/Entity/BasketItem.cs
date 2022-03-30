using System;
namespace Mirror.Service.Basket.Entity
{
	public class BasketItem
	{
		public BasketItem()
		{
		}

        public int Quantity { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }

    }
}

