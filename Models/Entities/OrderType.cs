namespace SneakerShop.Models.Entities
{
	/// <summary>
	/// Тип заказа
	/// </summary>
	public class OrderType : EntityBase
	{

		public string Name { get; set; }

		public OrderType()
		{

		}

		public OrderType(string name)
		{
			Name = name;
		}

		public override string ToString()
		{
			return $"Id: {Id}, Name: {Name}";
		}

	}
}