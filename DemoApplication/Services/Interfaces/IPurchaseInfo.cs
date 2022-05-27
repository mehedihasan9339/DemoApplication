using DemoApplication.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApplication.Services.Interfaces
{
	public interface IPurchaseInfo
	{
		#region Basic_Actions
		Task<int> SavePurchaseMaster(PurchaseMaster model);
		Task<IEnumerable<PurchaseMaster>> GetAllPurchaseMaster();
		Task<PurchaseMaster> GetPurchaseMasterById(int id);
		Task<int> DeletePurchaseMasterById(int id);
		#endregion

		#region Basic_Actions
		Task<int> SavePurchaseDetail(PurchaseDetail model);
		Task<IEnumerable<PurchaseDetail>> GetAllPurchaseDetail();
		Task<PurchaseDetail> GetPurchaseDetailById(int id);
		Task<int> DeletePurchaseDetailById(int id);
		#endregion

		Task<PurchaseMaster> GetPurchaseMasterByCode(string code);
		Task<IEnumerable<PurchaseDetail>> GetPurchaseDetailByMasterId(int id);
	}
}
