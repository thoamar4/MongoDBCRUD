using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersApi.Models
{
    public class geolist
    {
        [BsonElement("lat")]
        public string lat { get; set; }
        [BsonElement("lng")]
        public string lng { get; set; }
       
    }
}
