using System;
using System.Text.Json;
using Core.Mirror.Core.Enums;
using Core.Mirror.Core.Model;
using Mirror.Service.Basket.Redis;

namespace Mirror.Service.Basket.Services
{
	public class BasketService : IBasketService
	{
        private readonly RedisManager _redisManager;

        public BasketService(RedisManager redisManager)
        {
            _redisManager = redisManager;
        }

        public async Task<MirrorResponse<bool>> AddOrUpdate(Entity.Basket basket)
        {
            var status = await _redisManager.GetDb().StringSetAsync(basket.UserId, JsonSerializer.Serialize(basket));
            return MirrorResponse<bool>.MirrorResult(true, ApiResponseEnum.Success, "OK");
        }

        public async Task<MirrorResponse<bool>> DeleteByUserId(string userId)
        {
            var delete = await _redisManager.GetDb().KeyDeleteAsync(userId);
            return MirrorResponse<bool>.MirrorResult(true, ApiResponseEnum.Success, "OK");
        }

        public async Task<MirrorResponse<Entity.Basket>> GetByUserId(string userId)
        {
            var getBasket = await _redisManager.GetDb().StringGetAsync(userId);
            if (string.IsNullOrEmpty(getBasket))
                return MirrorResponse<Entity.Basket>.MirrorResult(null, ApiResponseEnum.NotFound, "Basket Not Found");

            return MirrorResponse<Entity.Basket>.MirrorResult(JsonSerializer.Deserialize<Entity.Basket>(getBasket), ApiResponseEnum.Success, "OK");

        }
    }
}

