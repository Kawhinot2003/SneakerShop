namespace SneakerShop.Models.PageModels
{
	public class IndexPageModel
	{

		public List<Good> Goods { get; private set; }

		public Good CurrentGood { get; private set; }

		public IndexPageModel(List<Good> goods)
		{
			Goods = goods;
		}

		public IndexPageModel(Good choosedGood)
		{
			CurrentGood = choosedGood;
		}

	}
}