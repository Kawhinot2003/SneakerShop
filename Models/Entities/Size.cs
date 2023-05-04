namespace SneakerShop.Models.Entities
{
	/// <summary>
	/// Размер товара
	/// </summary>
	public class Size : EntityBase
	{

		public int IdGoodCategory { get; set; }

		public string Name { get; set; }

		public Size()
		{

		}

		public Size(int idGoodCategory, string name)
		{
			IdGoodCategory = idGoodCategory;
			Name = name;
		}

		public override string ToString()
		{
			return $"Id: {Id}, IdGoodCategory: {IdGoodCategory}, Name: {Name}";
		}

	}
}