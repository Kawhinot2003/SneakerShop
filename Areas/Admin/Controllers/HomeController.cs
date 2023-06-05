using Microsoft.AspNetCore.Mvc;
using SneakerShop.Models.Entities;
using SneakerShop.Models.PageModels;
using SneakerShop.Services.Interfaces;

namespace SneakerShop.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class HomeController : Controller
	{

		private IGoodsService _GoodsService;
		private IDiscountsService _DiscountsService;
		private IBasketService _BasketService;
		private IOrdersService _OrdersService;
		private ISizeService _SizeService;

		public HomeController(IGoodsService goodsService, IDiscountsService discountsService, 
			IBasketService basketService, IOrdersService ordersService, ISizeService sizeService)
		{
			_GoodsService = goodsService;
			_DiscountsService = discountsService;
			_BasketService = basketService;
			_OrdersService = ordersService;
			_SizeService = sizeService;
		}

		public IActionResult AllActions()
		{
			return View();
		}

		#region Goods

		public IActionResult GoodCategories()
		{
			var pageModel = new AdminIndexPageModel();
			pageModel.GoodCategories = _GoodsService.GetAllGoodCategories();
			return View(pageModel);
		}

		public IActionResult AddGoodCategory()
		{
			return View(new GoodCategory());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult AddGoodCategory(GoodCategory goodCategory)
		{
			_GoodsService.AddGoodCategory(goodCategory);
			var pageModel = new AdminIndexPageModel();
			pageModel.GoodCategories = _GoodsService.GetAllGoodCategories();
			return RedirectToAction("GoodCategories", "Home");
		}

		public IActionResult EditGoodCategory(int id)
		{
			return View(_GoodsService.GetGoodCategory(id));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult EditGoodCategory(GoodCategory goodCategory)
		{
			_GoodsService.EditGoodCategory(goodCategory);
			var pageModel = new AdminIndexPageModel();
			pageModel.GoodCategories = _GoodsService.GetAllGoodCategories();
			return RedirectToAction("GoodCategories", "Home");
		}

		public IActionResult DeleteGoodCategory(int id)
		{
			_GoodsService.DeleteGoodCategory(id);
			return RedirectToAction("GoodCategories", "Home");
		}

		public IActionResult Goods()
		{
			var pageModel = new AdminIndexPageModel();
			pageModel.Goods = _GoodsService.GetAllGoods();
			return View(pageModel);
		}
		public IActionResult AddGood()
		{
			return View();
		}
		public IActionResult DeleteGood()
		{
			return View();
		}
		public IActionResult EditGood()
		{
			return View();
		}

		#endregion

		#region Discounts

		public IActionResult DiscountTypes()
		{
			var pageModel = new AdminIndexPageModel();
			pageModel.DiscountTypes = _DiscountsService.GetAllDiscountTypes();
			return View(pageModel);
		}

		public IActionResult Discounts()
		{
			var pageModel = new AdminIndexPageModel();
			pageModel.Discounts = _DiscountsService.GetAllDiscounts();
			return View(pageModel);
		}

		#endregion

		public IActionResult Manufacturers()
		{
			var pageModel = new AdminIndexPageModel();
			pageModel.Manufacturers = _GoodsService.GetAllManufacturers();
			return View(pageModel);
		}

		public IActionResult Sizes()
		{
			var pageModel = new AdminIndexPageModel();
			pageModel.Sizes = _SizeService.GetAll();
			return View(pageModel);
		}

		public IActionResult Basket()
		{
			var pageModel = new AdminIndexPageModel();
			pageModel.Basket = _BasketService.GetAll();
			return View(pageModel);
		}

		#region Orders

		public IActionResult OrderTypes()
		{
			var pageModel = new AdminIndexPageModel();
			pageModel.OrderTypes = _OrdersService.GetAllOrderTypes();
			return View(pageModel);
		}

		public IActionResult Orders()
		{
			var pageModel = new AdminIndexPageModel();
			pageModel.Orders = _OrdersService.GetAllOrders();
			return View(pageModel);
		}

		public IActionResult OrderedGoods()
		{
			var pageModel = new AdminIndexPageModel();
			pageModel.OrderedGoods = _OrdersService.GetAllOrderedGoods();
			return View(pageModel);
		}

		#endregion

	}
}