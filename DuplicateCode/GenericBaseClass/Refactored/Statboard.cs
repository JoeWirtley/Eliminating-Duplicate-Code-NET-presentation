using DuplicateCode.GenericBaseClass.Support;

namespace DuplicateCode.GenericBaseClass.Refactored {
   public class Statboard: MultiChartBase<Statboard, StatboardDefinition> {
      public Statboard() {
      }

      public Statboard( StatboardDefinition chartDef ) {
         MultiChartDefinition = chartDef;
      }

      public override string ChartType {
         get { return StatboardDefinition.ChartTypeKey; }
      }

      public override string Serialize( IChartSerializer chartSerializer ) {
         return chartSerializer.Serialize( MultiChartDefinition );
      }
   }
}