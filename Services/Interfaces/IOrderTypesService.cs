using SneakerShop.Models;

namespace SneakerShop.Services.Interfaces
{
	public interface IOrderTypesService
	{

		OrderType Get(int id);

		List<OrderType> GetAll();

		Returns Add(OrderType entity);

		/// <summary>
		/// Изменить объект
		/// </summary>
		/// <param name="id">Id изменяемого объекта</param>
		/// <param name="entity">Изменённый объект</param>
		/// <returns></returns>
		Returns Edit(int id, OrderType entity);

		Returns Delete(int id);

	}
}