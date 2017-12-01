#region Copyright © 2007 by Alteridem Consulting, All Rights Reserved.
//
// This source file(s) may be redistributed by any means PROVIDING they
// are not sold for profit without the authors expressed written consent,
// and providing that this notice and the authors name and all copyright
// notices remain intact.
//
// THIS SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED. USE IT AT YOUR OWN RISK. THE AUTHOR ACCEPTS NO
// LIABILITY FOR ANY DATA DAMAGE/LOSS THAT THIS PRODUCT MAY CAUSE.
//
// Author: Rob Prouse http://www.alteridem.net
//
#endregion

#region Using Directives

using System;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;

#endregion

namespace XmlSerialization
{
	class Program
    {
        private const string xmlFile = "person.xml";
		string dat = "";

        #region Methods static

        private static bool GetCacheFirstAsyncStepExecuted()
        {
            var key = ChachingCachan.GetKeyName(cacheKeyName: CacheKeyNameEnum.FirstAsyncStepExecuted, cacheKeyParams: new object[] { "?¿" });
            var firstAsyncStepExecuted = ChachingCachan.Get(key);

            bool existsCache = firstAsyncStepExecuted != null && (int)firstAsyncStepExecuted == 1;
            if (existsCache) { ChachingCachan.Remove(key); }

            return existsCache;
        }
        private static void SaveCacheFirstAsyncStepExecuted()
        {
            var key = ChachingCachan.GetKeyName(cacheKeyName: CacheKeyNameEnum.FirstAsyncStepExecuted, cacheKeyParams: new object[] { "?¿" });
            ChachingCachan.Add(key: key, result: "1", expirationInMinutes: 1);
        }

        #endregion

        static void Main(string[] args)
        {


            ///////////////////
            Ip ipMain = new Ip();
            var dato = nameof(ipMain.GetClientIP);// para obtener el nombre del metodo
            ipMain.GetClientIP();



            SaveCacheFirstAsyncStepExecuted();
            object data = 5;
            Empleado persona = new Empleado();
            persona.plus(0.0);
            Console.WriteLine(persona.Valor);





            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            //toca referenciar  System.Xml.Linq
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $@"App_Data/{xmlFile}");
            if (!File.Exists(path)) { throw new SystemException($"File not found: '{path}'"); }

            XDocument libroRaiz = XDocument.Load(path, LoadOptions.None);

            //JObject dato = libroRaiz.ToString().XmlAJson(true);

            //Manera de obtener datos
          //  var nombreUno = dato["Persons"]["Person"][2]["First"].ToString();
          //  var nombreDos = dato["Persons"]["Person"][1]["First"].ToString();
          //  foreach (var item in dato["Persons"]["Person"])
          //  {
          //      Console.WriteLine("Nombre : ", item["First"]);
          //  }

            //Person restored =
            //XmlSerializerHelper.Deserialize<Person>(xmlFile);
            //Console.WriteLine("After deserialization: {0}", restored);

            // Let's look at the generated XML
            Console.WriteLine("----------------------------------");
            //   using (StreamReader reader = new StreamReader(xmlFile))
            //   {
            //       while (!reader.EndOfStream)
            //       {
            //           Console.WriteLine(reader.ReadLine());
            //       }
            //   }
            Console.WriteLine();

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
}
