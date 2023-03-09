using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;
using SneakerShop.Models;
using SneakerShop.Models.PageModels;
using SneakerShop.Services;
using System.Diagnostics;

namespace SneakerShop.Controllers
{
    public class HomeController : Controller
    {

		private GoodsService _GoodsService;
		private GoodCategoriesService _GoodCategoriesService;
		private DiscountsService _DiscountsService;
		private SignInManager<IdentityUser> _SignInManager;

		public HomeController(GoodsService goodsService, GoodCategoriesService goodCategoriesService, 
			DiscountsService discountsService, SignInManager<IdentityUser> signInManager)
		{
			_GoodsService = goodsService;
			_GoodCategoriesService = goodCategoriesService;
			_DiscountsService = discountsService;
			_SignInManager = signInManager;
		}

		public IActionResult Index()
        {
			var goods = _GoodsService.GetAll();
			return View(new IndexPageModel(goods));
		}

		public IActionResult Sales()
		{
			var goods = _GoodsService.GetAll().Where(x => x.IdDiscount != null).ToList();
			return View(new IndexPageModel(goods));
		}

		public IActionResult Newproducts()
		{
			var goods = _GoodsService.GetAll();
			return View(new IndexPageModel(goods));
		}

		public IActionResult GetGoodInfo(int goodId)
		{
			return View(new IndexPageModel(_GoodsService.Get(goodId)));
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

		[HttpPost]
		public IActionResult FindGoodsByName(string goodName)
		{
			return View(_GoodsService.GetAll().Where(x => x.Name.Contains(goodName)));
		}

		[HttpPost]
		public IActionResult GetGoodsByCategoryId(int idCategory)
		{
			return View(_GoodsService.GetAll().Where(x => x.IdGoodCategory == idCategory));
		}

		[HttpPost]
		public IActionResult GetGoodCategories()
		{
			return View(_GoodCategoriesService.GetAll());
		}

    }
}