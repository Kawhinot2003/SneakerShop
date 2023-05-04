namespace SneakerShop.Models.Entities
{
	/// <summary>
	/// Заказанный товар вместе с размером и скидкой
	/// </summary>
	public class OrderedGood : EntityBase
	{

		public int IdOrder { get; set; }

		public int IdGood { get; set; }

		public int IdSize { get; set; }

		public int? IdDiscount { get; set; }

		public int Count { get; set; }

		public OrderedGood()
		{

		}

		public OrderedGood(int idOrder, int idGood, int idSize, int? idDiscount, int count)
		{
			IdOrder = idOrder;
			IdGood = idGood;
			IdSize = idSize;
			Count = count;
			IdDiscount = idDiscount;
		}

		public override string ToString()
		{
			return $"Id: {Id}, IdOrder: {IdOrder}, IdGood: {IdGood}, IdSize: {IdSize}, IdDiscount: {IdDiscount}, Count: {Count}";
		}

	}
}