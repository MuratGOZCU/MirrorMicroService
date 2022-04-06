using System;
using Mirror.Service.Order.Core.Abstract;

namespace Mirror.Service.Order.Core.Entity
{
	public class Address : BaseEntity
	{
        public string Name { get; private set; }

        public string Surname { get; private set; }

        public string Email { get; private set; }

        public string Phone { get; private set; }

        public string City { get; private set; }
        public string District { get; private set; }
        public string AddreesDetail { get; set; }
    }
}

