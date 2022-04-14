using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersApi.Models
{
    public class companylist
    {
        [BsonElement("name")]
        public string name { get; set; }
        [BsonElement("catchPhrase")]
        public string catchPhrase { get; set; }
        [BsonElement("bs")]
        public string bs { get; set; }
    }
}
