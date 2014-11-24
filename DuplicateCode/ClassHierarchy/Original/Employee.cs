namespace DuplicateCode.ClassHierarchy.Original {
   public class Employee {
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public EmployeeType EmployeeType { get; set; }
   }

   public enum EmployeeType {
      Hourly,
      Salaried,
      Contract
   }
}