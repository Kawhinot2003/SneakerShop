namespace SneakerShop.Models
{
	public class Good
	{

		public int Id { get; set; }

		public int IdGoodCategory { get; set; }

		public string Name { get; set; }

		public decimal Price { get; set; }

		public int? IdDiscount { get; set; }

		public int Count { get; set; }

		public string Size { get; set; }

		public string Description { get; set; }

		public string ImageURL { get; set; }

		public Good() 
		{
			
		}

		public Good(int id, int idGoodCategory, string name, decimal price, int? idDiscount, int count, string size, string description, string imageURL)
		{
			Id = id;
			IdGoodCategory = idGoodCategory;
			Name = name;
			Price = price;
			IdDiscount = idDiscount;
			Count = count;
			Size = size;
			Description = description;
			ImageURL = imageURL;
		}

	}
}