namespace SneakerShop.Models
{
	public class OrderType
	{

		public int Id { get; set; }

		public string Name { get; set; }

		public OrderType()
		{

		}

		public OrderType(int id, string name)
		{
			Id = id;
			Name = name;
		}

	}
}