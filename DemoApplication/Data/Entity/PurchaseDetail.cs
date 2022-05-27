using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApplication.Data.Entity
{
	public class PurchaseDetail:Base
	{
		public int? purchaseMasterId { get; set; }
		public PurchaseMaster purchaseMaster { get; set; }

		public int? productId { get; set; }
		public Product product { get; set; }

		public int? quantity { get; set; }
		public decimal? totalPrice { get; set; }
	}
}
