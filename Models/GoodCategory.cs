namespace SneakerShop.Models
{
	public class GoodCategory
	{

		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public GoodCategory()
		{

		}

		public GoodCategory(int id, string name, string description)
		{
			Id = id;
			Name = name;
			Description = description;
		}

	}
}