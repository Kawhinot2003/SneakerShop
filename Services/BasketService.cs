using SneakerShop.Models;
using SneakerShop.Models.Entities;
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

		public (int EntityId, Returns Result) Add(BasketElement entity)
		{
			return Repository.Add(entity);
		}

		public Returns Edit(BasketElement entity)
		{
			return Repository.Edit(entity);
		}

		public Returns Delete(int id)
		{
			return Repository.Delete(id);
		}

	}
}