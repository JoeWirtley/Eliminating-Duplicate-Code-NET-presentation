using System;
using DuplicateCode.ExtensionMethod.Support;

namespace DuplicateCode.ExtensionMethod.Original {
   public class StringProcess: IStringProcess {
      public string ReverseString( string source ) {
         if ( string.IsNullOrEmpty( source ) ) {
            return source ?? null;
         }
         char[] charArray = source.ToCharArray();
         Array.Reverse( charArray );
         return new string( charArray );
      }
   }
}