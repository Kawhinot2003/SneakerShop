using SneakerShop.Models;

namespace SneakerShop.Repositories.Interfaces
{
	public interface IDbRepository<T> where T : class
	{

		T Get(int id);

		List<T> GetAll();

		(int EntityId, Returns Result) Add(T entity);

		/// <summary>
		/// Изменить объект
		/// </summary>
		/// <param name="id">Id изменяемого объекта</param>
		/// <param name="entity">Изменённый объект</param>
		/// <returns></returns>
		Returns Edit(T entity);

		Returns Delete(int id);

	}
}