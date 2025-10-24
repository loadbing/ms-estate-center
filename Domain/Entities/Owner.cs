using System.Collections;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ms_estate_center.Domain.Entities
{
    public class Owner
    {
        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("phone")]
        public string Phone { get; set; } = string.Empty;
    }
}

