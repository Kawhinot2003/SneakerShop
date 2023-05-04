using Microsoft.AspNetCore.Mvc.RazorPages;
using SneakerShop.Models.Entities;

namespace SneakerShop.Models.PageModels
{
	public class ChoosedGoodPageModel : PageModel
	{

		public Good ChoosedGood { get; private set; }

		public List<Size> Sizes { get; private set; }

		public ChoosedGoodPageModel(Good choosedGood, List<Size> sizes)
		{
			ChoosedGood = choosedGood;
			Sizes = sizes;
		}

	}
}