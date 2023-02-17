namespace SneakerShop.Models
{
	public class Discount
	{

		public int Id { get; set; }

		public int Percent { get; set; }

		public string Description { get; set; }

		public Discount()
		{

		}

		public Discount(int id, int percent, string description)
		{
			Id = id;
			Percent = percent;
			Description = description;
		}

	}
}