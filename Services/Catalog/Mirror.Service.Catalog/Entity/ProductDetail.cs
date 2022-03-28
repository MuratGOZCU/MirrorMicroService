using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Mirror.Service.Catalog.Entity
{
	public class ProductDetail
	{
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Description { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string ProductId { get; set; }
    }
}

