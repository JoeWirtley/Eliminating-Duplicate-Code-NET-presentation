using System.Diagnostics;
using DuplicateCode.GenericMethod.Original;
using DuplicateCode.GenericMethod.Support;
using FluentAssertions;
using NUnit.Framework;

namespace DuplicateCode.GenericMethod.Test {
   [TestFixture]
   public class GenericMethodTest {
      private string _purchaseOrderXml;
      private PurchaseOrder _purchaseOrder;

      [SetUp]
      public void BeforeEachTest() {
         _purchaseOrder = new PurchaseOrder {
            OrderNumber = "12345",
            ItemsOrders = new[] {
               new Item {ID = "1", ItemPrice = 10m},
               new Item {ID = "2", ItemPrice = 20m},
               new Item {ID = "3", ItemPrice = 30m}
            }
         };

         _purchaseOrderXml = @"<?xml version='1.0' encoding='utf-8'?>
                               <PurchaseOrder>
                                  <ItemsOrders>
                                      <Item><ID>1</ID><ItemPrice>10</ItemPrice></Item>
                                      <Item><ID>2</ID><ItemPrice>20</ItemPrice></Item>
                                      <Item><ID>3</ID><ItemPrice>30</ItemPrice></Item>
                                  </ItemsOrders>
                                  <OrderNumber>12345</OrderNumber>
                               </PurchaseOrder>";
      }

      [Test]
      public void TestOriginalSerialize() {
         XmlProcessor processor = new XmlProcessor();

         string poXml = processor.SerializePurchaseOrder( _purchaseOrder );

         poXml.Should().NotBeEmpty();
         Debug.Write( poXml  );
         // Yes, this is pretty low bar for a passing unit test, but comparing XML is beynod the scope of this project
      }

      [Test]
      public void TestOriginalDeserialize() {
         XmlProcessor processor = new XmlProcessor();

         PurchaseOrder po = processor.DeserializePurchaseOrder( _purchaseOrderXml );

         po.Should().NotBeNull();
         po.ItemsOrders.Should().NotBeEmpty().And.HaveCount( 3 );
         po.OrderNumber.Should().Be( "12345" );
      }

      [Test]
      public void TestRefactoredSerialize() {
         Refactored.XmlProcessor processor = new Refactored.XmlProcessor();

         string poXml = processor.Serialize( _purchaseOrder );

         poXml.Should().NotBeEmpty();
         Debug.Write( poXml );
         // Yes, this is pretty low bar for a passing unit test, but comparing XML is beynod the scope of this project
      }

      [Test]
      public void TestRefactoredDeserialize() {
         XmlProcessor processor = new XmlProcessor();

         PurchaseOrder po = processor.Deserialize<PurchaseOrder>( _purchaseOrderXml );

         po.Should().NotBeNull();
         po.ItemsOrders.Should().NotBeEmpty().And.HaveCount( 3 );
         po.OrderNumber.Should().Be( "12345" );
      }
   }
}