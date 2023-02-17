namespace SneakerShop.Models
{
	public class BasketElement
	{

		public int Id { get; set; }

		public int IdGood { get; set; }

		public int IdUser { get; set; }

		public BasketElement()
		{

		}

		public BasketElement(int id, int idGood, int idUser)
		{
			Id = id;
			IdGood = idGood;
			IdUser = idUser;
		}

	}
}