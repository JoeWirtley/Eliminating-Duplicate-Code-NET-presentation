using System.Collections.Generic;
using DuplicateCode.Encapsulation.Support;

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
}