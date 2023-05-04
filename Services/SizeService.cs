using SneakerShop.Models;
using SneakerShop.Models.Entities;
using SneakerShop.Repositories.Interfaces;
using SneakerShop.Services.Interfaces;

namespace SneakerShop.Services
{
	public class SizeService : ISizeService
	{

		private readonly IDbRepository<Size> Repository;

		public SizeService(IDbRepository<Size> repository)
		{
			Repository = repository;
		}

		public Size Get(int id)
		{
			return Repository.Get(id);
		}

		public List<Size> GetAll()
		{
			return Repository.GetAll();
		}

		public (int EntityId, Returns Result) Add(Size entity)
		{
			return Repository.Add(entity);
		}

		public Returns Edit(Size entity)
		{
			return Repository.Edit(entity);
		}

		public Returns Delete(int id)
		{
			return Repository.Delete(id);
		}

	}
}