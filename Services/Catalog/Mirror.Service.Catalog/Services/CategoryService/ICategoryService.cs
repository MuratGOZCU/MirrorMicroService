using System;
using Core.Mirror.Core.Model;
using Mirror.Service.Catalog.Model;

namespace Mirror.Service.Catalog.Services.CategoryService
{
	public interface ICategoryService
	{
		Task<MirrorResponse<List<CategoryModel>>> GetAllAsync();
		Task<MirrorResponse<CategoryModel>> CreateAsync(CategoryModel categoryModel);
		Task<MirrorResponse<CategoryModel>> GetByIdAsync(string id);
		Task<MirrorResponse<bool>> DeleteAsync(string id);
	}
}

