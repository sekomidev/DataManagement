using System.Xml.Serialization;
using System.Diagnostics;

namespace DataManagement
{
	public static class DataManager
	{
		/// <summary>
		/// Saves the given object instance to an XML file.
		/// <para>
		/// Only public fields and properties will be written to the file.
		/// If you don't wish to save certain fields/properties, add the [XmlIgnore] attribute to them.
		/// Object type must have a parameterless constructor.
		/// </para>
		/// </summary>
		/// <typeparam name="T">The type of object to save.</typeparam>
		/// <param name="filePath">The file path to save the object to.</param>
		/// <param name="objectToSave">The object instance to save.</param>
		/// <param name="append">Whether or not to append contents to the file.</param>
		public static void Save<T>(string filePath, T objectToSave, bool append = false)
		{
			TextWriter? writer = null;
			try
			{
				writer = new StreamWriter(@filePath, append);
				new XmlSerializer(typeof(T)).Serialize(writer, objectToSave);
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
		/// Saves the given array of object instances to an XML file.
		/// <para>
		/// Only public fields and properties will be written to the file.
		/// If you don't wish to save certain fields/properties, add the [XmlIgnore] attribute to them.
		/// </para>
		/// <para>
		/// Object type must have a parameterless constructor.
		/// </para>
		/// </summary>
		public static void Save<T>(string filePath, params T[] objectsToSave)
		{
			TextWriter? writer = null;
			try
			{
				writer = new StreamWriter(@filePath, false);
				new XmlSerializer(typeof(T[])).Serialize(writer, objectsToSave);
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
		/// <typeparam name="T">The type of object to load.</typeparam>
		/// <param name="filePath">The file path to load the object instance from.</param>
		/// <returns>Returns a new instance of the object read from the XML file.</returns>
		public static T Load<T>(string filePath)
			where T : new()
		{
			TextReader? reader = null;
			try
			{
				reader = new StreamReader(@filePath);
				return (T)new XmlSerializer(typeof(T)).Deserialize(reader);
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
		/// <summary>
		/// Loads multiple object instances from an XML file.
		/// <para>
		/// Object type must have a parameterless constructor.
		/// </para>
		/// </summary>
		/// <typeparam name="T">The type of object to load.</typeparam>
		/// <param name="filePath">The file path to load the object instance from.</param>
		/// <returns>Returns a new array of the objects read from the XML file.</returns>
		public static T[] LoadMultiple<T>(string filePath)
			where T : new()
		{
			TextReader? reader = null;
			try
			{
				reader = new StreamReader(@filePath);
				return (T[])new XmlSerializer(typeof(T[])).Deserialize(reader);
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
