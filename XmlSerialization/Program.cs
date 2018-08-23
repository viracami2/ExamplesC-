#region Using Directives

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using XmlSerialization.Utility;

#endregion

namespace XmlSerialization
{
	class Program
	{
		private const string xmlFile = "Data.xml";
		string dat = "";

		#region Methods static

		private static object GetCacheFirstAsyncStepExecuted()
		{
			var key = ChachingCachan.GetKeyName(cacheKeyName: CacheKeyNameEnum.hayCache, cacheKeyParams: new object[] { "?¿" });
			var firstAsyncStepExecuted = ChachingCachan.Get(key);

			//bool existsCache = firstAsyncStepExecuted != null && (int)firstAsyncStepExecuted == 1;
			//if (existsCache) { ChachingCachan.Remove(key); }

			return firstAsyncStepExecuted;
		}
		private static void SaveCacheFirstAsyncStepExecuted(string dataaGuardar)
		{
			var key = ChachingCachan.GetKeyName(cacheKeyName: CacheKeyNameEnum.hayCache, cacheKeyParams: new object[] { "?¿" });
			ChachingCachan.Add(key: key, result: dataaGuardar, expirationInMinutes: 1);
		}

		#endregion

		static void Main(string[] args)
		{

			SaveCacheFirstAsyncStepExecuted("Esto se guardara en cache");
			var datoCacheado = GetCacheFirstAsyncStepExecuted().ToString();

			///////////////////
			Ip ipMain = new Ip();
			var dato = nameof(ipMain.GetClientIP);// para obtener el nombre del metodo
			ipMain.GetClientIP();



			object data = 5;
			Empleado persona = new Empleado();
			persona.plus(0.0);
			Console.WriteLine(persona.Valor);





			//XmlSerializer serializer = new XmlSerializer(typeof(ProductAttribute));
			XmlSerializer serializer = new XmlSerializer(typeof(List<CATALOG>), new XmlRootAttribute("CATALOG"));

			//toca referenciar  System.Xml.Linq
			var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $@"App_Data/{xmlFile}");
			if (!File.Exists(path)) { throw new SystemException($"File not found: '{path}'"); }

			XDocument libroRaiz = XDocument.Load(path, LoadOptions.None);

			//Busquedas en XML usando LINQ 
			var artista = (from dx in libroRaiz.Elements("CATALOG").Elements()
						   where dx.Element("TITLE").Value.Equals("Eros")
						   select dx).ToList();

			StringReader stringReader = new StringReader(libroRaiz.ToString());

			List<CATALOG> productList = (List<CATALOG>)serializer.Deserialize(stringReader);


			JObject xdato = libroRaiz.ToString().XmlAJson(true);

			//Manera de obtener datos	  			
			//  var nombreDos = xdato["Persons"]["Person"][1]["First"].ToString();
			Console.WriteLine($"Titulos de albunes");
			foreach (var item in xdato["CATALOG"]["CD"])
			{
				Console.WriteLine($"Titulo : {item["TITLE"]}");
			}

			Console.WriteLine("----------------------------------");
			Console.WriteLine("Press enter to exit.");
			Console.ReadLine();
		}

		public static string GetFormattedNumberStandard(object Text)
		{
			decimal DecimalNumber = 0;
			//Válidamos si el texto de entrada es vacio, para ponerlo 0 ó vacio segun el caso
			if (Text == null || Text.ToString() == string.Empty) { Text = 0; return "0.00"; }
			//Válidamos si el texto de entrada es un decimal, para poder darle formato.
			if (Text is decimal)
			{
				DecimalNumber = (decimal)Text;
			}
			else
			{
				string ConvertedText = Text.ToString();
				//ConvertedText = &quot;106755.25&quot;;
				try
				{
					DecimalNumber = decimal.Parse(ConvertedText);
				}
				catch
				{
					//throw new ArgumentException(&quot; Valor invalido: &quot; +ConvertedText);
				}
			}
			//return Text.ToString();
			string ConvertedDecimalNumber = DecimalNumber.ToString();
			return ConvertedDecimalNumber;
		}
	}




	public class CATALOG
	{
		[XmlElement(ElementName = "TITLE")]
		public string TITLE { get; set; }
		[XmlElement(ElementName = "ARTIST")]
		public string ARTIST { get; set; }
		[XmlElement(ElementName = "COUNTRY")]
		public string COUNTRY { get; set; }
		[XmlElement(ElementName = "COMPANY")]
		public string COMPANY { get; set; }
		[XmlElement(ElementName = "PRICE")]
		public string PRICE { get; set; }
		[XmlElement(ElementName = "YEAR")]
		public string YEAR { get; set; }

		CATALOG() { }
		public CATALOG(XElement element)
		{
			TITLE = element.Element("TITLE").Value;
			ARTIST = (string)element.Element("ARTIST").Value;
			COUNTRY = (string)element.Element("COUNTRY ").Value;
			COMPANY = (string)element.Element("COMPANY").Value;
			PRICE = (string)element.Element("PRICE").Value;
			YEAR = (string)element.Element("YEAR").Value;
		}

	}

}