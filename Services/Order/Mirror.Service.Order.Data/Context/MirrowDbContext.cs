using System;
using Microsoft.EntityFrameworkCore;
using Mirror.Service.Order.Core;

namespace Mirror.Service.Order.Data.Context
{
	public class MirrowDbContext : DbContext
	{
		public MirrowDbContext(DbContextOptions<MirrowDbContext> options) : base(options)
		{
		}


        public DbSet<Mirror.Service.Order.Core.Entity.Order> Order { get; set; }
        public DbSet<Mirror.Service.Order.Core.Entity.OrderItem> OrderItem { get; set; }
        public DbSet<Mirror.Service.Order.Core.Entity.Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

