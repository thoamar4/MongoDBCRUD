
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace UsersApi.Models
{
   [BsonIgnoreExtraElements]
    public class User
    {

        
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        [BsonElement("id")]
        public int id { get; set; }
        [BsonElement("name")]
        public string name { get; set; }
        [BsonElement("username")]
        public string Username { get; set; }
        [BsonElement("email")]
        public string email { get; set; }
       [BsonElement("address")]
       //[BsonElementAttribute("address")]
       public List<addresslist> address { get; set; }
       
        [BsonElement("phone")]
        public string phone { get; set; }
        [BsonElement("website")]
        public string website { get; set; }
        [BsonElement("company")]
        //[BsonElementAttribute("address")]
        public List<companylist> company { get; set; }



    }
}
