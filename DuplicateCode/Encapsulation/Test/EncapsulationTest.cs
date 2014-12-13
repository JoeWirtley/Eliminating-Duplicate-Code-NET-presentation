using DuplicateCode.Encapsulation.Support;
using FluentAssertions;
using NUnit.Framework;

namespace DuplicateCode.Encapsulation.Test {
   [TestFixture]
   public class EncapsulationTest {
      [SetUp]
      public void BeforeEachTest() {
      }

      [Test]
      public void TestOriginalQuery() {
         Original.Person person = new Original.Person() {
            FirstName = "Evan",
            LastName = "Piell"
         };
         person.AddPersonalAddress( new Address {Address1 = "123 Oak", City = "Theed", State = "CA", Zip = "91126"} );
         person.AddBusinessAddress( new Address {Address1 = "12 Main", City = "Theed", State = "CA", Zip = "91126"} );
         person.AddBusinessAddress( new Address {Address1 = "2115 High", City = "Las Vegaa", State = "NV", Zip = "89101"} );

         Original.AddressProcess process = new Original.AddressProcess();

         string[] states = process.GetUniqueStates( person );
         states.Should().NotBeEmpty().And.HaveCount( 2 );
         states.Should().BeEquivalentTo( new[] {"CA", "NV"} );

         int addressCount = process.CountMatchingAddresses( person, ( address ) => true );
         addressCount.Should().Be( 3 );
      }

      [Test]
      public void TestRefactoredQuery() {
         Refactored.Person person = new Refactored.Person() {
            FirstName = "Evan",
            LastName = "Piell"
         };
         person.Addresses.AddPersonalAddress( new Address {Address1 = "123 Oak", City = "Theed", State = "CA", Zip = "91126"} );
         person.Addresses.AddBusinessAddress( new Address { Address1 = "12 Main", City = "Theed", State = "CA", Zip = "91126" } );
         person.Addresses.AddBusinessAddress( new Address { Address1 = "2115 High", City = "Las Vegaa", State = "NV", Zip = "89101" } );

         Refactored.AddressProcess process = new Refactored.AddressProcess();

         string[] states = process.GetUniqueStates( person );
         states.Should().NotBeEmpty().And.HaveCount( 2 );
         states.Should().BeEquivalentTo( new[] {"CA", "NV"} );

         int addressCount = process.CountMatchingAddresses( person, ( address ) => true );
         addressCount.Should().Be( 3 );
      }
   }
}