using DataManagement;
namespace UserDataSavingExample
{
	internal class Program
	{
		static void Main(string[] args)
		{
			User user0 = new(name: "John Doe", password: "1234");
			// saves the user0 data to "user.xml" file
			DataManager.Save(@".\user.xml", user0);

			User user1 = DataManager.Load<User>(@".\user.xml");
			// will output "John Doe"
			Console.WriteLine(user1.Name);
		}
	}
}