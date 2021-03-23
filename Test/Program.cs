using System;
using MongoDB;
using Database;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.MongoDB.MongoDBConnect();
        }
    }
}
