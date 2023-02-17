namespace SneakerShop.Models
{
	/// <summary>
	/// Содержит информацию о результате выполненного действия
	/// </summary>
	public struct Returns
	{

		/// <summary>
		/// Успешно ли выполнена операция
		/// </summary>
		public bool IsSucessed { get; private set; }

		/// <summary>
		/// Текст ошибки, если она произошла
		/// </summary>
		public string? ErrorText { get; private set; }
		
		public Returns(bool isSucessed):this()
		{
			IsSucessed = isSucessed;
		}

		public Returns(bool isSucessed, string? errorText)
		{
			IsSucessed = isSucessed;
			ErrorText = errorText;
		}

	}
}