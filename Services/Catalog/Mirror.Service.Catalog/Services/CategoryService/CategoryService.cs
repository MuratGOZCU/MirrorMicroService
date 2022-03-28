using System;
using AutoMapper;
using Core.Mirror.Core.Model;
using Mirror.Service.Catalog.Congifration;
using Mirror.Service.Catalog.Entity;
using Mirror.Service.Catalog.Model;
using MongoDB.Driver;

namespace Mirror.Service.Catalog.Services.CategoryService
{
	public class CategoryService : ICategoryService
	{
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings dataBaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(dataBaseSettings.ConnectionString);
            var database = client.GetDatabase(dataBaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(dataBaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task<MirrorResponse<CategoryModel>> CreateAsync(CategoryModel categoryModel)
        {
            var categories = await _categoryCollection.Find<Category>(x => x.Id == categoryModel.Id).FirstOrDefaultAsync();
            if (categories == null)
            {
                await _categoryCollection.InsertOneAsync(_mapper.Map<Category>(categoryModel));
            }
            else
            {
                var category = _mapper.Map<Category>(categoryModel);
                var result = await _categoryCollection.FindOneAndReplaceAsync(x => x.Id == categoryModel.Id, category);
            }
            return MirrorResponse<CategoryModel>.MirrorResult(categoryModel, Core.Mirror.Core.Enums.ApiResponseEnum.Success, "OK");
        }

        public async Task<MirrorResponse<List<CategoryModel>>> GetAllAsync()
        {
            var categories = await _categoryCollection.Find<Category>(x => true).ToListAsync();
            return MirrorResponse<List<CategoryModel>>.MirrorResult(_mapper.Map<List<CategoryModel>>(categories), Core.Mirror.Core.Enums.ApiResponseEnum.Success, "Ok");

        }

        public async Task<MirrorResponse<CategoryModel>> GetByIdAsync(string id)
        {
            var category = await _categoryCollection.Find<Category>(x => x.Id == id).FirstOrDefaultAsync();
            return MirrorResponse<CategoryModel>.MirrorResult(_mapper.Map<CategoryModel>(category), Core.Mirror.Core.Enums.ApiResponseEnum.Success, "Ok");
           
        }

        public async Task<MirrorResponse<bool>> DeleteAsync(string id)
        {
            var delete = await _categoryCollection.DeleteOneAsync(x => x.Id == id);
            return MirrorResponse<bool>.MirrorResult(true, Core.Mirror.Core.Enums.ApiResponseEnum.Success, "Ok");


        }
    }
}

