using System.Xml.Serialization;

namespace UserDataSavingExample
{
	/// <summary>
	/// This is an example class for save/load method demonstration purposes.
	/// </summary>
	public class User
	{
		// this field will not be saved
		private const int someFieldThatWillNotBeSaved = 10;

		// this property will be saved
		public string Name { get; set; }
		// this property will also be saved
		public string Password { get; set; }
		// this property will not be saved
		[XmlIgnore]
		public string SessionId { get; private set; }
		
		// a parameterless constructor is needed to save/load objects
		public User()
		{
			Name = String.Empty;
			Password = String.Empty;
			SessionId = Guid.NewGuid().ToString();
		}
		
		public User(string name, string password)
		{
			Name = name;
			Password = password;
			SessionId = Guid.NewGuid().ToString();
		}
	}
}
