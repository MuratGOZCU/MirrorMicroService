using System;
using MassTransit;
using Mirror.Core.Messages;
using Mirror.Service.Order.Core.Model;

namespace Mirror.Service.Order.Api.Consumers
{
	public class CreateOrderMessageConsumer : IConsumer<CreateOrderCommandMessage>
    {
		

        public async Task Consume(ConsumeContext<CreateOrderCommandMessage> context)
        {
            var buyerId = context.Message.BuyerId;
            var Id = context.Message.Id;

        }
    }
}

