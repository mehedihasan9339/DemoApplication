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
	public class PurchaseInfoService : IPurchaseInfo
	{
		private readonly databaseContext _context;

		public PurchaseInfoService(databaseContext context)
		{
			_context = context;
		}

		#region Basic_Actions
		public async Task<int> DeletePurchaseDetailById(int id)
		{
			var data = _context.purchaseDetails.Find(id);
			_context.purchaseDetails.Remove(data);
			return await _context.SaveChangesAsync();
		}

		public async Task<int> DeletePurchaseMasterById(int id)
		{
			var data = _context.purchaseMasters.Find(id);
			_context.purchaseMasters.Remove(data);
			return await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<PurchaseDetail>> GetAllPurchaseDetail()
		{
			return await _context.purchaseDetails.AsNoTracking().ToListAsync();
		}

		public async Task<IEnumerable<PurchaseMaster>> GetAllPurchaseMaster()
		{
			return await _context.purchaseMasters.AsNoTracking().ToListAsync();
		}

		public async Task<PurchaseDetail> GetPurchaseDetailById(int id)
		{
			return await _context.purchaseDetails.FindAsync(id);
		}

		public async Task<PurchaseMaster> GetPurchaseMasterById(int id)
		{
			return await _context.purchaseMasters.FindAsync(id);
		}

		public async Task<int> SavePurchaseDetail(PurchaseDetail model)
		{
			if (model.Id != 0)
			{
				_context.purchaseDetails.Update(model);
			}
			else
			{
				_context.purchaseDetails.Add(model);
			}
			return await _context.SaveChangesAsync();
		}

		public async Task<int> SavePurchaseMaster(PurchaseMaster model)
		{
			if (model.Id != 0)
			{
				_context.purchaseMasters.Update(model);
			}
			else
			{
				_context.purchaseMasters.Add(model);
			}
			await _context.SaveChangesAsync();

			return model.Id;
		}
		#endregion

		public async Task<PurchaseMaster> GetPurchaseMasterByCode(string code)
		{
			var data = await _context.purchaseMasters.Where(x => x.code == code).AsNoTracking().FirstOrDefaultAsync();
			return data;
		}

		public async Task<IEnumerable<PurchaseDetail>> GetPurchaseDetailByMasterId(int id)
		{
			var data = await _context.purchaseDetails.Include(x => x.product).Include(x => x.purchaseMaster).Where(x => x.purchaseMasterId == id).AsNoTracking().ToListAsync();
			return data;
		}
	}
}
