using MongoDB.Driver;
using ProjAPICustomer.Config;
using ProjAPICustomer.Models;

namespace ProjAPICustomer.Services
{
    public class CityService
    {
        private readonly IMongoCollection<City> _city;

        public CityService(IProjCustomerSettings settings)
        {
            var city = new MongoClient(settings.ConnectionString);
            var database = city.GetDatabase(settings.DatabaseName);
            _city = database.GetCollection<City>(settings.CityCollectionName);
        }

        public List<City> Get()
        {
            return _city.Find(c => true).ToList();
        }

        public City Get(string id)
        {
            return _city.Find<City>(c => c.Id == id).FirstOrDefault();
        }

        public City Create(City city)
        {
            _city.InsertOne(city);
            return city;
        }

        public void Update(string id, City city) => _city.ReplaceOne(c => c.Id == id, city);
        public void Delete(string id) => _city.DeleteOne(c => c.Id == id);



    }
}
