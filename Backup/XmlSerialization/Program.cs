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

      static void Main( string[] args )
      {
         // Create and serialize out a person to XML
         Person person = new Person( "Rob", "Prouse", 39, new Address( "123 Candyland Dr", "Somewhere", "Ontario", "Canada", "A1B 2C3" ) );
         Console.WriteLine( "Before serialization: {0}", person );
         XmlSerializerHelper.Serialize<Person>( xmlFile, person );

         // Deserialize the person from XML
         Console.WriteLine();
         Person restored = XmlSerializerHelper.Deserialize<Person>( xmlFile );
         Console.WriteLine( "After deserialization: {0}", restored );

         // Let's look at the generated XML
         Console.WriteLine();
         using ( StreamReader reader = new StreamReader( xmlFile ) )
         {
            while ( !reader.EndOfStream )
            {
               Console.WriteLine( reader.ReadLine() );
            }
         }
         Console.WriteLine();

         Console.WriteLine( "Press enter to exit." );
         Console.ReadLine();
      }
   }
}
