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

#endregion

namespace XmlSerialization
{
   /// <summary>
   /// An address class to demonstrate that complex types
   /// will be serialized from the parent class. Also notice
   /// that we did not add any serialization attributes. Each
   /// public property will be serialized out as an XML Element.
   /// </summary>
   public class Address
   {
      #region Private Members

      private string _street;
      private string _city;
      private string _prov;
      private string _country;
      private string _postal; 

      #endregion

      #region Construction

      /// <summary>
      /// Even though we did not attribute this class, we still need
      /// the default constructor.
      /// </summary>
      public Address() { }

      public Address( string street, string city, string prov, string country, string postal )
      {
         _street = street;
         _city = city;
         _prov = prov;
         _country = country;
         _postal = postal;
      } 

      #endregion

      #region Public Properties

      public string Street
      {
         get { return _street; }
         set { _street = value; }
      }

      public string City
      {
         get { return _city; }
         set { _city = value; }
      }

      public string Province
      {
         get { return _prov; }
         set { _prov = value; }
      }

      public string Country
      {
         get { return _country; }
         set { _country = value; }
      }

      public string PostalCode
      {
         get { return _postal; }
         set { _postal = value; }
      } 

      #endregion

      #region Public Methods

      public override string ToString()
      {
         return string.Format( "{0}{1}{2}, {3} {4}", Street, Environment.NewLine, City, Province, PostalCode );
      } 

      #endregion
   }
}
