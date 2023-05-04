using Microsoft.AspNetCore.Mvc.RazorPages;
using SneakerShop.Models.Entities;

namespace SneakerShop.Models.PageModels
{
	public class BasketPageModel : PageModel
	{

		public List<(Good good, string size, int count)> BasketElements { get; private set; }

		public BasketPageModel(List<(Good, string, int)> basketElements)
		{
			BasketElements = basketElements;
		}

	}
}