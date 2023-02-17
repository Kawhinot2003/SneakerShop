using Microsoft.EntityFrameworkCore;
using SneakerShop.Domains.Contexts;
using SneakerShop.Models;
using SneakerShop.Repositories.Interfaces;

namespace SneakerShop.Repositories
{
	public class DbRepository<T> : IDbRepository<T> 
		where T : class
	{

		private readonly DbSet<T> Data;

		public DbRepository(ApplicationContext context)
		{
			Data = context.Set<T>();
		}

		public T Get(int id)
		{
			return Data.Find(id);
		}

		public List<T> GetAll()
		{
			return Data.ToList();
		}

		public Returns Add(T entity)
		{
			if (entity == null || Data.Contains(entity))
				return new Returns(false, "Объект пуст или данный экземпляр уже сущетсвует в БД");

			Data.Add(entity);

			return new Returns(true);
		}

		public Returns Edit(int id, T entity)
		{
			if (entity == null)
				return new Returns(false, "Объект пуст");
			if (Data.Find(id) == null)
				return new Returns(false, "Объект с заданным Id не найден");
			if (Data.Contains(entity))
				return new Returns(false, "Данный экземпляр уже сущетсвует в БД");

			// мб есть более лучший вариант реализации операции изменения
			Data.Remove(Data.Find(id));
			Data.Add(entity);
			Data.Update(entity);

			return new Returns(true);
		}

		public Returns Delete(int id)
		{
			if (Data.Find(id) == null)
				return new Returns(false, "Объект с заданным Id не найден");

			Data.Remove(Data.Find(id));

			return new Returns(true);
		}

	}
}