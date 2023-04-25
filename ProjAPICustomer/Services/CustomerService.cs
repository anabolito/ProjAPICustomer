using MongoDB.Driver;
using ProjAPICustomer.Config;
using ProjAPICustomer.Models;

namespace ProjAPICustomer.Services
{
    public class CustomerService
    {
        private readonly IMongoCollection<Customer> _customer;

        public CustomerService(IProjCustomerSettings settings)
        {
            var customer = new MongoClient(settings.ConnectionString);
            var database = customer.GetDatabase(settings.DatabaseName);
            _customer = database.GetCollection<Customer>(settings.CustomerCollectionName);
        }

        public List<Customer> Get()
        {
            return _customer.Find(a => true).ToList();
        }

        public Customer Get(string id)
        {
            return _customer.Find<Customer>(c => c.Id == id).FirstOrDefault();
        }

        public Customer Create(Customer customer)
        {
            _customer.InsertOne(customer);
            return customer;
        }

        public void Update(string id, Customer customer) => _customer.ReplaceOne(a => a.Id == id, customer);
        public void Delete(string id) => _customer.DeleteOne(a => a.Id == id);

    }
}
