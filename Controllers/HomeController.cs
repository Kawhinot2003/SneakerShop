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
			//goods.Add(new Good(1, 1, "Кроссовки абибас", 100, null, 2, "34", "Внатуре чоткие кроссы ежжы", @"https://www.meme-arsenal.com/memes/a0ec1870e03618b5abae03df59eb8e02.jpg"));
			//goods.Add(new Good(2, 1, "Кроссовки найк", 500, 1, 0, "40", "Не чоткие кросы", @"https://i.ytimg.com/vi/DAJjonCvR6Y/maxresdefault.jpg"));
			//
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
		public IActionResult GetGoodsWithDiscount()
		{
			return View(_GoodsService.GetAll().Where(x => x.IdDiscount != null));
		}

		[HttpPost]
		public IActionResult GetGoodCategories()
		{
			return View(_GoodCategoriesService.GetAll());
		}

    }
}