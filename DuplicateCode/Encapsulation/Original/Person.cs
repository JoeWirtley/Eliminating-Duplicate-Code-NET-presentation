using System.Collections.Generic;
using DuplicateCode.Encapsulation.Support;

namespace DuplicateCode.Encapsulation.Original {
   public class Person {
      private readonly List<Address> _businessAddresses;
      private readonly List<Address> _personalAddresses;

      public Person() {
         _businessAddresses = new List<Address>();
         _personalAddresses = new List<Address>();
      }

      public int ID { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }

      public IEnumerable<Address> BusinessAddresses {
         get { return _businessAddresses; }
      }

      public IEnumerable<Address> PersonalAddresses {
         get { return _personalAddresses; }
      }

      public void AddPersonalAddress( Address address ) {
         _personalAddresses.Add( address );
      }

      public void AddBusinessAddress( Address address ) {
         _businessAddresses.Add( address );
      }
   }
}