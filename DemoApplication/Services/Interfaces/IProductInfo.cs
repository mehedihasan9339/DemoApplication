using DemoApplication.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApplication.Services.Interfaces
{
	public interface IProductInfo
	{
		#region Basic_Actions
		Task<int> SaveProduct(Product model);
		Task<IEnumerable<Product>> GetAllProducts();
		Task<Product> GetProductById(int id);
		Task<int> DeleteProductById(int id);
		#endregion
	}
}
