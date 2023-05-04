namespace SneakerShop.Models.Entities
{
	/// <summary>
	/// Заказ
	/// </summary>
	public class Order : EntityBase
	{

		public int IdOrderType { get; set; }

		public string IdUser { get; set; }

		public string Status { get; set; }

		public Order()
		{

		}

		public Order(int idOrderType, string idUser, string status)
		{
			IdOrderType = idOrderType;
			IdUser = idUser;
			Status = status;
		}

		public override string ToString()
		{
			return $"Id: {Id}, IdOrderType: {IdOrderType}, IdUser: {IdUser}, Status: {Status}";
		}

	}
}