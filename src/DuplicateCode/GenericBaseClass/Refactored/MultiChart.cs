using DuplicateCode.GenericBaseClass.Support;

namespace DuplicateCode.GenericBaseClass.Refactored {
   public class MultiChart: MultiChartBase<MultiChart, MultichartDefinition> {
      public MultiChart() {
      }

      public MultiChart( MultichartDefinition chartDef ) {
         MultiChartDefinition = chartDef;
      }

      public override string ChartType {
         get { return MultichartDefinition.ChartTypeKey; }
      }

      public override string Serialize( IChartSerializer chartSerializer ) {
         return chartSerializer.Serialize( MultiChartDefinition );
      }
   }
}