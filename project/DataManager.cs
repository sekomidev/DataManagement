using System.Xml.Serialization;
using System.Diagnostics;
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
			catch(InvalidOperationException e)
			{
				Trace.TraceError("Only instances of public classes can be saved!");
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
		/// <summary>
		/// Loads an object instance from an XML file.
		/// <para>
		/// Object type must have a parameterless constructor.
		/// </para>
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="filePath"></param>
		/// <returns></returns>
		public static T Load<T>(string filePath)
			where T : new()
		{
			TextReader? reader = null;
			try
			{
				reader = new StreamReader(filePath);
				return (T)new XmlSerializer(typeof(T)).Deserialize(reader);
			}
			catch(FileNotFoundException)
			{
				Trace.TraceWarning($"File \"{filePath}\" not found; returning an empty object");
				return new T();
			}
			finally
			{
				if (reader is not null)
				{
					reader.Close();
					reader.Dispose();
				}
			}
		}
	}
}