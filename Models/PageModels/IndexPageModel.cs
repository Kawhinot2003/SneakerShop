using Microsoft.AspNetCore.Mvc.RazorPages;
using SneakerShop.Models.Entities;

namespace SneakerShop.Models.PageModels
{
	public class IndexPageModel : PageModel
	{

		public List<Good> Goods { get; private set; }

		public IndexPageModel(List<Good> goods)
		{
			Goods = goods;
		}

	}
}