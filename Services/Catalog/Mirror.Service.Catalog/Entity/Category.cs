using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mirror.Service.Catalog.Entity
{
	public class Category
	{
		
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
    }
}

