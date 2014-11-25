using DuplicateCode.GenericBaseClass.Support;

namespace DuplicateCode.GenericBaseClass.Original {
   public class MultiChart: MultiChartBase {
      private MultichartDefinition _chartDef;

      public MultiChart() {
      }

      public MultiChart( MultichartDefinition chartDef ) {
         _chartDef = chartDef;
      }

      public override IChartDefCommon MultiChartDefinition {
         get { return _chartDef; }
         set { _chartDef = ( MultichartDefinition ) value; }
      }

      protected override MultiChartBase CreateNewInstance() {
         return new MultiChart();
      }

      public override string ChartType {
         get { return MultichartDefinition.ChartTypeKey; }
      }

      public override string Serialize( IChartSerializer chartSerializer ) {
         return chartSerializer.Serialize( _chartDef );
      }
   }
}