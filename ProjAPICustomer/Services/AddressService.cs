using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProjAPICustomer.Config;
using ProjAPICustomer.Models;

namespace ProjAPICustomer.Services
{
    public class AddressService
    {
        private readonly IMongoCollection<Address> _address;

        public AddressService(IProjCustomerSettings settings)
        {
            var address = new MongoClient(settings.ConnectionString);
            var database = address.GetDatabase(settings.DatabaseName);
            _address = database.GetCollection<Address>(settings.AddressCollectionName);
        }

        public List<Address> Get()
        {
            return _address.Find(a => true).ToList();
        }

        public Address Get(string id)
        {
            return _address.Find<Address>(c => c.Id == id).FirstOrDefault();
        }

        public Address Create(Address address)
        {
            _address.InsertOne(address);
            return address;
        }

        public void Update(string id, Address address) => _address.ReplaceOne(a => a.Id == id, address);
        public void Delete(string id) => _address.DeleteOne(a => a.Id == id);
    }
}
