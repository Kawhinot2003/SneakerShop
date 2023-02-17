using SneakerShop.Models;

namespace SneakerShop.Services.Interfaces
{
	public interface IDiscountsService
	{

		Discount Get(int id);

		List<Discount> GetAll();

		Returns Add(Discount entity);

		/// <summary>
		/// Изменить объект
		/// </summary>
		/// <param name="id">Id изменяемого объекта</param>
		/// <param name="entity">Изменённый объект</param>
		/// <returns></returns>
		Returns Edit(int id, Discount entity);

		Returns Delete(int id);

	}
}