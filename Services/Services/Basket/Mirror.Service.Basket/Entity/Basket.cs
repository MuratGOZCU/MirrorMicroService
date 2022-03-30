using System;
namespace Mirror.Service.Basket.Entity
{
	public class Basket
	{
		public Basket()
		{
		}

        public string UserId { get; set; }
        public string DiscountCode { get; set; }
        public List<BasketItem> BasketItems { get; set; }
        public decimal Total
        {
            get => BasketItems.Sum(x => x.Price * x.Quantity);
        }

    }
}

