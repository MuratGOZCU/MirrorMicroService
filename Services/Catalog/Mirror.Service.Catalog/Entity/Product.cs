using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Mirror.Service.Catalog.Entity
{
	public class Product
	{
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Picture { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        public DateTime CreateTime { get; set; }
        public string UserId { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string CategoryId { get; set; }
        public ProductDetail ProductDetail { get; set; }
        [BsonIgnore]
        public Category Category { get; set; }
    }
}

