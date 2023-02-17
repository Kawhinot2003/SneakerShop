namespace SneakerShop.Models.PageModels
{
	public class IndexPageModel
	{

		public List<Good> Goods { get; set; }

		public IndexPageModel(List<Good> goods)
		{
			Goods = goods;
		}

	}
}