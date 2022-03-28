using System;
namespace Mirror.Service.Catalog.Model
{
	public class ProductModel
	{
       
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Picture { get; set; }
        public DateTime CreateTime { get; set; }
        public string UserId { get; set; }

        public string CategoryId { get; set; }
        public ProductDetailModel ProductDetail { get; set; }
        public CategoryModel Category { get; set; }
    }
}

