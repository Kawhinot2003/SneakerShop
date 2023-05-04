using SneakerShop.Models;
using SneakerShop.Models.Entities;
using SneakerShop.Repositories.Interfaces;
using SneakerShop.Services.Interfaces;

namespace SneakerShop.Services
{
	public class GoodsService : IGoodsService
	{

		private readonly IDbRepository<Good> GoodRepository;
		private readonly IDbRepository<GoodCategory> GoodCategoryRepository;

		public GoodsService(IDbRepository<Good> goodRepository, IDbRepository<GoodCategory> goodCategoryRepository)
		{
			GoodRepository = goodRepository;
			GoodCategoryRepository = goodCategoryRepository;
		}

		#region Good

		public Good GetGood(int id)
		{
			return GoodRepository.Get(id);
		}

		public List<Good> GetAllGoods()
		{
			return GoodRepository.GetAll();
		}

		public (int EntityId, Returns Result) AddGood(Good entity)
		{
			return GoodRepository.Add(entity);
		}

		public Returns EditGood(Good entity)
		{
			return GoodRepository.Edit(entity);
		}

		public Returns DeleteGood(int id)
		{
			return GoodRepository.Delete(id);
		}

		#endregion

		#region GoodCategory

		public GoodCategory GetGoodCategory(int id)
		{
			return GoodCategoryRepository.Get(id);
		}

		public List<GoodCategory> GetAllGoodCategories()
		{
			return GoodCategoryRepository.GetAll();
		}

		public (int EntityId, Returns Result) AddGoodCategory(GoodCategory entity)
		{
			return GoodCategoryRepository.Add(entity);
		}

		public Returns EditGoodCategory(GoodCategory entity)
		{
			return GoodCategoryRepository.Edit(entity);
		}

		public Returns DeleteGoodCategory(int id)
		{
			return GoodCategoryRepository.Delete(id);
		}

		#endregion

	}
}