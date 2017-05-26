using GrpcService.Impl;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using System;
using System.IO;

namespace GrpcService.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            string envName = string.Empty;
            var builder = new ConfigurationBuilder();
            var provider = new EnvironmentVariablesConfigurationProvider();
            provider.Load();
            if (!provider.TryGet("EnvName", out envName))
            {
                envName = "debug";
            }

            if (args != null && args.Length > 0)
                envName = args[0];

            var config = builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{envName}.json", optional: true)
                .Build();

            Console.WriteLine("service start");
            RpcConfiguration.Start(config);
            //RpcConfiguration.Stop();
        }
    }
}