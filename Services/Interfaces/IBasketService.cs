using SneakerShop.Models;
using SneakerShop.Models.Entities;

namespace SneakerShop.Services.Interfaces
{
	public interface IBasketService
	{

		BasketElement Get(int id);

		List<BasketElement> GetAll();

		(int EntityId, Returns Result) Add(BasketElement entity);

		Returns Edit(BasketElement entity);

		Returns Delete(int id);

	}
}