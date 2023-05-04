using Microsoft.EntityFrameworkCore;
using SneakerShop.Domains.Contexts;
using SneakerShop.Models;
using SneakerShop.Models.Entities;
using SneakerShop.Repositories.Interfaces;

namespace SneakerShop.Repositories
{
	public class DbRepository<T> : IDbRepository<T> 
		where T : EntityBase
	{

		private readonly ApplicationContext Context;
		private readonly DbSet<T> Data;

		public DbRepository(ApplicationContext context)
		{
			Context = context;
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

		public (int EntityId, Returns Result) Add(T entity)
		{
			if (entity == null || Data.Contains(entity))
				return (-1, new Returns(false, "Объект пуст или данный экземпляр уже сущетсвует в БД"));

			Data.Add(entity);
			Context.SaveChanges();

			return (entity.Id, new Returns(true));
		}

		public Returns Edit(T entity)
		{
			if (entity == null)
				return new Returns(false, "Объект пуст");

			Context.Entry(entity).State = EntityState.Modified;
			Data.Update(entity);
			Context.SaveChanges();

			return new Returns(true);
		}

		public Returns Delete(int id)
		{
			if (Data.Find(id) == null)
				return new Returns(false, "Объект с заданным Id не найден");

			Context.Entry(Data.Find(id)).State = EntityState.Deleted;
			Data.Remove(Data.Find(id));
			Context.SaveChanges();

			return new Returns(true);
		}

	}
}