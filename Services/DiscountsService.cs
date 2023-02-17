using SneakerShop.Models;
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

		public Returns Add(Discount entity)
		{
			return Repository.Add(entity);
		}

		public Returns Edit(int id, Discount entity)
		{
			return Repository.Edit(id, entity);
		}

		public Returns Delete(int id)
		{
			return Repository.Delete(id);
		}

	}
}