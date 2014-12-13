using System;

namespace DuplicateCode.ClassHierarchy.Original {
   public class HumanResourcesProcess {
      public Decimal GetHourlyRate( Employee employee ) {
         Decimal rate;
         switch ( employee.EmployeeType ) {
            case EmployeeType.Hourly:
               rate = 10.0m;
               break;
            case EmployeeType.Salaried:
               rate = 15.0m;
               break;
            case EmployeeType.Contract:
               rate = 20.0m;
               break;
            default:
               throw new ArgumentOutOfRangeException();
         }
         return rate;
      }

      public int GetVacationDays( Employee employee ) {
         int vacationDays;
         switch ( employee.EmployeeType ) {
            case EmployeeType.Hourly:
               vacationDays = 5;
               break;
            case EmployeeType.Salaried:
               vacationDays = 20;
               break;
            case EmployeeType.Contract:
               vacationDays = 0;
               break;
            default:
               throw new ArgumentOutOfRangeException();
         }
         return vacationDays;
      }
   }
}