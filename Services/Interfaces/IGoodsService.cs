using SneakerShop.Models;

namespace SneakerShop.Services.Interfaces
{
	public interface IGoodsService
	{

		Good Get(int id);

		List<Good> GetAll();

		Returns Add(Good entity);

		/// <summary>
		/// Изменить объект
		/// </summary>
		/// <param name="id">Id изменяемого объекта</param>
		/// <param name="entity">Изменённый объект</param>
		/// <returns></returns>
		Returns Edit(int id, Good entity);

		Returns Delete(int id);

	}
}
