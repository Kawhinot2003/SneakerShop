using SneakerShop.Models;
using SneakerShop.Models.Entities;

namespace SneakerShop.Services.Interfaces
{
	public interface IGoodsService
	{

		#region Good

		Good GetGood(int id);

		List<Good> GetAllGoods();

		(int EntityId, Returns Result) AddGood(Good entity);

		Returns EditGood(Good entity);

		Returns DeleteGood(int id);

		#endregion

		#region GoodCategory

		GoodCategory GetGoodCategory(int id);

		List<GoodCategory> GetAllGoodCategories();

		(int EntityId, Returns Result) AddGoodCategory(GoodCategory entity);

		Returns EditGoodCategory(GoodCategory entity);

		Returns DeleteGoodCategory(int id);

		#endregion

		List<Good> SearchGoods(int? searchType, string? searchParam);

	}
}