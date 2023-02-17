using SneakerShop.Models;
using SneakerShop.Repositories.Interfaces;
using SneakerShop.Services.Interfaces;

namespace SneakerShop.Services
{
	public class OrdersService : IOrdersService
	{

		private readonly IDbRepository<Order> Repository;

		public OrdersService(IDbRepository<Order> repository)
		{
			Repository = repository;
		}

		public Order Get(int id)
		{
			return Repository.Get(id);
		}

		public List<Order> GetAll()
		{
			return Repository.GetAll();
		}

		public Returns Add(Order entity)
		{
			return Repository.Add(entity);
		}

		public Returns Edit(int id, Order entity)
		{
			return Repository.Edit(id, entity);
		}

		public Returns Delete(int id)
		{
			return Repository.Delete(id);
		}

	}
}