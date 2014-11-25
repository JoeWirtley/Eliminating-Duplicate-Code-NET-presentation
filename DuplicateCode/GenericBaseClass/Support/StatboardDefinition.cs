using System;

namespace DuplicateCode.GenericBaseClass.Support {
   public class StatboardDefinition: IChartDefCommon {
      public Guid Id { get; set; }
      public string Name { get; set; }
      public static string ChartTypeKey { get; set; }
   }
}