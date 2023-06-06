using Microsoft.AspNetCore.Mvc;
using SneakerShop.Models;
using SneakerShop.Models.PageModels;
using SneakerShop.Services.Interfaces;
using System.Diagnostics;

namespace SneakerShop.Controllers
{
    public class HomeController : Controller
    {

		private IGoodsService _GoodsService;
		private IDiscountsService _DiscountsService;

		public HomeController(IGoodsService goodsService, IDiscountsService discountsService)
		{
			_GoodsService = goodsService;
			_DiscountsService = discountsService;
		}

		public IActionResult Index(int? searchType, string? searchParam)
		{
			var goods = _GoodsService.SearchGoods(searchType, searchParam);
			goods = goods.OrderBy(x => x.Id).ToList();
			return View(new IndexPageModel(goods));
		}

		public IActionResult Sales()
		{
			var discounts = _DiscountsService.GetAllDiscounts().Select(x => x.IdGood);
			var goods = _GoodsService.GetAllGoods().Where(x => discounts.Contains(x.Id)).ToList();
			return View(new IndexPageModel(goods));
		}

		public IActionResult Newproducts()
		{
			var goods = _GoodsService.GetAllGoods();
			return View(new IndexPageModel(goods));
		}

		public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}