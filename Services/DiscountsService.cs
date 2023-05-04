using SneakerShop.Models;
using SneakerShop.Models.Entities;
using SneakerShop.Repositories.Interfaces;
using SneakerShop.Services.Interfaces;

namespace SneakerShop.Services
{
	public class DiscountsService : IDiscountsService
	{

		private readonly IDbRepository<Discount> Repository;

		public DiscountsService(IDbRepository<Discount> repository)
		{
			Repository = repository;
		}

		public Discount Get(int id)
		{
			return Repository.Get(id);
		}

		public List<Discount> GetAll()
		{
			return Repository.GetAll();
		}

		public (int EntityId, Returns Result) Add(Discount entity)
		{
			return Repository.Add(entity);
		}

		public Returns Edit(Discount entity)
		{
			return Repository.Edit(entity);
		}

		public Returns Delete(int id)
		{
			return Repository.Delete(id);
		}

	}
}