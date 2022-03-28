using System;
using Core.Mirror.Core.Model;
using Mirror.Service.Catalog.Entity;
using Mirror.Service.Catalog.Model;

namespace Mirror.Service.Catalog.Services.ProductService
{
	public interface IProductService
	{
		Task<MirrorResponse<List<Product>>> GetAllAsync(string categoryId);
		Task<MirrorResponse<ProductModel>> GetById(string id);
		Task<MirrorResponse<ProductModel>> CreateOrUpdae(ProductModel productModel);
	}
}

