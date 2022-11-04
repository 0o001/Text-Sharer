using System;
using Microsoft.AspNetCore.WebUtilities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TextSharer.Models
{
    public class Base
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public DateTime CreatedAt => DateTime.Now;
        public bool IsDeleted { get; set; }
    }
}
