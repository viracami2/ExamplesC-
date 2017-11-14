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
   public class Empleado : Person
    {
      #region Private Members

      private string _street;
      private double valor;


      #endregion

      #region Construction

      /// <summary>
      /// Even though we did not attribute this class, we still need
      /// the default constructor.
      /// </summary>
      public Empleado() { }

      public Empleado( string street )
      {
         _street = street;
         
      } 

      #endregion

      #region Public Properties

      public string Street
      {
         get { return _street; }
         set { _street = value; }
      }

      public double Valor
        {
         get { return valor; }
         set { valor = value; }
      }

    

        public override bool plus(double sueldoPlus)
        {
            //if (sueldoPlus = ) { }
           valor =sueldoPlus * 2;
            return true;
        }

        #endregion

        #region Public Methods

        public override string ToString()
      {
         return string.Format( "{0}{1}{2}, {3} {4}", Street, Environment.NewLine,Valor );
      } 

      #endregion
   }
}
