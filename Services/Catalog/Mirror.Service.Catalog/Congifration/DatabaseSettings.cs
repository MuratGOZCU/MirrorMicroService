using System;
namespace Mirror.Service.Catalog.Congifration
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string CategoryCollectionName { get; set; }
        public string ProeductCollectionName { get; set; }
        public string ProductDetailColeectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}

