using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace recordXAPI.Models
{
    public class Customer
    {
        public Customer()
        {
            Id = string.Empty;
            Name = string.Empty;
            NIC = string.Empty;
            Location = string.Empty;
            Job = string.Empty;
            DOB = DateTime.Today;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string Id { get; set; }

        [BsonElement("NIC")]
        public string NIC { get; set; }

        [BsonElement("DOB")]
        public DateTime DOB { get; set; }

        [BsonElement("Job")]
        public string Job { get; set; }

        [BsonElement("Location")]
        public string Location { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }
    }
}