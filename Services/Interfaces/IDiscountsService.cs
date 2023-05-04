using SneakerShop.Models;
using SneakerShop.Models.Entities;

namespace SneakerShop.Services.Interfaces
{
	public interface IDiscountsService
	{

		Discount Get(int id);

		List<Discount> GetAll();

		(int EntityId, Returns Result) Add(Discount entity);

		Returns Edit(Discount entity);

		Returns Delete(int id);

	}
}