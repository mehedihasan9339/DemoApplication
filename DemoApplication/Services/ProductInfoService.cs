using DemoApplication.Context;
using DemoApplication.Data.Entity;
using DemoApplication.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApplication.Services
{
	public class ProductInfoService : IProductInfo
	{
		private readonly databaseContext _context;

		public ProductInfoService(databaseContext context)
		{
			_context = context;
		}

		#region Basic_Actions
		public async Task<int> DeleteProductById(int id)
		{
			var data = _context.products.Find(id);
			_context.products.Remove(data);
			return await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Product>> GetAllProducts()
		{
			return await _context.products.AsNoTracking().OrderBy(x => x.Name).ToListAsync();
		}

		public async Task<Product> GetProductById(int id)
		{
			return await _context.products.FindAsync(id);
		}

		public async Task<int> SaveProduct(Product model)
		{
			if (model.Id != 0)
			{
				_context.products.Update(model);
			}
			else
			{
				_context.products.Add(model);
			}
			return await _context.SaveChangesAsync();
		}
		#endregion
	}
}
