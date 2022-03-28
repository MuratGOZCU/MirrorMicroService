using System;
using AutoMapper;
using Core.Mirror.Core.Enums;
using Core.Mirror.Core.Model;
using Mirror.Service.Catalog.Congifration;
using Mirror.Service.Catalog.Entity;
using Mirror.Service.Catalog.Model;
using MongoDB.Driver;

namespace Mirror.Service.Catalog.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMongoCollection<ProductDetail> _ProductDetailCollection;
        private readonly IMapper _mapper; 

        public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProeductCollectionName);
            _ProductDetailCollection = database.GetCollection<ProductDetail>(databaseSettings.ProductDetailColeectionName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task<MirrorResponse<ProductModel>> CreateOrUpdae(ProductModel productModel)
        {
            var modelToEntityMap = _mapper.Map<Product>(productModel);

            if (productModel.Id == null)
            {
                await _productCollection.InsertOneAsync(modelToEntityMap);
            }
            else
            {
                await _productCollection.FindOneAndReplaceAsync(productModel.Id, modelToEntityMap);
            }
            return MirrorResponse<ProductModel>.MirrorResult(productModel, ApiResponseEnum.Success, "Ok");
        }

        public async Task<MirrorResponse<List<Product>>> GetAllAsync(string categoryId)
        {
            var products = new List<Product>();

            if (categoryId == null)
            {
                products = await _productCollection.Find<Product>(x => true).ToListAsync();
            }
            else
            {
                products = await _productCollection.Find<Product>(x => x.CategoryId == categoryId).ToListAsync();
            }

            if (products.Any())
            {
                foreach (var product in products)
                {
                    product.Category = await _categoryCollection.Find<Category>(x => x.Id == product.CategoryId).FirstOrDefaultAsync();
                    product.ProductDetail = await _ProductDetailCollection.Find<ProductDetail>(x => x.ProductId == product.Id).FirstOrDefaultAsync();
                }
            }

            //var modelToEntityMap = _mapper.Map<List<Product>>(products);
            return MirrorResponse<List<Product>>.MirrorResult(products, ApiResponseEnum.Success,"Ok");
        }

        public async Task<MirrorResponse<ProductModel>> GetById(string id)
        {
            var product = await _productCollection.Find<Product>(x => x.Id == id).FirstOrDefaultAsync();
            if (product != null)
            {
                product.Category = await _categoryCollection.Find<Category>(x => x.Id == product.CategoryId).FirstOrDefaultAsync();
                product.ProductDetail = await _ProductDetailCollection.Find<ProductDetail>(x => x.ProductId == product.Id).FirstOrDefaultAsync();

            }

            var entityToModel = _mapper.Map<ProductModel>(product);

            return MirrorResponse<ProductModel>.MirrorResult(entityToModel, ApiResponseEnum.Success, "Ok");

        }
    }
}

