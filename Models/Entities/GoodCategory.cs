namespace SneakerShop.Models.Entities
{
	/// <summary>
	/// Тип товара
	/// </summary>
	public class GoodCategory : EntityBase
	{

		public string Name { get; set; }

		public string Description { get; set; }

		public GoodCategory()
		{

		}

		public GoodCategory(string name, string description)
		{
			Name = name;
			Description = description;
		}

		public override string ToString()
		{
			return $"Id: {Id}, Name: {Name}, Description: {Description}";
		}

	}
}