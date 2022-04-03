using System;
using Core.Mirror.Core.Model;

namespace Mirror.Service.Basket.Services
{
	public interface IBasketService
	{
		Task<MirrorResponse<Entity.Basket>> GetByUserId(string userId);
		Task<MirrorResponse<bool>> AddOrUpdate(Entity.Basket basket);
		Task<MirrorResponse<bool>> DeleteByUserId(string userId);
	}
}

