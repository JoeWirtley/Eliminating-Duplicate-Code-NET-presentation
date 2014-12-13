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
      private readonly List<Address> _businessAddresses;
      private readonly List<Address> _personalAddresses;

      public Addresses() {
         _businessAddresses = new List<Address>();
         _personalAddresses = new List<Address>();
      }

      public IEnumerable<Address> BusinessAddresses { get { return _businessAddresses; } }
      public IEnumerable<Address> PersonalAddresses { get { return _personalAddresses; } }

      public IEnumerator<Address> GetEnumerator() {
         return BusinessAddresses.Union( PersonalAddresses ).GetEnumerator();
      }

      IEnumerator IEnumerable.GetEnumerator() {
         return GetEnumerator();
      }

      public void AddPersonalAddress( Address address ) {
         _personalAddresses.Add( address );
      }

      public void AddBusinessAddress( Address address ) {
         _businessAddresses.Add( address );
      }

   }
}