using System;
using StackExchange.Redis;

namespace Mirror.Service.Basket.Redis
{
	public class RedisManager
	{
        private readonly string _host;
        private readonly string _port;

        private ConnectionMultiplexer _connectionMultiplexer;

        public RedisManager(string host, string port)
        {
            _host = host;
            _port = port;
        }

        public void Connect()
        {
             _connectionMultiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port}");
        }

        public IDatabase GetDb(int db = 1) => _connectionMultiplexer.GetDatabase(db);
        
    }
}

