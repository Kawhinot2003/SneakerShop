using SneakerShop.Models;
using SneakerShop.Models.Entities;
using SneakerShop.Repositories.Interfaces;
using SneakerShop.Services.Interfaces;

namespace SneakerShop.Services
{
	public class DiscountsService : IDiscountsService
	{

		private readonly IDbRepository<Discount> DiscountRepository;
		private readonly IDbRepository<DiscountType> DiscountTypeRepository;

		public DiscountsService(IDbRepository<DiscountType> discountTypeRepository, IDbRepository<Discount> discountRepository)
		{
			DiscountTypeRepository = discountTypeRepository;
			DiscountRepository = discountRepository;
		}

		public Discount GetDiscount(int id)
		{
			return DiscountRepository.Get(id);
		}

		public List<Discount> GetAllDiscounts()
		{
			return DiscountRepository.GetAll();
		}

		public (int EntityId, Returns Result) AddDiscount(Discount entity)
		{
			return DiscountRepository.Add(entity);
		}

		public Returns EditDiscount(Discount entity)
		{
			return DiscountRepository.Edit(entity);
		}

		public Returns DeleteDiscount(int id)
		{
			return DiscountRepository.Delete(id);
		}

		public DiscountType GetDiscountType(int id)
		{
			return DiscountTypeRepository.Get(id);
		}

		public List<DiscountType> GetAllDiscountTypes()
		{
			return DiscountTypeRepository.GetAll();
		}

		public (int EntityId, Returns Result) AddDiscountType(DiscountType entity)
		{
			return DiscountTypeRepository.Add(entity);
		}

		public Returns EditDiscountType(DiscountType entity)
		{
			return DiscountTypeRepository.Edit(entity);
		}

		public Returns DeleteDiscountType(int id)
		{
			return DiscountTypeRepository.Delete(id);
		}

	}
}