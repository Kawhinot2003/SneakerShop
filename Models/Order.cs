namespace SneakerShop.Models
{
	public class Order
	{

		public int Id { get; set; }

		public int IdOrderType { get; set; }

		public int IdUser { get; set; }

		public int IdGood { get; set; }

		public string Status { get; set; }

		public Order()
		{

		}

		public Order(int id, int idOrderType, int idUser, int idGood, string status)
		{
			Id = id;
			IdOrderType = idOrderType;
			IdUser = idUser;
			IdGood = idGood;
			Status = status;
		}

	}
}