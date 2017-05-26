using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrpcService.Impl.Repositories
{
    public class DataContext : IDataContext
    {
        private readonly IMongoDatabase _database;


        public DataContext(IConfigurationRoot config)
        {
            //注意：连接字符串中如果指定数据库，在以下写法会报错，例如
            //"mongodb": "mongodb://root1:root1@192.168.1.132:27017/GrpcDb"
            var client = new MongoClient(config.GetConnectionString("mongodb"));
            _database = client.GetDatabase("GrpcDb");
        }

        public IMongoDatabase Database { get { return _database; } }


        private bool disposed = false;

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }
    }
}
