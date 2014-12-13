using DuplicateCode.ClassHierarchy.Original;
using DuplicateCode.ClassHierarchy.Refactored;
using FluentAssertions;
using NUnit.Framework;
using Employee = DuplicateCode.ClassHierarchy.Original.Employee;

namespace DuplicateCode.ClassHierarchy.Test {
   [TestFixture]
   public class EmployeeTest {
      [Test]
      public void TestOriginalEmployees() {
         Employee hourlyEmployee = new Employee {FirstName = "Sio", LastName = "Bibble", EmployeeType = EmployeeType.Hourly};
         Employee salariedEmployee = new Employee {FirstName = "Cliegg", LastName = "Lars", EmployeeType = EmployeeType.Salaried};
         Employee contractEmployee = new Employee {FirstName = "Boba", LastName = "Fett", EmployeeType = EmployeeType.Contract};

         HumanResourcesProcess process = new HumanResourcesProcess();

         process.GetHourlyRate( hourlyEmployee ).Should().Be( 10m );
         process.GetHourlyRate( salariedEmployee ).Should().Be( 15m );
         process.GetHourlyRate( contractEmployee ).Should().Be( 20m );
      }

      [Test]
      public void TestRefactoredEmployees() {
         Refactored.Employee hourlyEmployee = new HourlyEmployee {FirstName = "Sio", LastName = "Bibble"};
         Refactored.Employee salariedEmployee = new SalariedEmployee {FirstName = "Cliegg", LastName = "Lars"};
         Refactored.Employee contractEmployee = new ContractEmployee {FirstName = "Boba", LastName = "Fett"};

         HumanResources.EmployeeStrategy( hourlyEmployee ).GetHourlyRate().Should().Be( 10m );
         HumanResources.EmployeeStrategy( salariedEmployee ).GetHourlyRate().Should().Be( 15m );
         HumanResources.EmployeeStrategy( contractEmployee ).GetHourlyRate().Should().Be( 20m );
      }
   }
}