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
using System.Xml.Serialization; 

#endregion

namespace XmlSerialization
{
   /// <summary>
   /// This is an example class that we will serialize to XML
   /// </summary>
   [XmlRoot( Namespace = "http://alteridem.net/person" )]
   public class Person
   {
      #region Private Members

      // Private properties/members are not serialized, only public properties/members
      private string _first;
      private string _last;
      private int _age;
      private Address _address;

      #endregion

      #region Construction

      /// <summary>
      /// The XML serializer requires a public default constructor
      /// </summary>
      public Person()
      {
      }

      /// <summary>
      /// You can provide other constructors, the XML serializer will
      /// not use them.
      /// </summary>
      public Person( string first, string last, int age, Address addr )
      {
         _first = first;
         _last = last;
         _age = age;
         _address = addr;
      }

      #endregion

      #region Public Properties

      [XmlElement( ElementName = "First" )]
      public string FirstName
      {
         get { return _first; }
         set { _first = value; }
      }

      [XmlElement( ElementName = "Last" )]
      public string LastName
      {
         get { return _last; }
         set { _last = value; }
      }

      [XmlAttribute]
      public int Age
      {
         get { return _age; }
         set { _age = value; }
      }

      /// <summary>
      /// Notice that complex types can be serialized too.
      /// </summary>
      [XmlElement]
      public Address Address
      {
         get { return _address; }
         set { _address = value; }
      }

      /// <summary>
      /// Since this is a generated property, we do not want it serialized to XML,
      /// therefore we use the XmlIgnore attribute.
      /// </summary>
      [XmlIgnore]
      public string StripperName
      {
         get { return StripperNameGenerator.GetStripperName( FirstName, LastName ); }
      }

      #endregion

      #region Methods

      public override string ToString()
      {
         return string.Format( "Name: {0} {1}{2}Stripper name:{3}{2}Address:{2}{4}", FirstName, LastName, Environment.NewLine, StripperName, Address );
      }

      #endregion
   }
}
