using MongoDB.Driver;
using recordXAPI.Models;
using recordXAPI.Configurations;

namespace recordXAPI.Services
{
    public class CustomerService
    {
        private readonly IMongoCollection<Customer> _customers;

        public CustomerService(IDatabaseSettings settings)
        {
            ArgumentNullException.ThrowIfNull(settings);
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _customers = database.GetCollection<Customer>("Accounts");
        }

        public List<Customer> Get() => _customers.Find(customer => true).ToList();

        public Customer Get(string id) => _customers.Find(customer => customer.Id == id).FirstOrDefault();

        public Customer Create(Customer customer)
        {
            _customers.InsertOne(customer);
            return customer;
        }

        public void Update(string id, Customer customerIn) => _customers.ReplaceOne(customer => customer.Id == id, customerIn);

        public void Remove(string id) => _customers.DeleteOne(customer => customer.Id == id);
    }
}
