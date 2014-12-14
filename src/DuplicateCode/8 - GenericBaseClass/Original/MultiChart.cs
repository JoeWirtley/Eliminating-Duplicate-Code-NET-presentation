using DuplicateCode.GenericBaseClass.Support;

namespace DuplicateCode.GenericBaseClass.Original {
   public class MultiChart: ChartBase {
      private MultichartDefinition _chartDef;

      public MultiChart() {
      }

      public MultiChart( MultichartDefinition chartDef ) {
         _chartDef = chartDef;
      }

      public override IChartDefCommon ChartDefinition {
         get { return _chartDef; }
         set { _chartDef = ( MultichartDefinition ) value; }
      }

      protected override ChartBase CreateNewInstance() {
         return new MultiChart();
      }

      public override string Serialize( IChartSerializer chartSerializer ) {
         return chartSerializer.Serialize( _chartDef );
      }
   }
}