namespace DuplicateCode.ClassHierarchy.Refactored {
   public abstract class Employee {
      public string FirstName { get; set; }
      public string LastName { get; set; }
   }

   public class SalariedEmployee: Employee {
   }

   public class HourlyEmployee: Employee {
   }

   public class ContractEmployee: Employee {
   }

}