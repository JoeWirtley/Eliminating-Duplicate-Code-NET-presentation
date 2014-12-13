namespace DuplicateCode.GenericMethod.Support {
   public class PurchaseOrder {
      public Item[] ItemsOrders { get; set; }
      public string OrderNumber { get; set; }
   }

   public class Item {
      public string ID { get; set; }
      public decimal ItemPrice { get; set; }
   }
}