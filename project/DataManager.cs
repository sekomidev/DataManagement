using System.Xml.Serialization;
namespace DataManagement
{
	public static class DataManager
	{
		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="filePath"></param>
		/// <param name="objectToSave"></param>
		/// <param name="append"></param>
		public static void Save<T>(string filePath, T objectToSave, bool append = false)
		{
			TextWriter? writer = null;
			try
			{
				writer = new StreamWriter(filePath, append);
				new XmlSerializer(typeof(T)).Serialize(writer, objectToSave);
			}
			catch(Exception e)
			{
				// TODO: add logic for dealing with exceptions
				throw e;
			}
			finally
			{
				if (writer is not null)
				{
					writer.Close();
					writer.Dispose();
				}
			}
		}
	}
}