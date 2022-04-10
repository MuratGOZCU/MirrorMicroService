using System;
using AutoMapper;
using Mirror.Service.Order.Core.Model;

namespace Mirror.Service.Order.Api.Mapper
{
	public class AutoMap : Profile
	{
		public AutoMap()
		{
			CreateMap<Core.Entity.Order, OrderModel>().ReverseMap();

		}


	}
}

