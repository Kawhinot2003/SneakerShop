namespace SneakerShop.Models.Entities
{
	/// <summary>
	/// Дейсвующая скидка на определённом товаре
	/// </summary>
	public class Discount : EntityBase
	{

		public int IdGood { get; set; }

		public int IdDiscountType { get; set; }

		public Discount()
		{

		}

		public Discount(int idGood, int idDiscountType)
		{
			IdGood = idGood;
			IdDiscountType = idDiscountType;
		}

		public override string ToString()
		{
			return $"Id: {Id}, IdGood: {IdGood}, IdDiscountType: {IdDiscountType}";
		}

	}
}