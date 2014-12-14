using System.Diagnostics;
using DuplicateCode.GenericMethod.Support;
using FluentAssertions;
using NUnit.Framework;

namespace DuplicateCode.GenericMethod.Test {
   [TestFixture]
   public class GenericMethodInvoiceTest {
      private string _invoiceXml;
      private Invoice _invoice;

      [SetUp]
      public void BeforeEachTest() {
         _invoice = new Invoice {
            InvoiceNumber = "12345",
            ItemsOrders = new[] {
               new Item {ID = "1", ItemPrice = 10m},
               new Item {ID = "2", ItemPrice = 20m},
               new Item {ID = "3", ItemPrice = 30m}
            }
         };

         _invoiceXml = @"<?xml version='1.0' encoding='utf-8'?>
                               <Invoice>
                                  <ItemsOrders>
                                      <Item><ID>1</ID><ItemPrice>10</ItemPrice></Item>
                                      <Item><ID>2</ID><ItemPrice>20</ItemPrice></Item>
                                      <Item><ID>3</ID><ItemPrice>30</ItemPrice></Item>
                                  </ItemsOrders>
                                  <InvoiceNumber>12345</InvoiceNumber>
                               </Invoice>";
      }

      [Test]
      public void TestOriginalSerialize() {
         Original.XmlProcessor processor = new Original.XmlProcessor();

         string poXml = processor.SerializeInvoice( _invoice );

         poXml.Should().NotBeEmpty();
         Debug.Write( poXml  );
         // Yes, this is pretty low bar for a passing unit test, but comparing XML is beynod the scope of this project
      }

      [Test]
      public void TestOriginalDeserialize() {
         Original.XmlProcessor processor = new Original.XmlProcessor();

         Invoice po = processor.DeserializeInvoice( _invoiceXml );

         po.Should().NotBeNull();
         po.ItemsOrders.Should().NotBeEmpty().And.HaveCount( 3 );
         po.InvoiceNumber.Should().Be( "12345" );
      }

      [Test]
      public void TestRefactoredSerialize() {
         Refactored.XmlProcessor processor = new Refactored.XmlProcessor();

         string poXml = processor.Serialize( _invoice );

         poXml.Should().NotBeEmpty();
         Debug.Write( poXml );
         // Yes, this is pretty low bar for a passing unit test, but comparing XML is beynod the scope of this project
      }

      [Test]
      public void TestRefactoredDeserialize() {
         Refactored.XmlProcessor processor = new Refactored.XmlProcessor();

         Invoice po = processor.Deserialize<Invoice>( _invoiceXml );

         po.Should().NotBeNull();
         po.ItemsOrders.Should().NotBeEmpty().And.HaveCount( 3 );
         po.InvoiceNumber.Should().Be( "12345" );
      }
   }
}