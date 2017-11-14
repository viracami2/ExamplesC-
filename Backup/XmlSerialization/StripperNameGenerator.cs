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
   /// A class for generating someone's stripper name.
   /// </summary>
   public static class StripperNameGenerator
   {
      #region Generate the stripper name

      /// <summary>
      /// Generates your stripper name based on your first and last name.
      /// </summary>
      /// <param name="first">First name</param>
      /// <param name="last">Last name</param>
      /// <returns>Stripper name</returns>
      public static string GetStripperName( string first, string last )
      {
         // Find the position in the first and last name to take the stripper name from
         int pos1 = 0;
         int pos2 = 0;
         int pos3 = 0;

         if ( !string.IsNullOrEmpty( first ) )
         {
            pos1 = first.Length >= 3 ? 2 : first.Length - 1;
         }

         if ( !string.IsNullOrEmpty( last ) )
         {
            pos2 = last.Length >= 2 ? 1 : last.Length - 1;
            pos3 = last.Length >= 3 ? 2 : last.Length - 1;
         }

         // Get the character in the given positions
         char ch1 = first.ToLower()[pos1];
         char ch2 = last.ToLower()[pos2];
         char ch3 = last.ToLower()[pos3];

         // Calculate the index into the name arrays
         int i1 = ( int )( ( byte )ch1 - ( byte )( 'a' ) ) % 26;
         int i2 = ( int )( ( byte )ch2 - ( byte )( 'a' ) ) % 26;
         int i3 = ( int )( ( byte )ch3 - ( byte )( 'a' ) ) % 26;

         return string.Format( "{0} {1}{2}", _stripperFirst[i1], _stripperLastOne[i2], _stripperLastTwo[i3] );
      }

      #endregion

      #region Parts of the stripper name

      // Use the third letter of your first name to
      // determine your new first name:
      private static string[] _stripperFirst = new string[] {
         "Fantasia",
         "Chesty",
         "Starr",
         "Diamond",
         "Montana",
         "Angel",
         "Sugar",
         "Mimi",
         "Lola",
         "Kitty",
         "Roxie",
         "Dallas",
         "Princess",
         "Heidi",
         "Bambi",
         "Bunny",
         "Brandy",
         "Sugar",
         "Candy",
         "Raquelle",
         "Sapphire",
         "Cinnamon",
         "Blaze",
         "Trixie",
         "Isis",
         "Jade"
      };

      // Use the second letter of your last name to 
      // determine the first half of your new last name:
      private static string[] _stripperLastOne = new string[] {
         "Leather",
         "Dream",
         "Sunny",
         "Deep",
         "Heaven",
         "Tight",
         "Shimmer",
         "Velvet",
         "Lusty",
         "Harley",
         "Passion",
         "Dazzle",
         "Dixon",
         "Spank",
         "Glitter",
         "Razor",
         "Meadow",
         "Glitz",
         "Sparkle",
         "Sweet",
         "Silver",
         "Tickle",
         "Cherry",
         "Hard",
         "Night",
         "Amber"
      };

      // Use the third letter of your last name to
      // determine the second half of
      // your new last name:
      private static string[] _stripperLastTwo = new string[] {
         "hooter",
         "horn",
         "tower",
         "fire",
         "thighs",
         "hips",
         "side",
         "jugs",
         "shock",
         "cocker",
         "brook",
         "tush",
         "sizzle",
         "ridge",
         "kiss",
         "bomb",
         "cream",
         "thong",
         "heat",
         "whip",
         "cheeks",
         "rock",
         "hiney",
         "button",
         "lick",
         "juice"
      };

      #endregion
   }
}
