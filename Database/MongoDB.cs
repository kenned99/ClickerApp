using System;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;



namespace Database
{
    public class MongoDB
    {
        static MongoClient cnn = new MongoClient("mongodb+srv://Kenned:Password123@cluster0.dg6zy.mongodb.net/mpc?authSource=admin&retryWrites=true&w=majority");

        public static MongoClient MongoDBConnect()
        {
            var client = new MongoClient("mongodb+srv://Kenned:password123@cluster0.dg6zy.mongodb.net/mpc?authSource=admin&retryWrites=true&w=majority");
            var database = cnn.GetDatabase("mpc");

            var collection = database.GetCollection<BsonDocument>("Users");
            var data = collection.Find(new BsonDocument()).FirstOrDefault();
            Console.WriteLine(data);

            return cnn;
        }
    }

    /*public User Login(string email, string password)
    {
      //  User user = new User();
    //  Nyt user objekt
        var database = cnn.GetDatabase("mpc");
        var collection = database.GetCollection<BsonDocument>("Users");
        var filterEmail = Builders<BsonDocument>.Filter.Eq("email", email);
        var filterPassword = Builders<BsonDocument>.Filter.Eq("password", password);
        var data = collection.Find(filterEmail & filterPassword).FirstOrDefault();

        return user;
    }*/



}