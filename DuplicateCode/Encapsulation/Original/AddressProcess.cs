using System;
using System.Linq;
using DuplicateCode.Encapsulation.Support;

namespace DuplicateCode.Encapsulation.Original {
   public class AddressProcess {
      public string[] GetUniqueStates( Person person ) {
         var businessStates = person.BusinessAddresses.Select( address => address.State ).Distinct();

         var personalStates = person.PersonalAddresses.Select( address => address.State ).Distinct();

         return businessStates.Union( personalStates ).ToArray();
      }

      public int CountMatchingAddresses( Person person, Func<Address, bool> matchingFunction ) {
         var matchingBusinessAddresses = person.BusinessAddresses.Count( matchingFunction );

         var matchingPersonalAddresses = person.BusinessAddresses.Count( matchingFunction );

         return matchingBusinessAddresses + matchingPersonalAddresses;
      }
   }
}