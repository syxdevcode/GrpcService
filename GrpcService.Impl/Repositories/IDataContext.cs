using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrpcService.Impl.Repositories
{
    /// <summary>
    /// 数据库上下文
    /// </summary>
    public interface IDataContext : IDisposable
    {
        IMongoDatabase Database { get; }
    }
}
