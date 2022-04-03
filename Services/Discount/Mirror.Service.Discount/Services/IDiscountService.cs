using System;
using Core.Mirror.Core.Model;

namespace Mirror.Service.Discount.Services
{
	public interface IDiscountService
	{
		Task<MirrorResponse<List<Entity.Discount>>> GetAll();
		Task<MirrorResponse<Entity.Discount>> GetDiscountByUserId(string userId);
		Task<MirrorResponse<Entity.Discount>> GetDiscountByCode(string code);
		Task<MirrorResponse<int>> Save(Entity.Discount discount);
		Task<MirrorResponse<Entity.Discount>> Update(Entity.Discount discount);
		Task<MirrorResponse<bool>> DeleteById(int id);
	}
}

