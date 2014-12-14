namespace DuplicateCode.ExtensionMethod.Refactored {
   public static class StringExtensions {
      public static bool IsNullOrEmpty( this string value ) {
         return string.IsNullOrEmpty( value );
      }

      public static string ToStringPreserveNull( this object value ) {
         return value == null ? null: value.ToString();
      }
   }
}