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

#endregion

namespace XmlSerialization
{
    class Program
    {
        private const string xmlFile = "person.xml";

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
            Ip ipMain = new Ip();

            ipMain.GetClientIP();


            SaveCacheFirstAsyncStepExecuted();
            object data = 5;
            Empleado persona = new Empleado();
            persona.plus(0.0);
            Console.WriteLine(persona.Valor);

            // var  strings = GetFormattedNumberStandard("propna");

            // Create and serialize out a person to XML
            //Person person = Person( "Rob", "Prouse", 39, new Address( "123 Candyland Dr", "Somewhere", "Ontario", "Canada", "A1B 2C3" ) );



            //Console.WriteLine( "Before serialization: {0}", person );
            //XmlSerializerHelper.Serialize<Person>( xmlFile, person );

            // Deserialize the person from XML
            Console.WriteLine();
            Person restored = XmlSerializerHelper.Deserialize<Person>(xmlFile);
            Console.WriteLine("After deserialization: {0}", restored);

            // Let's look at the generated XML
            Console.WriteLine("----------------------------------");
            using (StreamReader reader = new StreamReader(xmlFile))
            {
                while (!reader.EndOfStream)
                {
                    Console.WriteLine(reader.ReadLine());
                }
            }
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
