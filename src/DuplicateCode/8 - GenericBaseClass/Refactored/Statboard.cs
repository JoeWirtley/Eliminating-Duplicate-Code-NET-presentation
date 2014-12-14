using DuplicateCode.GenericBaseClass.Support;

namespace DuplicateCode.GenericBaseClass.Refactored {
   public class Statboard: ChartBase<Statboard, StatboardDefinition> {
      public Statboard() {
      }

      public Statboard( StatboardDefinition chartDef ) {
         ChartDefinition = chartDef;
      }

      public override string Serialize( IChartSerializer chartSerializer ) {
         return chartSerializer.Serialize( ChartDefinition );
      }
   }
}