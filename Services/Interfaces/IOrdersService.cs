using SneakerShop.Models;

namespace SneakerShop.Services.Interfaces
{
	public interface IOrdersService
	{

		Order Get(int id);

		List<Order> GetAll();

		Returns Add(Order entity);

		/// <summary>
		/// Изменить объект
		/// </summary>
		/// <param name="id">Id изменяемого объекта</param>
		/// <param name="entity">Изменённый объект</param>
		/// <returns></returns>
		Returns Edit(int id, Order entity);

		Returns Delete(int id);

	}
}