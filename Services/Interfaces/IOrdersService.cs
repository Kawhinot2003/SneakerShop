using SneakerShop.Models;
using SneakerShop.Models.Entities;

namespace SneakerShop.Services.Interfaces
{
	public interface IOrdersService
	{

		#region Order

		Order GetOrder(int id);

		List<Order> GetAllOrders();

		(int EntityId, Returns) AddOrder(Order entity);

		Returns EditOrder(Order entity);

		Returns DeleteOrder(int id);

		#endregion

		#region OrderType

		OrderType GetOrderType(int id);

		List<OrderType> GetAllOrderTypes();

		(int EntityId, Returns) AddOrderType(OrderType entity);

		Returns EditOrderType(OrderType entity);

		Returns DeleteOrderType(int id);

		#endregion

		#region OrderedGood

		OrderedGood GetOrderedGood(int id);

		List<OrderedGood> GetAllOrderedGoods();

		(int EntityId, Returns) AddOrderedGood(OrderedGood entity);

		Returns EditOrderedGood(OrderedGood entity);

		Returns DeleteOrderedGood(int id);

		#endregion

		Returns MakeOrderFromBasket(List<BasketElement> goods);

	}
}