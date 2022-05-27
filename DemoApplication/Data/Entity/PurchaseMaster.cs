using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApplication.Data.Entity
{
	public class PurchaseMaster:Base
	{
		public string code { get; set; }

		public DateTime? purchaseDate { get; set; }

		public int? totalQuantity { get; set; }
	}
}
