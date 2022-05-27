using DemoApplication.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApplication.Areas.Purchase.Models
{
	public class PurchaseInfoViewModel
	{
		public int? Id { get; set; }

		public int? productId { get; set; }
		public Product product { get; set; }

		public string productName { get; set; }

		public int? quantity { get; set; }

		public decimal? totalPrice { get; set; }


		public int?[] proId { get; set; }
		public int?[] qty { get; set; }
		public decimal?[] tPrice { get; set; }

		public int? totalPurchaseQty { get; set; }
		public decimal? totalPurchasePrice { get; set; }


		public IEnumerable<Product> products { get; set; }
	}
}
