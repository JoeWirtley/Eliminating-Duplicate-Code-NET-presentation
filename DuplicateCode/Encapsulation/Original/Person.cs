using System.Collections.Generic;

namespace DuplicateCode.Encapsulation.Original {
   public class Person {
      public Person() {
         BusinessAddresses = new List<Address>();
         PersonalAddresses = new List<Address>();
      }

      public int ID { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public IEnumerable<Address> BusinessAddresses { get; private set; }
      public IEnumerable<Address> PersonalAddresses { get; private set; }
   }

   public class Address {
      public string Address1 { get; set; }
      public string Address2 { get; set; }
      public string City { get; set; }
      public string State { get; set; }
      public string Zip { get; set; }
   }
}