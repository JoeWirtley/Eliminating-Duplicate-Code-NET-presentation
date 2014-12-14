using System;
using DuplicateCode.ExtensionMethod.Support;

namespace DuplicateCode.ExtensionMethod.Refactored {
   public class StringProcess: IStringProcess {
      public string ReverseString( string source ) {
         if ( source.IsNullOrEmpty() ) {
            return source.ToStringPreserveNull();
         }
         char[] charArray = source.ToCharArray();
         Array.Reverse( charArray );
         return new string( charArray );
      }
   }
}