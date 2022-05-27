using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApplication.Data.Entity
{
	public class Product:Base
	{
		public string ProductCode { get; set; }
		public string Name { get; set; }
		public decimal? price { get; set; }
	}
}
