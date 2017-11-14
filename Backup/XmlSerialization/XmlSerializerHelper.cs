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
using System.Xml.Serialization; 

#endregion

namespace XmlSerialization
{
   /// <summary>
   /// Helper methods for serializing/deserializing classes to/from XML files.
   /// </summary>
   public static class XmlSerializerHelper
   {
      #region Xml Serialization

      /// <summary>
      /// Serialize a class out to an XML file.
      /// </summary>
      /// <typeparam name="T">The type of the class that you are serializing.</typeparam>
      /// <param name="filename">The name of the XML file that you are serializing to.</param>
      /// <param name="data">The data that you are serializing out to the XML file.</param>
      public static void Serialize<T>( string filename, T data )
      {
         TextWriter writer = null;
         try
         {
            writer = new StreamWriter( filename );
            XmlSerializer serializer = new XmlSerializer( typeof( T ) );
            serializer.Serialize( writer, data );
         }
         finally
         {
            if ( writer != null )
            {
               writer.Close();
            }
         }
      }

      /// <summary>
      /// Reads in an XML file and returns the results as an instance of a class.
      /// </summary>
      /// <typeparam name="T">The type that you expect to be returned.</typeparam>
      /// <param name="filename">The name of the XML file that you are deserializing from.</param>
      /// <returns>The class that has been deserialized from the XML.</returns>
      public static T Deserialize<T>( string filename )
      {
         TextReader reader = null;
         T data = default(T);
         try
         {
            reader = new StreamReader( filename );
            XmlSerializer serializer = new XmlSerializer( typeof( T ) );
            data = ( T )serializer.Deserialize( reader );
         }
         finally
         {
            if ( reader != null )
            {
               reader.Close();
            }
         }
         return data;
      }

      #endregion
   }
}
