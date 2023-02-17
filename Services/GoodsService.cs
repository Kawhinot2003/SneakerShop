using SneakerShop.Models;
using SneakerShop.Repositories.Interfaces;
using SneakerShop.Services.Interfaces;

namespace SneakerShop.Services
{
	public class GoodsService : IGoodsService
	{

		private readonly IDbRepository<Good> Repository;

		public GoodsService(IDbRepository<Good> repository)
		{
			Repository = repository;
		}

		public Good Get(int id)
		{
			return Repository.Get(id);
		}

		public List<Good> GetAll()
		{
			return Repository.GetAll();
		}

		public Returns Add(Good entity)
		{
			return Repository.Add(entity);
		}

		public Returns Edit(int id, Good entity)
		{
			return Repository.Edit(id, entity);
		}

		public Returns Delete(int id)
		{
			return Repository.Delete(id);
		}

	}
}