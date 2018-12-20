#region Using Directives

using Newtonsoft.Json.Linq;
using OpenHtmlToPdf;
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

        #region Methods static

        static int? dataStatic;

        static object GetCacheFirstAsyncStepExecuted()
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

        public class NumerosIrregulares {
            public const double PI = 3.14;

            private int numeroMenorACien;

            public int NumeroMenorACien
            {
                get { return numeroMenorACien; }
                set { numeroMenorACien = value < 100 ? value : 100; }
            }
        }

        static void Main(string[] args)
        {



            //las variables constantes se pueden llamar como las staticas pero no modificar
            Console.WriteLine(NumerosIrregulares.PI);
            Console.WriteLine(dataStatic = 4);

            NumerosIrregulares numIrre = new NumerosIrregulares();
            numIrre.NumeroMenorACien = 110;
            Console.WriteLine(numIrre.NumeroMenorACien);


            SaveCacheFirstAsyncStepExecuted("Esto se guardara en cache");
            var datoCacheado = GetCacheFirstAsyncStepExecuted().ToString();

            //Funcion Local 
            void MetodosObtenerIP()
            {
                ///////////////////
                Ip ipMain = new Ip();
                var dato = nameof(ipMain.GetClientIP);// para obtener el nombre del metodo
                ipMain.GetClientIP();
            }

            MetodosObtenerIP();





            int ProbandoRefAndFuncionLocal(ref string dataTests)
            {
                if (dataTests.Equals("1")) { dataTests = "2"; }
                return dataTests.Equals("1") ? 1 : 0;
            }

            void ProbandoOutAndFuncionLocal(out string dataTests)
            {
                dataTests = "2.Dos";
            }

            string uno = "1";
            ProbandoRefAndFuncionLocal(ref uno);

            string dos = "dos";
            ProbandoOutAndFuncionLocal(out dos);
            Console.WriteLine($"la variable tipo 'out' es ->{dos}");


            //Recursion.
            void conteo(int valoraContar) {

                if (valoraContar == 0) { return; }
                conteo(valoraContar - 1);
                Console.WriteLine($"conteo {valoraContar}");
            }

            conteo(5);

            object data = 5;
            Empleado persona = new Empleado();
            persona.plus(0.0);
            Console.WriteLine(persona.Valor);

            var dataa = new Dictionary<string, string>();
            dataa.Add("X-KEYCONTROL", "X-KEY");
            persona.AdditionalParameters = dataa;

            //Siempre entrara porque al momento de setear el diccionario tiene un StringComparer.InvariantCultureIgnoreCase ,que hace lo case 'case-insensitive'
            if (persona.AdditionalParameters.ContainsKey("X-KEYcontrol"))
            {
                Console.WriteLine("Suck!");
            }

            //toca referenciar  System.Xml.Linq
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $@"App_Data/{xmlFile}");
            if (!File.Exists(path)) { throw new SystemException($"File not found: '{path}'"); }

            XDocument libroRaiz = XDocument.Load(path, LoadOptions.None);

            //Busquedas en XML usando LINQ 
            var artista = (from dx in libroRaiz.Elements("CATALOG").Elements()
                           where dx.Element("TITLE").Value.Equals("Eros")
                           select dx).ToList();

            //XmlSerializer serializer = new XmlSerializer(typeof(ProductAttribute));
            XmlSerializer serializer = new XmlSerializer(typeof(List<CD>), new XmlRootAttribute("CATALOG"));

            StringReader stringReader = new StringReader(libroRaiz.ToString());

            List<CD> productList = (List<CD>)serializer.Deserialize(stringReader);

            //Tools para generar clase a partir del xml http://xmltocsharp.azurewebsites.net/
            //   var dataaa= (CD)serializer.Deserialize(stringReader);



            JObject xdato = libroRaiz.ToString().XmlAJson(true);

            //Manera de obtener datos	  			
            //  var nombreDos = xdato["Persons"]["Person"][1]["First"].ToString();

            Console.WriteLine($"Titulos de albunes");
            foreach (var item in xdato["CATALOG"]["CD"])
            {
                Console.WriteLine($"Titulo : {item["TITLE"]}");
            }



            GeneratePdf();

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

        public static readonly string FolderAppData = Path.GetFullPath($@"{AppDomain.CurrentDomain.BaseDirectory}\..\..\App_Data");
        public static void GeneratePdf()
        {

            Console.WriteLine("ujhum");
            var html = Path.Combine(FolderAppData, @"HTMLPage.html");
            var pdfFolder = Path.Combine(FolderAppData, @"Example_1.pdf");
            var xmlFolder = Path.Combine(FolderAppData, @"html.html");

            html = File.ReadAllText(xmlFolder);


            var alto = Length.Centimeters(27.94);
            var ancho = Length.Centimeters(21.59);


            PaperSize tamPag = new PaperSize(ancho,alto);
            
            var pdf = Pdf
                        .From(html).OfSize(tamPag)
                        .Comressed().WithMargins(Length.Centimeters(0.3))
                        .Content();

            File.WriteAllBytes(pdfFolder, pdf);

        }
    }

    [XmlRoot(ElementName = "CD")]
    public class CD
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


    }

    [XmlRoot(ElementName = "CATALOG")]
    public class CATALOG
    {
        [XmlElement(ElementName = "CD")]
        public List<CD> CD { get; set; }
    }

}