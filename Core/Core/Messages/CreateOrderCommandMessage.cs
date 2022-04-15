using System;
namespace Mirror.Core.Messages
{
	public class CreateOrderCommandMessage
	{
        public int Id { get; set; }
        public string BuyerId { get; set; }
	}
}

