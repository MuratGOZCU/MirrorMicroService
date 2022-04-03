using System;
namespace Mirror.Service.Basket.Settings
{
	public class RedisSetting : IRedisSetting
	{
        public string Host { get; set; }
        public string Port { get; set; }
    }
}

