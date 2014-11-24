using System;

namespace DuplicateCode.ClassHierarchy.Refactored {
   public static class HumanResources {
      public static IEmployeeStrategy EmployeeStrategy( Employee employee ) {
         if ( employee is HourlyEmployee ) {
            return new HourlyStrategy();
         }
         if ( employee is SalariedEmployee ) {
            return new SalariedStrategy();
         }
         if ( employee is ContractEmployee ) {
            return new ContractStrategy();
         }
         throw new Exception( "Unknown employee type" );
      }
   }


   public interface IEmployeeStrategy {
      decimal GetHourlyRate();
      int GetVacationDays();
   }


   public class HourlyStrategy: IEmployeeStrategy {
      public decimal GetHourlyRate() {
         return 10.0m;
      }

      public int GetVacationDays() {
         return 5;
      }
   }

   public class SalariedStrategy: IEmployeeStrategy {
      public decimal GetHourlyRate() {
         return 15.0m;
      }

      public int GetVacationDays() {
         return 10;
      }
   }

   public class ContractStrategy: IEmployeeStrategy {
      public decimal GetHourlyRate() {
         return 20.0m;
      }

      public int GetVacationDays() {
         return 0;
      }
   }
}