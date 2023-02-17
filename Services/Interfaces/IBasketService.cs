using SneakerShop.Models;

namespace SneakerShop.Services.Interfaces
{
	public interface IBasketService
	{

		BasketElement Get(int id);

		List<BasketElement> GetAll();

		Returns Add(BasketElement entity);

		/// <summary>
		/// Изменить объект
		/// </summary>
		/// <param name="id">Id изменяемого объекта</param>
		/// <param name="entity">Изменённый объект</param>
		/// <returns></returns>
		Returns Edit(int id, BasketElement entity);

		Returns Delete(int id);

	}
}