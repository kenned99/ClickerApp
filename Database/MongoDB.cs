using System;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using Model;



namespace Database
{
    public class MongoDB
    {
        public static MongoClient cnn = new MongoClient("mongodb+srv://Kenned:Password123@cluster0.dg6zy.mongodb.net/mpc?authSource=admin&retryWrites=true&w=majority");

        public static MongoClient MongoDBConnect()
        {
            var client = new MongoClient("mongodb+srv://Kenned:password123@cluster0.dg6zy.mongodb.net/mpc?authSource=admin&retryWrites=true&w=majority");
            var database = cnn.GetDatabase("mpc");
            if (database != null)
            {
                Console.WriteLine("Successfull connection");
            }
            var collection = database.GetCollection<BsonDocument>("Save");
            var data = collection.Find(new BsonDocument()).FirstOrDefault();
            Console.WriteLine(data);

            return cnn;
        }

    /*   public Save Login(string username, string password)
        {
           Save save = new Save();
        //  Nyt user objekt
            var database = cnn.GetDatabase("mpc");
            var collection = database.GetCollection<BsonDocument>("Users");
            var filterEmail = Builders<BsonDocument>.Filter.Eq("username", username);
            var filterPassword = Builders<BsonDocument>.Filter.Eq("password", password);
            var data = collection.Find(filterEmail & filterPassword).FirstOrDefault();

            return save;
        }*/

        public static Save SelectSave(string Username, string key)
        {
            Save save = new Save();
            var database = cnn.GetDatabase("mpc");
            var collection = database.GetCollection<BsonDocument>("Save");
            var filter = Builders<BsonDocument>.Filter.Eq(key, Username);

            var data = collection.Find(filter).FirstOrDefault();
           // save = SaveObject(data);

            return save;
        }

        public Save SaveObject(BsonDocument Tname)
        {
            Save save = new Save();

            save.Username = (string)Tname["Username"];

            save.katana = new Building()
            {
                amount = (double)Tname["Amount"],
                upgrades = (double)Tname["Upgrades"]
            };

            save.fedora = new Building()
            {
                amount = (double)Tname["Amount"],
                upgrades = (double)Tname["Upgrades"]
            };
            return save;
        }

        public bool AddSave(Save save)
        {
          /*  int number = 0;
            //Create random 8 bit no
            void CreateNewNumber()
            {
                var generator = new RandomGenerator();
                var New8Number = generator.RandomNumber(10000000, 99999999);
            }

        /*    CreateNewNumber();
            while (number == 0)
            {
                CreateNewNumber();
            }*/

            var database = cnn.GetDatabase("mpc");
            var collection = database.GetCollection<BsonDocument>("Save");

            var filter = Builders<BsonDocument>.Filter.Eq("Username", save.Username);
            var data = collection.Find(filter).FirstOrDefault();


            bool state = true;
            var document = new BsonDocument
            {
                { "Username", save.Username},
                { "Waifu.Amount", save.waifu.amount},
                { "Waifu.Upgrades", save.waifu.upgrades},
                { "Bodypillow.Amount", save.bodypillow.amount},
                { "Bodypillow.Upgrades", save.bodypillow.upgrades},
                { "Fedora.Amount", save.fedora.amount},
                { "Fedora.Upgrades", save.fedora.upgrades},
                { "Katana.Amount", save.katana.amount},
                { "Katana.Upgrades", save.katana.upgrades}
            };

            if (data != null)
            {
                collection.UpdateOne(filter, document);
            }

            try
            {
                collection.InsertOne(document);
            }
            catch (AggregateException aggEx)
            {
                aggEx.Handle(x =>
                {
                    var mwx = x as MongoWriteException;
                    if (mwx != null && mwx.WriteError.Category == ServerErrorCategory.DuplicateKey) //  tjekker om rec findes
                    {
                        //  created
                        state = false;
                        return false;
                    }
                    //  not created
                    state = false;
                    return false;
                });
            }
            return state;
        }

      /*  public class RandomGenerator
        {
            private readonly Random _random = new Random();

            public int RandomNumber(int min, int max)
            {
                return _random.Next(min, max);
            }
        }*/

    }
}