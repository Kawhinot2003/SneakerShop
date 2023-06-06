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

		#region GoodCategories

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

		#endregion

		#region Goods

		public IActionResult Goods()
		{
			var pageModel = new AdminIndexPageModel();
			pageModel.Goods = _GoodsService.GetAllGoods();
			return View(pageModel);
		}

		#endregion

		#region DiscountTypes

		public IActionResult DiscountTypes()
		{
			var pageModel = new AdminIndexPageModel();
			pageModel.DiscountTypes = _DiscountsService.GetAllDiscountTypes();
			return View(pageModel);
		}

		#endregion

		#region Discounts

		public IActionResult Discounts()
		{
			var pageModel = new AdminIndexPageModel();
			pageModel.Discounts = _DiscountsService.GetAllDiscounts();
			return View(pageModel);
		}

		#endregion

		#region Manufacturers

		public IActionResult Manufacturers()
		{
			var pageModel = new AdminIndexPageModel();
			pageModel.Manufacturers = _GoodsService.GetAllManufacturers();
			return View(pageModel);
		}

		public IActionResult AddManufacturer()
		{
			return View(new Manufacturer());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult AddManufacturer(Manufacturer manufacturer)
		{
			_GoodsService.AddManufacturer(manufacturer);
			var pageModel = new AdminIndexPageModel();
			pageModel.Manufacturers = _GoodsService.GetAllManufacturers();
			return RedirectToAction("Manufacturers", "Home");
		}

		public IActionResult EditManufacturer(int id)
		{
			return View(_GoodsService.GetManufacturer(id));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult EditManufacturer(Manufacturer manufacturer)
		{
			_GoodsService.EditManufacturer(manufacturer);
			var pageModel = new AdminIndexPageModel();
			pageModel.Manufacturers = _GoodsService.GetAllManufacturers();
			return RedirectToAction("Manufacturers", "Home");
		}

		public IActionResult DeleteManufacturer(int id)
		{
			_GoodsService.DeleteManufacturer(id);
			return RedirectToAction("Manufacturers", "Home");
		}

		#endregion

		#region Sizes

		public IActionResult Sizes()
		{
			var pageModel = new AdminIndexPageModel();
			pageModel.Sizes = _SizeService.GetAll();
			return View(pageModel);
		}

		#endregion

		#region Basket

		public IActionResult Basket()
		{
			var pageModel = new AdminIndexPageModel();
			pageModel.Basket = _BasketService.GetAll();
			return View(pageModel);
		}

		#endregion

		#region OrderTypes

		public IActionResult OrderTypes()
		{
			var pageModel = new AdminIndexPageModel();
			pageModel.OrderTypes = _OrdersService.GetAllOrderTypes();
			return View(pageModel);
		}

		#endregion

		#region Orders

		public IActionResult Orders()
		{
			var pageModel = new AdminIndexPageModel();
			pageModel.Orders = _OrdersService.GetAllOrders();
			return View(pageModel);
		}

		#endregion

		#region OrderedGoods

		public IActionResult OrderedGoods()
		{
			var pageModel = new AdminIndexPageModel();
			pageModel.OrderedGoods = _OrdersService.GetAllOrderedGoods();
			return View(pageModel);
		}

		#endregion

	}
}