using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersApi.Models
{
    public class addresslist
    {
        //[BsonRepresentation(BsonType.ObjectId)]
        //public string _id { get; set; }
        [BsonElement("street")]
        public string street { get; set; }
        [BsonElement(" suite")]
        public string suite { get; set; }
        [BsonElement("city")]
        public string city { get; set; }
        [BsonElement("zipcode")]
        public string zipcode { get; set; }
        [BsonElement("geo")]
        public List<geolist> geo { get; set; }


    }
}
