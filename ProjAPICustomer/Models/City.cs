﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProjAPICustomer.Models
{
    public class City
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string  CityName { get; set; }
    }
}
