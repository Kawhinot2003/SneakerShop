using SneakerShop.Enums;
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
		private readonly IDbRepository<Manufacturer> ManufacturerRepository;

		public GoodsService(IDbRepository<Good> goodRepository, IDbRepository<GoodCategory> goodCategoryRepository, 
			IDbRepository<Manufacturer> manufacturerRepository)
		{
			GoodRepository = goodRepository;
			GoodCategoryRepository = goodCategoryRepository;
			ManufacturerRepository = manufacturerRepository;
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

		#region Manufacturer

		public Manufacturer GetManufacturer(int id)
		{
			return ManufacturerRepository.Get(id);
		}

		public List<Manufacturer> GetAllManufacturers()
		{
			return ManufacturerRepository.GetAll();
		}

		public (int EntityId, Returns Result) AddManufacturer(Manufacturer entity)
		{
			return ManufacturerRepository.Add(entity);
		}

		public Returns EditManufacturer(Manufacturer entity)
		{
			return ManufacturerRepository.Edit(entity);
		}

		public Returns DeleteManufacturer(int id)
		{
			return ManufacturerRepository.Delete(id);
		}

		#endregion

		public List<Good> SearchGoods(int? searchType, string? searchParam)
		{
			searchType = !searchType.HasValue ? searchType = 0 : searchType;
			var type = (SearchTypes)searchType;
			var result = new List<Good>();

			switch (type)
			{
				case SearchTypes.GoodName:
					result = GetAllGoods().Where(x => x.Name.Contains(searchParam)).ToList();
					break;
				case SearchTypes.IdManufacturer: 
					result = GetAllGoods().Where(x => x.IdManufacturer == Convert.ToInt32(searchParam)).ToList();
					break;
				case SearchTypes.IdGoodCategory:
					result = GetAllGoods().Where(x => x.IdGoodCategory == Convert.ToInt32(searchParam)).ToList();
					break;
				case SearchTypes.AccessoriesOnly:
					var accessories = new[] { 7, 10, 11, 12 };
					result = GetAllGoods().Where(x => accessories.Contains(x.IdGoodCategory)).ToList();
					break;
				default: result = GetAllGoods();
					break;
			}

			return result;
		}

	}
}