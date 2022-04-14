using UsersApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;

namespace UsersApi.Services
{
    public class UserServices
    {
        private readonly IMongoCollection<User> _UsersCollection;

        //IOptions<UserDatabaseSettings> userDatabaseSettings
        public UserServices(  )
        {
           
            //var mongoClient = new MongoClient(
            //    userDatabaseSettings.Value.ConnectionString);
            var mongoClient = new MongoClient("mongodb://localhost:27017");

            //var mongoDatabase = mongoClient.GetDatabase(
            //    userDatabaseSettings.Value.DatabaseName);
            var mongoDatabase = mongoClient.GetDatabase("employeeDB");

            //_UsersCollection = mongoDatabase.GetCollection<User>(
            //    userDatabaseSettings.Value.UsersCollectionName);
             _UsersCollection = mongoDatabase.GetCollection<User>("Users");
        }


       
        //public async Task<List<User>> GetAsync() =>
        //    await _UsersCollection.Find(_ => true).ToListAsync();

        public List<User> Get()
         {
            return _UsersCollection.Find(User => true).ToList();
        }
        public User Get(int id)
        {
            //return JsonConvert.DeserializeObject<User>(obj1);
           return   _UsersCollection.Find<User>(user => user.id== id).FirstOrDefault();
        }

        
        public User Create(User user)
        {
          
            _UsersCollection.InsertOne(user);
           
            return user;
        }
        public void Update(int id,User userIn)
        {
            _UsersCollection.ReplaceOne(user => user.id == id, userIn);
        }
        public void Remove( User userIn)
        {
            _UsersCollection.DeleteOne(user => user.id ==userIn.id);

        }


        //public async Task<User?> GetAsync(int id) =>
        //public async Task<User> GetAsync(string id) =>
        // await _UsersCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        //public async Task CreateAsync(User newUser) =>
        //    await _UsersCollection.InsertOneAsync(newUser);

        //public async Task UpdateAsync(string id,User updatedBook) =>
        //    await _UsersCollection.ReplaceOneAsync(x => x.Id== id, updatedBook);

        //public async Task RemoveAsync(string id) =>
        //    await _UsersCollection.DeleteOneAsync(x => x.Id== id);
    }
}

