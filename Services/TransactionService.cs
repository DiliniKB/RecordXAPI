using MongoDB.Driver;
using recordXAPI.Models;
using recordXAPI.Configurations;

namespace recordXAPI.Services
{
    public class TransactionService
    {
        private readonly IMongoCollection<Transaction> _transactions;

        public TransactionService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _transactions = database.GetCollection<Transaction>("Transactions");
        }

        public List<Transaction> Get() => _transactions.Find(transaction => true).ToList();

        public Transaction Get(string id) => _transactions.Find(transaction => transaction.Id == id).FirstOrDefault();

        public Transaction Create(Transaction transaction)
        {
            _transactions.InsertOne(transaction);
            return transaction;
        }

        public void Update(string id, Transaction transactionIn) => _transactions.ReplaceOne(transaction => transaction.Id == id, transactionIn);

        public void Remove(string id) => _transactions.DeleteOne(transaction => transaction.Id == id);
    }
}
