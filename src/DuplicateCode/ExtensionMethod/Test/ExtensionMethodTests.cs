using DuplicateCode.ExtensionMethod.Support;
using FluentAssertions;
using NUnit.Framework;

namespace DuplicateCode.ExtensionMethod.Test {
   [TestFixture]
   public class ExtensionMethodTests {

      private void CoreStringReverseTest( IStringProcess process ) {
         process.ReverseString( null ).Should().BeNull();
         process.ReverseString( "" ).Should().Be( "" );
         process.ReverseString( "ABC" ).Should().Be( "CBA" );
      }


      [Test]
      public void TestOriginalStringReverse() {
         CoreStringReverseTest( new Original.StringProcess()  );
      }

      [Test]
      public void TestRefactoredStringReverse() {
         CoreStringReverseTest( new Refactored.StringProcess() );
      }

   }
}