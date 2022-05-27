using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoApplication.Areas.Purchase.Models;
using DemoApplication.Data.Entity;
using DemoApplication.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DemoApplication.Areas.Purchase.Controllers
{
	[Area("Purchase")]
    public class PurchaseInfoController : Controller
    {
		private readonly IProductInfo productInfoService;
		private readonly IPurchaseInfo purchaseInfoService;

		public PurchaseInfoController(IProductInfo productInfoService, IPurchaseInfo purchaseInfoService)
		{
			this.productInfoService = productInfoService;
			this.purchaseInfoService = purchaseInfoService;
		}

		public async Task<IActionResult> Index()
        {
			var data = new PurchaseInfoViewModel
			{
				products = await productInfoService.GetAllProducts()
			};

			return View(data);
        }

		[HttpPost]
		public async Task<IActionResult> AddPurchase(PurchaseInfoViewModel model)
		{
			var product = await productInfoService.GetProductById((int)model.productId);

			var data = new PurchaseInfoViewModel
			{
				Id = 0,
				productId = model.productId,
				productName = product.Name,
				quantity = model.quantity,
				totalPrice = model.quantity * product.price
			};
			return Json(data);
		}

		public async Task<IActionResult> SavePurchase(PurchaseInfoViewModel model)
		{
			try
			{
				var rnd = new Random();
				var proCode = "C-" + rnd.Next(1000, 9999).ToString();
				var pMaster = new PurchaseMaster
				{
					Id = 0,
					code = proCode,
					purchaseDate = DateTime.Now,
					totalQuantity = (int)model.totalPurchaseQty
				};
				var masterId = await purchaseInfoService.SavePurchaseMaster(pMaster);

				for (int i = 0; i < model.proId.Length; i++)
				{
					var data = new PurchaseDetail
					{
						Id = 0,
						productId = model.proId[i],
						quantity = model.qty[i],
						totalPrice = model.tPrice[i],
						purchaseMasterId = masterId
					};
					await purchaseInfoService.SavePurchaseDetail(data);
				}
				return Json(proCode);
			}
			catch (Exception ex)
			{
				return Json("failed");
			}
		}

		public async Task<IActionResult> GetPurchaseHistoryById(string code)
		{
			var master = await purchaseInfoService.GetPurchaseMasterByCode(code);
			var details = await purchaseInfoService.GetPurchaseDetailByMasterId(master.Id);
			return Json(details);
		}
	}
}