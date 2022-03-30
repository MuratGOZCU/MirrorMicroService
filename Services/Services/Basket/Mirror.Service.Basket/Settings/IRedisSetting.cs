using System;
namespace Mirror.Service.Basket.Settings
{
	public interface IRedisSetting
	{
        public string Host { get; set; }
        public string Port { get; set; }
    }
}

