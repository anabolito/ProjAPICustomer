using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using ProjAPICustomer.Config;


namespace ProjAPICustomer.Models
{
    public class Address
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public City City { get; set; }
    }
}
