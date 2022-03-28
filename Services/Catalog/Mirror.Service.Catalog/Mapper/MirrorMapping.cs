using System;
using AutoMapper;
using Mirror.Service.Catalog.Entity;
using Mirror.Service.Catalog.Model;

namespace Mirror.Service.Catalog.Mapper
{
	public class MirrorMapping:Profile
	{
		public MirrorMapping()
		{
			CreateMap<Category, CategoryModel>().ReverseMap();
			CreateMap<Product, ProductModel>().ReverseMap();
			CreateMap<ProductDetail, ProductDetailModel>().ReverseMap();
		}
	}
}

