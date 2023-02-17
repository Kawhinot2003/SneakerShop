using SneakerShop.Models;
using SneakerShop.Repositories.Interfaces;
using SneakerShop.Services.Interfaces;

namespace SneakerShop.Services
{
	public class GoodCategoriesService : IGoodCategoriesService
	{

		private readonly IDbRepository<GoodCategory> Repository;

		public GoodCategoriesService(IDbRepository<GoodCategory> repository)
		{
			Repository = repository;
		}

		public GoodCategory Get(int id)
		{
			return Repository.Get(id);
		}

		public List<GoodCategory> GetAll()
		{
			return Repository.GetAll();
		}

		public Returns Add(GoodCategory entity)
		{
			return Repository.Add(entity);
		}

		public Returns Edit(int id, GoodCategory entity)
		{
			return Repository.Edit(id, entity);
		}

		public Returns Delete(int id)
		{
			return Repository.Delete(id);
		}

	}
}