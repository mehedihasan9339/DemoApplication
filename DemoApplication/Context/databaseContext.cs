using DemoApplication.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApplication.Context
{
	public class databaseContext:DbContext
	{
		public databaseContext(DbContextOptions<databaseContext> options):base(options)
		{

		}

		#region DBSets
		public DbSet<Product> products { get; set; }
		public DbSet<PurchaseMaster> purchaseMasters { get; set; }
		public DbSet<PurchaseDetail> purchaseDetails { get; set; }
		#endregion
	}
}
