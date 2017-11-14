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
   
   public abstract class Person
   {
      #region Private Members

      // Private properties/members are not serialized, only public properties/members
      protected string _first;
      protected string _last;
      protected int _age;


        #endregion
        public abstract bool plus(double sueldoPlus);

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


      [XmlIgnore]
      public string StripperName
      {
         get { return StripperNameGenerator.GetStripperName( FirstName, LastName ); }
      }

      #endregion

      #region Methods

      public override string ToString()
      {
         return string.Format( "Name: {0} {1}{2}Stripper name:{3}{2}Address:{2}{4}", FirstName, LastName, Environment.NewLine, StripperName );
      }

      #endregion
   }
}
