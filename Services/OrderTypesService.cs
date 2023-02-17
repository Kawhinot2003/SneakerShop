using SneakerShop.Models;
using SneakerShop.Repositories.Interfaces;
using SneakerShop.Services.Interfaces;

namespace SneakerShop.Services
{
	public class OrderTypesService : IOrderTypesService
	{

		private readonly IDbRepository<OrderType> Repository;

		public OrderTypesService(IDbRepository<OrderType> repository)
		{
			Repository = repository;
		}

		public OrderType Get(int id)
		{
			return Repository.Get(id);
		}

		public List<OrderType> GetAll()
		{
			return Repository.GetAll();
		}

		public Returns Add(OrderType entity)
		{
			return Repository.Add(entity);
		}

		public Returns Edit(int id, OrderType entity)
		{
			return Repository.Edit(id, entity);
		}

		public Returns Delete(int id)
		{
			return Repository.Delete(id);
		}

	}
}