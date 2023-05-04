namespace SneakerShop.Models.Entities
{
	/// <summary>
	/// Добавленный в корзину товар
	/// </summary>
	public class BasketElement : EntityBase
	{

		public int IdGood { get; set; }

		public int IdSize { get; set; }

		public string IdUser { get; set; }

		public int? IdDiscount { get; set; }

		public int Count { get; set; }

		public BasketElement()
		{

		}

		public BasketElement(int idGood, int idSize, string idUser, int? idDiscount, int count)
		{
			IdGood = idGood;
			IdSize = idSize;
			IdUser = idUser;
			Count = count;
		}

		public override string ToString()
		{
			return $"Id: {Id}, IdGood: {IdGood}, IdSize: {IdSize}, IdUser: {IdUser}, IdDiscount, {IdDiscount}, Count: {Count}";
		}

	}
}