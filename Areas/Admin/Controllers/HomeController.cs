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

		public IActionResult AddGood()
		{
			return View(new Good());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult AddGood(Good good)
		{
			_GoodsService.AddGood(good);
			var pageModel = new AdminIndexPageModel();
			pageModel.Goods = _GoodsService.GetAllGoods();
			return RedirectToAction("Goods", "Home");
		}
		public IActionResult DeleteGood(int id)
		{
			_GoodsService.DeleteGood(id);
			return RedirectToAction("Goods", "Home");
		}

		public IActionResult EditGood(int id)
		{
			return View(_GoodsService.GetGood(id));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult EditGood(Good good)
		{
			_GoodsService.EditGood(good);
			var pageModel = new AdminIndexPageModel();
			pageModel.Goods = _GoodsService.GetAllGoods();
			return RedirectToAction("Goods", "Home");
		}

		#endregion

		#region Discounts

		public IActionResult Discounts()
		{
			var pageModel = new AdminIndexPageModel();
			pageModel.Discounts = _DiscountsService.GetAllDiscounts();
			return View(pageModel);
		}

		public IActionResult AddDiscount()
		{
			return View(new Discount());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult AddDiscount(Discount discount)
		{
			_DiscountsService.AddDiscount(discount);
			var pageModel = new AdminIndexPageModel();
			pageModel.Discounts = _DiscountsService.GetAllDiscounts();
			return RedirectToAction("Discounts", "Home");
		}

		public IActionResult EditDiscount(int id)
		{
			return View(_DiscountsService.GetDiscount(id));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult EditDiscount(Discount discount)
		{
			_DiscountsService.EditDiscount(discount);
			var pageModel = new AdminIndexPageModel();
			pageModel.Discounts = _DiscountsService.GetAllDiscounts();
			return RedirectToAction("Discounts", "Home");
		}

		public IActionResult DeleteDiscount(int id)
		{
			_DiscountsService.DeleteDiscount(id);
			return RedirectToAction("Discounts", "Home");
		}

		#endregion

		#region DiscountTypes

		public IActionResult DiscountTypes()
		{
			var pageModel = new AdminIndexPageModel();
			pageModel.DiscountTypes = _DiscountsService.GetAllDiscountTypes();
			return View(pageModel);
		}

		public IActionResult AddDiscountType()
		{
			return View(new DiscountType());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult AddDiscountType(DiscountType discountType)
		{
			_DiscountsService.AddDiscountType(discountType);
			var pageModel = new AdminIndexPageModel();
			pageModel.DiscountTypes = _DiscountsService.GetAllDiscountTypes();
			return RedirectToAction("DiscountTypes", "Home");
		}

		public IActionResult EditDiscountType(int id)
		{
			return View(_DiscountsService.GetDiscountType(id));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult EditDiscountType(DiscountType discountType)
		{
			_DiscountsService.EditDiscountType(discountType);
			var pageModel = new AdminIndexPageModel();
			pageModel.DiscountTypes = _DiscountsService.GetAllDiscountTypes();
			return RedirectToAction("DiscountTypes", "Home");
		}

		public IActionResult DeleteDiscountType(int id)
		{
			_DiscountsService.DeleteDiscountType(id);
			return RedirectToAction("DiscountTypes", "Home");
		}

		#endregion

		#region Sizes

		public IActionResult Sizes()
		{
			var pageModel = new AdminIndexPageModel();
			pageModel.Sizes = _SizeService.GetAll();
			return View(pageModel);
		}

		public IActionResult AddSize()
		{
			return View(new Size());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult AddSize(Size size)
		{
			_SizeService.Add(size);
			var pageModel = new AdminIndexPageModel();
			pageModel.Sizes = _SizeService.GetAll();
			return RedirectToAction("Sizes", "Home");
		}

		public IActionResult EditSize(int id)
		{
			return View(_SizeService.Get(id));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult EditSize(Size size)
		{
			_SizeService.Edit(size);
			var pageModel = new AdminIndexPageModel();
			pageModel.Sizes = _SizeService.GetAll();
			return RedirectToAction("Sizes", "Home");
		}

		public IActionResult DeleteSize(int id)
		{
			_SizeService.Delete(id);
			return RedirectToAction("Sizes", "Home");
		}

		#endregion

		#region Basket

		public IActionResult Basket()
		{
			var pageModel = new AdminIndexPageModel();
			pageModel.Basket = _BasketService.GetAll();
			return View(pageModel);
		}

		public IActionResult AddBasketElement()
		{
			return View(new BasketElement());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult AddBasketElement(BasketElement basketElement)
		{
			_BasketService.Add(basketElement);
			var pageModel = new AdminIndexPageModel();
			pageModel.Basket = _BasketService.GetAll();
			return RedirectToAction("Basket", "Home");
		}

		public IActionResult EditBasketElement(int id)
		{
			return View(_BasketService.Get(id));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult EditBasketElement(BasketElement basketElement)
		{
			_BasketService.Edit(basketElement);
			var pageModel = new AdminIndexPageModel();
			pageModel.Basket = _BasketService.GetAll();
			return RedirectToAction("Basket", "Home");
		}
		public IActionResult DeleteBasketElement(int id)
		{
			_BasketService.Delete(id);
			return RedirectToAction("Basket", "Home");
		}

		#endregion

		#region OrderTypes

		public IActionResult OrderTypes()
		{
			var pageModel = new AdminIndexPageModel();
			pageModel.OrderTypes = _OrdersService.GetAllOrderTypes();
			return View(pageModel);
		}

		public IActionResult AddOrderType()
		{
			return View(new OrderType());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult AddOrderType(OrderType orderType)
		{
			_OrdersService.AddOrderType(orderType);
			var pageModel = new AdminIndexPageModel();
			pageModel.OrderTypes = _OrdersService.GetAllOrderTypes();
			return RedirectToAction("OrderTypes", "Home");
		}

		public IActionResult EditOrderType(int id)
		{
			return View(_OrdersService.GetOrderType(id));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult EditOrderType(OrderType orderType)
		{
			_OrdersService.EditOrderType(orderType);
			var pageModel = new AdminIndexPageModel();
			pageModel.OrderTypes = _OrdersService.GetAllOrderTypes();
			return RedirectToAction("OrderTypes", "Home");
		}

		public IActionResult DeleteOrderType(int id)
		{
			_OrdersService.DeleteOrderType(id);
			return RedirectToAction("OrderTypes", "Home");
		}

		#endregion

		#region Orders

		public IActionResult Orders()
		{
			var pageModel = new AdminIndexPageModel();
			pageModel.Orders = _OrdersService.GetAllOrders();
			return View(pageModel);
		}

		public IActionResult AddOrder()
		{
			return View(new Order());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult AddOrder(Order order)
		{
			_OrdersService.AddOrder(order);
			var pageModel = new AdminIndexPageModel();
			pageModel.Orders = _OrdersService.GetAllOrders();
			return RedirectToAction("Orders", "Home");
		}

		public IActionResult EditOrder(int id)
		{
			return View(_OrdersService.GetOrder(id));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult EditOrder(Order order)
		{
			_OrdersService.EditOrder(order);
			var pageModel = new AdminIndexPageModel();
			pageModel.Orders = _OrdersService.GetAllOrders();
			return RedirectToAction("Orders", "Home");
		}

		public IActionResult DeleteOrder(int id)
		{
			_OrdersService.DeleteOrder(id);
			return RedirectToAction("Orders", "Home");
		}

		#endregion

		#region OrderedGoods

		public IActionResult OrderedGoods()
		{
			var pageModel = new AdminIndexPageModel();
			pageModel.OrderedGoods = _OrdersService.GetAllOrderedGoods();
			return View(pageModel);
		}

		public IActionResult AddOrderedGood()
		{
			return View(new OrderedGood());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult AddOrderedGood(OrderedGood orderedGood)
		{
			_OrdersService.AddOrderedGood(orderedGood);
			var pageModel = new AdminIndexPageModel();
			pageModel.OrderedGoods = _OrdersService.GetAllOrderedGoods();
			return RedirectToAction("OrderedGoods", "Home");
		}

		public IActionResult EditOrderedGood(int id)
		{
			return View(_OrdersService.GetOrderedGood(id));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult EditOrderedGood(OrderedGood orderedGood)
		{
			_OrdersService.EditOrderedGood(orderedGood);
			var pageModel = new AdminIndexPageModel();
			pageModel.OrderedGoods = _OrdersService.GetAllOrderedGoods();
			return RedirectToAction("OrderedGoods", "Home");
		}

		public IActionResult DeleteOrderedGood(int id)
		{
			_OrdersService.DeleteOrderedGood(id);
			return RedirectToAction("OrderedGoods", "Home");
		}

		#endregion
	}
}