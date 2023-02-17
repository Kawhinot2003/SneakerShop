using SneakerShop.Models;

namespace SneakerShop.Services.Interfaces
{
	public interface IGoodCategoriesService
	{

		GoodCategory Get(int id);

		List<GoodCategory> GetAll();

		Returns Add(GoodCategory entity);

		/// <summary>
		/// Изменить объект
		/// </summary>
		/// <param name="id">Id изменяемого объекта</param>
		/// <param name="entity">Изменённый объект</param>
		/// <returns></returns>
		Returns Edit(int id, GoodCategory entity);

		Returns Delete(int id);
	}
}