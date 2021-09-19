using Catalog.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configurations)
        {
            var client = new MongoClient(configurations.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configurations.GetValue<string>("DatabaseSettings:DatabaseName"));
            Products = database.GetCollection<Product>(configurations.GetValue<string>("DatabaseSettings:CollectionName"));
            CatalogContextSeed.SeedData(Products);
        }
        public IMongoCollection<Product> Products { get; }
    }
}
