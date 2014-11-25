using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DuplicateCode.Encapsulation.Support;

namespace DuplicateCode.Encapsulation.Refactored {
   public class Person {
      public Person() {
         Addresses = new Addresses();
      }

      public int ID { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public Addresses Addresses { get; private set; }
   }


   public class Addresses: IEnumerable<Address> {
      public IEnumerable<Address> BusinessAddresses { get; private set; }
      public IEnumerable<Address> PersonalAddresses { get; private set; }

      public Addresses() {
         BusinessAddresses = new List<Address>();
         PersonalAddresses = new List<Address>();
      }

      public IEnumerator<Address> GetEnumerator() {
         return BusinessAddresses.Union( PersonalAddresses ).GetEnumerator();
      }

      IEnumerator IEnumerable.GetEnumerator() {
         return GetEnumerator();
      }
   }
}