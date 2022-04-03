using System;
using System.Data;
using Core.Mirror.Core.Enums;
using Core.Mirror.Core.Model;
using Dapper;
using Mirror.Service.Discount.Settings;
using Npgsql;

namespace Mirror.Service.Discount.Services
{
	public class DiscountService : IDiscountService
	{
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _dbConnection;

		public DiscountService(IConfiguration configuration)
		{
            _configuration = configuration;
            var dd = _configuration.GetConnectionString("PostgreSql");
            _dbConnection = new NpgsqlConnection(dd);

		}

        public Task<MirrorResponse<bool>> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<MirrorResponse<List<Entity.Discount>>> GetAll()
        {
            var discounts = await _dbConnection.QueryAsync<Entity.Discount>("select * from Discount");
            return MirrorResponse<List<Entity.Discount>>.MirrorResult(discounts.ToList(), ApiResponseEnum.Success, "Ok");
        }

        public Task<MirrorResponse<Entity.Discount>> GetDiscountByCode(string code)
        {
            throw new NotImplementedException();
        }

        public Task<MirrorResponse<Entity.Discount>> GetDiscountByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<MirrorResponse<int>> Save(Entity.Discount discount)
        {
            discount.CreatedTime = DateTime.Now;
            var sql = "INSERT INTO Discount(UserId,Rate,Code) values(@UserId,@Rate,@Code)";
            var discountInsert = await _dbConnection.ExecuteAsync(sql,
                new { UserId = discount.UserId, Code = discount.Code, Rate = discount.Rate});

            return MirrorResponse<int>.MirrorResult(discountInsert, ApiResponseEnum.Success, "OK");

            
        }

        public Task<MirrorResponse<Entity.Discount>> Update(Entity.Discount discount)
        {
            throw new NotImplementedException();
        }
    }
}

