﻿using System;
using System.Linq;
using DuplicateCode.Encapsulation.Support;

namespace DuplicateCode.Encapsulation.Refactored {
   public class AddressProcess {
      public string[] GetUniqueStates( Person person ) {
         return person.Addresses.GetUniqueStates().ToArray();
      }

      public int CountMatchingAddresses( Person person, Func<Address, bool> matchingFunction ) {
         return person.Addresses.Count( matchingFunction );
      }
   }
}