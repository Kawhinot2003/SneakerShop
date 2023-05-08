namespace SneakerShop.Models.Entities
{
	/// <summary>
	/// Товар
	/// </summary>
	public class Good : EntityBase
	{

		public int IdGoodCategory { get; set; }

		public int IdManufacturer { get; set; }

		public string Name { get; set; }

		public decimal Price { get; set; }

		public string Description { get; set; }

		public string ImageURL { get; set; }

		public Good()
		{

		}

		public Good(int idGoodCategory, int idManufacturer, string name, decimal price, string description, string imageURL)
		{
			IdGoodCategory = idGoodCategory;
			IdManufacturer = idManufacturer;
			Name = name;
			Price = price;
			Description = description;
			ImageURL = imageURL;
		}

		public override string ToString()
		{
			return $"Id: {Id}, IdGoodCategory: {IdGoodCategory}, Name: {Name}, Price: {Price}, Description: {Description}, ImageURL: {ImageURL}";
		}

	}
}