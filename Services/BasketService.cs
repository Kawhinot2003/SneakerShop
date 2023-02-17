using SneakerShop.Models;
using SneakerShop.Repositories.Interfaces;
using SneakerShop.Services.Interfaces;

namespace SneakerShop.Services
{
	public class BasketService : IBasketService
	{

		private readonly IDbRepository<BasketElement> Repository;

		public BasketService(IDbRepository<BasketElement> repository)
		{
			Repository = repository;
		}

		public BasketElement Get(int id)
		{
			return Repository.Get(id);
		}

		public List<BasketElement> GetAll()
		{
			return Repository.GetAll();
		}

		public Returns Add(BasketElement entity)
		{
			return Repository.Add(entity);
		}

		public Returns Edit(int id, BasketElement entity)
		{
			return Repository.Edit(id, entity);
		}

		public Returns Delete(int id)
		{
			return Repository.Delete(id);
		}

	}
}