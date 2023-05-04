using SneakerShop.Models;
using SneakerShop.Models.Entities;

namespace SneakerShop.Services.Interfaces
{
	public interface ISizeService
	{

		Size Get(int id);

		List<Size> GetAll();

		(int EntityId, Returns Result) Add(Size entity);

		Returns Edit(Size entity);

		Returns Delete(int id);

	}
}