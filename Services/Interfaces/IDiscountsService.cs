using SneakerShop.Models;
using SneakerShop.Models.Entities;

namespace SneakerShop.Services.Interfaces
{
	public interface IDiscountsService
	{

		Discount GetDiscount(int id);

		List<Discount> GetAllDiscounts();

		(int EntityId, Returns Result) AddDiscount(Discount entity);

		Returns EditDiscount(Discount entity);

		Returns DeleteDiscount(int id);

		DiscountType GetDiscountType(int id);

		List<DiscountType> GetAllDiscountTypes();

		(int EntityId, Returns Result) AddDiscountType(DiscountType entity);

		Returns EditDiscountType(DiscountType entity);

		Returns DeleteDiscountType(int id);

	}
}