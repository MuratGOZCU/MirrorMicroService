using System;
namespace Mirror.Service.Discount.Entity
{
    [Dapper.Contrib.Extensions.Table("Discount")]
	public class Discount
	{
        public int id { get; set; }
        public string UserId { get; set; }
        public int Rate { get; set; }
        public string Code { get; set; }
        public DateTime CreatedTime { get; set; }

    }
}

