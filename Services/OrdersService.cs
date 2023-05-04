using SneakerShop.Models;
using SneakerShop.Models.Entities;
using SneakerShop.Repositories.Interfaces;
using SneakerShop.Services.Interfaces;

namespace SneakerShop.Services
{
	public class OrdersService : IOrdersService
	{

		private readonly IDbRepository<Order> OrderRepository;
		private readonly IDbRepository<OrderType> OrderTypeRepository;
		private readonly IDbRepository<OrderedGood> OrderedGoodRepository;

		public OrdersService(IDbRepository<Order> orderRepository, IDbRepository<OrderType> orderTypeRepository, 
			IDbRepository<OrderedGood> orderedGoodRepository)
		{
			OrderRepository = orderRepository;
			OrderTypeRepository = orderTypeRepository;
			OrderedGoodRepository = orderedGoodRepository;
		}

		#region Order

		public Order GetOrder(int id)
		{
			return OrderRepository.Get(id);
		}

		public List<Order> GetAllOrders()
		{
			return OrderRepository.GetAll();
		}

		public (int EntityId, Returns) AddOrder(Order entity)
		{
			return OrderRepository.Add(entity);
		}

		public Returns EditOrder(Order entity)
		{
			return OrderRepository.Edit(entity);
		}

		public Returns DeleteOrder(int id)
		{
			return OrderRepository.Delete(id);
		}

		#endregion

		#region OrderType

		public OrderType GetOrderType(int id)
		{
			return OrderTypeRepository.Get(id);
		}

		public List<OrderType> GetAllOrderTypes()
		{
			return OrderTypeRepository.GetAll();
		}

		public (int EntityId, Returns) AddOrderType(OrderType entity)
		{
			return OrderTypeRepository.Add(entity);
		}

		public Returns EditOrderType(OrderType entity)
		{
			return OrderTypeRepository.Edit(entity);
		}

		public Returns DeleteOrderType(int id)
		{
			return OrderTypeRepository.Delete(id);
		}

		#endregion

		#region OrderedGood

		public OrderedGood GetOrderedGood(int id)
		{
			return OrderedGoodRepository.Get(id);
		}

		public List<OrderedGood> GetAllOrderedGoods()
		{
			return OrderedGoodRepository.GetAll();
		}

		public (int EntityId, Returns) AddOrderedGood(OrderedGood entity)
		{
			return OrderedGoodRepository.Add(entity);
		}

		public Returns EditOrderedGood(OrderedGood entity)
		{
			return OrderedGoodRepository.Edit(entity);
		}

		public Returns DeleteOrderedGood(int id)
		{
			return OrderedGoodRepository.Delete(id);
		}

		#endregion

		/// <summary>
		/// Создать заказ из корзины пользователя
		/// </summary>
		public Returns MakeOrderFromBasket(List<BasketElement> goodsInBasket)
		{
			var userId = goodsInBasket.First().IdUser;

			// ХАРДКОД, заменить тип заказа 1 на поиск типа заказа
			var orderId = AddOrder(new Order(1, userId, "В ожидании")).EntityId;
			foreach(var good in goodsInBasket)
			{
				AddOrderedGood(new OrderedGood(orderId, good.IdGood, good.IdSize, good.IdDiscount, good.Count));
			}

			return new Returns(true);
		}

	}
}